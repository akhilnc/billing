
using System;

namespace billing.Data.Models
{
    public class CompanySettings
    {
        public int Id { get; set; }
        public string UId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Logo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public string? WhatsAppNumber { get; set; }
        public string? FaceBookId { get; set; }
        public string? InstagramId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

    }
}
