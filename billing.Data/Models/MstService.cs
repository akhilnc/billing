using System;
using System.Collections.Generic;

namespace billing.Data.Models
{
    public partial class MstService
    {
        public int Id { get; set; }
        public string UId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }

    }
}
