using System;
namespace billing.Data.Models
{
    public  class MstUserRole
    {

        public int Id { get; set; }
        public string UId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public  MstUser User { get; set; }
    }
}
