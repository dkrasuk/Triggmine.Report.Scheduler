using System;
using System.Collections.Generic;

namespace Triggmine.Report.Scheduler.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string AuthId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Language { get; set; }
        public string TimeZone { get; set; }
        public string Email { get; set; }
        public string ShopUrl { get; set; }
        public int BillingLimit { get; set; }
        public string ApiKey { get; set; }
        public string CmsName { get; set; }
        public string EspProvider { get; set; }
        public string EspApiKey { get; set; }
        public string EspEmailFrom { get; set; }
        public string EspNameFrom { get; set; }
        public string ShopCurrency { get; set; }
        public string RegisterSource { get; set; }
        public string AssetId { get; set; }
        public string SourceId { get; set; }
        public string Position { get; set; }
        public string LogoUrl { get; set; }
        public string SupportEmail { get; set; }
        public string TemplateColor { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Guid? IndustryUid { get; set; }
        public string ShopAlias { get; set; }
        public bool IsLocked { get; set; }
        public bool IsAiEnabled { get; set; }
        public bool IsFbIntegrated { get; set; }
        public bool? NeedNotification { get; set; }
        public string CustomerUid { get; set; }
        public DateTime? LastSingInDate { get; set; }
    }
}
