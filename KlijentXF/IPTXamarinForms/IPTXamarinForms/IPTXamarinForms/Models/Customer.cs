using System;

namespace IPTXamarinForms.Models
{
    public class Customer
    {
        public Nullable<int> SequenceNumber { get; set; }
        public Nullable<int> RelationType { get; set; }
        public string RelationCode { get; set; }
        public int CustomerType { get; set; }

        //ovo prikazati ako je CustomerType == 1
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string Gender { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string SIN { get; set; }
        public string MaritalStatus { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string SuiteNo { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public string StreetDir { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }

        //ovo prikazati ako je CustomerType == 2
        public string NatureOfBusiness { get; set; }
        public string LegalCompanyName { get; set; }
        public string DoingBusinessAs { get; set; }
        public string PrincipalOwner { get; set; }
        public Nullable<int> NumberOfEmployees { get; set; }
        public Nullable<int> YearsInBusiness { get; set; }
    }
}
