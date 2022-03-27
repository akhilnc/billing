
namespace billing.Data.DTOs.Dropdown
{
    public class CustomerDropdownDTO:DropdownDTO
    {
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public decimal VehicleKm { get; set; }
    }
}
