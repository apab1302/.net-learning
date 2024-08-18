namespace Vehicles.Models.RequestModels
{
    public class CreateVehicleRequestModel
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public int Model { get; set; }
        public string Manufacturer { get; set; }
        public string Mode { get; set; }
    }
}
