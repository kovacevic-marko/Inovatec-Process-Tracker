using System;
using System.Collections.Generic;

namespace IPTXamarinForms.Models
{
    public class Application
    {
        public long ID { get; set; }
        public string PortalApplicationID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ApplicationNumber { get; set; }
        public string DealerName { get; set; }
        public string AuditFundingWorkflowStateName { get; set; }
        public string IncomeWorkflowStateName { get; set; }
        public string CreditWorkflowStateName { get; set; }
        public string BusinessLineName { get; set; }
        public string RiskTierName { get; set; }
        public string StructureName { get; set; }
        public string Subvented { get; set; }
        public List<AppAsset> AppAssets { get; set; }
        public List<Customer> Customers { get; set; }
        public CreditDecision LastCreditDecision { get; set; }
    }
}
