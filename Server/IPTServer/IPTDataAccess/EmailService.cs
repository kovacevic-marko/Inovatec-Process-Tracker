//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IPTDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmailService
    {
        public int id { get; set; }
        public int ClientServiceID { get; set; }
        public int EmailSubscriptionId { get; set; }
        public int ClientServiceID { get; set; }
    
        public virtual ClientService ClientService { get; set; }
        public virtual EmailNotificationSubscription EmailNotificationSubscription { get; set; }
        public virtual ClientService ClientService1 { get; set; }
    }
}
