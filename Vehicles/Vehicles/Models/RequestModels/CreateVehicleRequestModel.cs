namespace Vehicles.Models.RequestModels
{
    public class CreateVehicleRequestModel
    {
        
        public string VehicleName { get; set; }
        public int Model { get; set; }
        public string Manufacturer { get; set; }
        public string Mode { get; set; }
    }
}
