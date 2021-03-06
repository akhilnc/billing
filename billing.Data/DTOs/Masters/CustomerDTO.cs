
using System;

namespace billing.Data.DTOs.Masters
{
   public  class CustomerDTO
    {

        public int Id { get; set; }
        public string UId { get; set; }
        public string? Name { get; set; }
        public long PhoneNumber { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public decimal VehicleKm { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
