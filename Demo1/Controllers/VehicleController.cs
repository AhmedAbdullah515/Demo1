using AutoMapper;
using Demo1.DTOs.VehicleDTOs;
using Demo1.Models;
using Demo1.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUitOfWork uitOf;
        private readonly IMapper _mapper;
        public VehicleController(IUitOfWork U,IMapper Mapper)
        {
            _mapper = Mapper;
            uitOf = U;
        }
        [HttpPost("createvehicle")]
        public IActionResult Create(CreateVehicleDTO vehicleDTO)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleDTO);
            uitOf.VehicleRepo.Create(vehicle);
            uitOf.Save();
            var responsdto=_mapper.Map<VehicleDTO>(vehicle);
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.VehicleId }, responsdto);
        }
        [HttpGet("getbyId")]
        public IActionResult GetVehicleById(int id)
        {
            var vehicle = uitOf.VehicleRepo.GetById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<VehicleDTO>(vehicle);
            return Ok(result);
        }
        [HttpGet("availableVehicles")]
        public IActionResult GetAvailableVehicles()
        {
            var vehicles = uitOf.VehicleRepo.GetAvailableVehicles();
            var result = _mapper.Map<IEnumerable<VehicleDTO>>(vehicles);
            return Ok(result);

        }
        [HttpPut("updateVehicles")]
        public IActionResult UpdateVehicles(int id, UpdateVehicleDTO dto)
        {
            var vehicle = uitOf.VehicleRepo.GetById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, vehicle);
            uitOf.VehicleRepo.Update(vehicle);
            uitOf.Save();
            return NoContent();

        }
        [HttpDelete("delete")]
        public IActionResult DeleteVehicle(int id)
        {
            var vehicle=uitOf.VehicleRepo.GetById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            uitOf.VehicleRepo.Delete(id);
            uitOf.Save();
            return Ok("Delete Sucecss");
        }
    }
}
