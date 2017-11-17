using IPTXamarinForms.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IPTXamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplicationPage : ContentPage
    {
        public ApplicationPage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            btnShowApplication.Pressed += BtnShowApplication_Pressed;
        }

        private async void BtnShowApplication_Pressed(object sender, EventArgs e)
        {
            string url = Settings.WebApiUrl;
            url = string.Format("{0}{1}application?ApplicationNumber={2}", url, url.EndsWith("/") ? string.Empty : "/", entryApplicationNumber.Text);
            string jsonString = await JsonFunctions.GetJson(url);

            if (jsonString == "Error")
            {
                lblStatus.IsVisible = true;
                lblStatus.Text = jsonString;
            }
            else
            {
                JObject json = JObject.Parse(jsonString);
                List<Models.AppAsset> listAppAssets = new List<Models.AppAsset>();
                List<Models.Customer> listCustomers = new List<Models.Customer>();
                foreach (var item in json["AppAssets"])
                {
                    listAppAssets.Add(new Models.AppAsset
                    {
                        SequenceNumber = (Nullable<int>)item["SequenceNumber"],
                        Description = (string)item["Description"],
                        Make = (string)item["Make"],
                        Model = (string)item["Model"],
                        Series = (string)item["Series"],
                        BodyStyle = (string)item["BodyStyle"],
                        Year = (Nullable<int>)item["Year"],
                        VIN = (string)item["VIN"],
                        Condition = (Nullable<int>)item["Condition"],
                        Mileage = (Nullable<int>)item["Mileage"],
                        MSRP = (Nullable<decimal>)item["MSRP"],
                        AdjustedMSRP = (Nullable<decimal>)item["AdjustedMSRP"],
                        WholesaleClean = (Nullable<decimal>)item["WholesaleClean"],
                        Type = (string)item["Type"],
                        AssetTypeName = (int)item["AssetTypeName"],
                        LenderBookValue = (Nullable<decimal>)item["LenderBookValue"],
                        OriginalBookValue = (Nullable<decimal>)item["OriginalBookValue"],
                        OriginalBookType = (string)item["OriginalBookType"],
                    });
                }
                foreach (var item in json["Customers"])
                {
                    Models.Customer customer = new Models.Customer();

                    customer.SequenceNumber = (Nullable<int>)item["SequenceNumber"];
                    customer.RelationType = (Nullable<int>)item["RelationType"];
                    customer.RelationCode = (string)item["RelationCode"];
                    customer.CustomerType = (int)item["CustomerType"];

                    if (customer.CustomerType == 1)
                    {
                        customer.Prefix = (string)item["Prefix"];
                        customer.Suffix = (string)item["Suffix"];
                        customer.Gender = (string)item["Gender"];
                        customer.LastName = (string)item["LastName"];
                        customer.FirstName = (string)item["FirstName"];
                        customer.MiddleInitial = (string)item["MiddleInitial"];
                        customer.DateOfBirth = (Nullable<System.DateTime>)item["DateOfBirth"];
                        customer.SIN = (string)item["SIN"];
                        customer.MaritalStatus = (string)item["MaritalStatus"];
                        customer.Phone = (string)item["Phone"];
                        customer.MobilePhone = (string)item["MobilePhone"];
                        customer.Email = (string)item["Email"];
                        customer.SuiteNo = (string)item["SuiteNo"];
                        customer.StreetNumber = (string)item["StreetNumber"];
                        customer.StreetName = (string)item["StreetName"];
                        customer.StreetType = (string)item["StreetType"];
                        customer.StreetDir = (string)item["StreetDir"];
                        customer.City = (string)item["City"];
                        customer.Province = (string)item["Province"];
                        customer.PostalCode = (string)item["PostalCode"];
                    }
                    else if (customer.CustomerType == 2)
                    {
                        customer.NatureOfBusiness = (string)item["NatureOfBusiness"];
                        customer.LegalCompanyName = (string)item["LegalCompanyName"];
                        customer.DoingBusinessAs = (string)item["DoingBusinessAs"];
                        customer.PrincipalOwner = (string)item["PrincipalOwner"];
                        customer.NumberOfEmployees = (Nullable<int>)item["NumberOfEmployees"];
                        customer.YearsInBusiness = (Nullable<int>)item["YearsInBusiness"];
                    }

                    listCustomers.Add(customer);
                }
                Models.CreditDecision creditDecision = new Models.CreditDecision
                {
                    tier = (string)json["tier"],
                    ProgramName = (string)json["ProgramName"],
                    DecStatus = (string)json["DecStatus"],
                    DecDateTime = (Nullable<System.DateTime>)json["DecDateTime"],
                    LenderComments = (string)json["LenderComments"],
                    Amount = (Nullable<float>)json["Amount"],
                    InterestRate = (Nullable<float>)json["InterestRate"],
                    Term = (Nullable<int>)json["Term"],
                    Amortization = (Nullable<int>)json["Amortization"],
                    TotalMthPay = (Nullable<float>)json["TotalMthPay"],
                    PaymentFrequency = (string)json["PaymentFrequency"],
                    FirstPaymentDate = (Nullable<System.DateTime>)json["FirstPaymentDate"],
                    CashDown = (Nullable<float>)json["CashDown"],
                };
                Models.Application CAFApplication = new Models.Application
                {
                    ID = (long)json["ID"],
                    PortalApplicationID = (string)json["PortalApplicationID"],
                    CreatedBy = (string)json["CreatedBy"],
                    CreatedOn = (Nullable<System.DateTime>)json["CreatedOn"],
                    ApplicationNumber = (string)json["ApplicationNumber"],
                    DealerName = (string)json["DealerName"],
                    AuditFundingWorkflowStateName = (string)json["AuditFundingWorkflowStateName"],
                    IncomeWorkflowStateName = (string)json["IncomeWorkflowStateName"],
                    CreditWorkflowStateName = (string)json["CreditWorkflowStateName"],
                    BusinessLineName = (string)json["BusinessLineName"],
                    RiskTierName = (string)json["RiskTierName"],
                    StructureName = (string)json["StructureName"],
                    Subvented = (string)json["Subvented"],
                    AppAssets = listAppAssets,
                    Customers = listCustomers,
                    LastCreditDecision = creditDecision
                };
            }
        }
    }
}