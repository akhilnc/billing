using System;

namespace billing.Data.Models
{
    public partial class MstService:MasterBase
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

    }
}
