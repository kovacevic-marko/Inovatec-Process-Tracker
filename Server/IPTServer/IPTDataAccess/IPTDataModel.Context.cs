﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IPTDBEntities : DbContext
    {
        public IPTDBEntities()
            : base("name=IPTDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientService> ClientServices { get; set; }
        public virtual DbSet<EmailNotification> EmailNotifications { get; set; }
        public virtual DbSet<EmailNotificationSubscription> EmailNotificationSubscriptions { get; set; }
        public virtual DbSet<EmailService> EmailServices { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceLog> ServiceLogs { get; set; }
    
        public virtual int DeleteSubscribedService(Nullable<int> clientServiceID, Nullable<int> emailSubscriptionID)
        {
            var clientServiceIDParameter = clientServiceID.HasValue ?
                new ObjectParameter("ClientServiceID", clientServiceID) :
                new ObjectParameter("ClientServiceID", typeof(int));
    
            var emailSubscriptionIDParameter = emailSubscriptionID.HasValue ?
                new ObjectParameter("EmailSubscriptionID", emailSubscriptionID) :
                new ObjectParameter("EmailSubscriptionID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteSubscribedService", clientServiceIDParameter, emailSubscriptionIDParameter);
        }
    
        public virtual ObjectResult<GetEMailNotificationMessageService_Result> GetEMailNotificationMessageService(Nullable<int> clientServiceID)
        {
            var clientServiceIDParameter = clientServiceID.HasValue ?
                new ObjectParameter("ClientServiceID", clientServiceID) :
                new ObjectParameter("ClientServiceID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetEMailNotificationMessageService_Result>("GetEMailNotificationMessageService", clientServiceIDParameter);
        }
    
        public virtual ObjectResult<GetLatestServiceLog_Result> GetLatestServiceLog(Nullable<int> clientServiceID)
        {
            var clientServiceIDParameter = clientServiceID.HasValue ?
                new ObjectParameter("ClientServiceID", clientServiceID) :
                new ObjectParameter("ClientServiceID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetLatestServiceLog_Result>("GetLatestServiceLog", clientServiceIDParameter);
        }
    
        public virtual ObjectResult<GetServiceLog_Result> GetServiceLog(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetServiceLog_Result>("GetServiceLog", idParameter);
        }
    
        public virtual ObjectResult<GetServicesForClientID_Result> GetServicesForClientID(Nullable<int> clientID)
        {
            var clientIDParameter = clientID.HasValue ?
                new ObjectParameter("ClientID", clientID) :
                new ObjectParameter("ClientID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetServicesForClientID_Result>("GetServicesForClientID", clientIDParameter);
        }
    
        public virtual ObjectResult<string> GetServiceUrl(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetServiceUrl", idParameter);
        }
    
        public virtual int InsertEmail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertEmail", emailParameter);
        }
    
        public virtual int InsertSubscribedService(Nullable<int> clientServiceID, Nullable<int> emailSubscriptionID)
        {
            var clientServiceIDParameter = clientServiceID.HasValue ?
                new ObjectParameter("ClientServiceID", clientServiceID) :
                new ObjectParameter("ClientServiceID", typeof(int));
    
            var emailSubscriptionIDParameter = emailSubscriptionID.HasValue ?
                new ObjectParameter("EmailSubscriptionID", emailSubscriptionID) :
                new ObjectParameter("EmailSubscriptionID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertSubscribedService", clientServiceIDParameter, emailSubscriptionIDParameter);
        }
    
        public virtual int UpdateInsertEmail(string email, Nullable<bool> isOn, ObjectParameter emailID)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var isOnParameter = isOn.HasValue ?
                new ObjectParameter("IsOn", isOn) :
                new ObjectParameter("IsOn", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateInsertEmail", emailParameter, isOnParameter, emailID);
        }
    }
}
