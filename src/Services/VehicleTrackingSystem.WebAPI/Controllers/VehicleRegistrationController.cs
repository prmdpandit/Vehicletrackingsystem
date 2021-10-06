using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VehicleTrackingSystem.WebAPI.Entities;
using VehicleTrackingSystem.WebAPI.Repository;

namespace VehicleTrackingSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehicleRegistrationController : ControllerBase
    {
        private  IRepository<VehicleRegistration> vehicleRegistrationRepository;
        public VehicleRegistrationController(IRepository<VehicleRegistration> _vehicleRegistrationRepository)
        { vehicleRegistrationRepository = _vehicleRegistrationRepository; }

        [HttpGet]
        [Route("")]
        public IEnumerable<VehicleRegistration> GetAllRegistorVehicles() =>
            vehicleRegistrationRepository.GetAll();

        [HttpGet]
        [Route("{vehicleRegistrationId}")]
        public VehicleRegistration GetVehicalRegistrationById(Guid vehicleRegistrationId) => 
            vehicleRegistrationRepository.GetById(vehicleRegistrationId);

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public void AddVehicleRegistaration([FromBody] VehicleRegistration vehicleRegistration) => 
            vehicleRegistrationRepository.Insert(vehicleRegistration);

        [HttpDelete]
        [Route("{vehicleRegistrationId}")]
        [AllowAnonymous]
        public void DeleteBook(Guid vehicleRegistrationId) =>
            vehicleRegistrationRepository.Delete(vehicleRegistrationId);
    }
}
