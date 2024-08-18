using Microsoft.AspNetCore.Mvc;
using Vehicles.Models;
using Vehicles.Models.RequestModels;

namespace Vehicles.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VehiclesController : ControllerBase
    {
        private readonly VehiclesDbContext _Context;
        public VehiclesController(VehiclesDbContext context)
        {
            _Context = context;
        }
        [HttpGet]
        public IActionResult GetVehicle()
        {
            var vehicles = _Context.Vehicles.ToList();
            return Ok(vehicles);
        }
        [HttpGet]
        public IActionResult GetEVVehicle()
        {
            var vehicles = _Context.Vehicles.Where(x => x.Mode == "EV");
            return Ok(vehicles);
        }
        [HttpPost]
        public IActionResult CreateVehicle(List<CreateVehicleRequestModel> Request)
        {

            foreach (var VehicleDetail in Request)
                
            {
                var duplicate = _Context.Vehicles.Where(x => x.VehicleName == VehicleDetail.VehicleName 
                        && x.Model == VehicleDetail.Model 
                        && x.Manufacturer == VehicleDetail.Manufacturer ).ToList();
                if (duplicate.Count > 0)
                {
                    return Ok("Record already exists");
                }
                var vehicle = new Vehicle();
                //vehicle.VehicleId = Request.VehicleId;
                vehicle.VehicleName = VehicleDetail.VehicleName;
                vehicle.Model = VehicleDetail.Model;
                vehicle.Manufacturer = VehicleDetail.Manufacturer;
                vehicle.Mode = VehicleDetail.Mode;

                _Context.Vehicles.Add(vehicle);
            }
            
            _Context.SaveChanges();
            return Ok("Vehicle details added succesfully");
        }
    }
}
