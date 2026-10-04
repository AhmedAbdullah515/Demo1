using AutoMapper;
using Demo1.DTOs.SaleDTOs;
using Demo1.Models;
using Demo1.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IUitOfWork _unit;
        private readonly IMapper _mapper;
        public SaleController(IUitOfWork unit,IMapper mapper)
        {
            _unit=unit;
            _mapper=mapper;
        }
        [HttpPost("CreateSale")]
        public IActionResult Create(CreateSaleDTO dto)
        {
            var vehicle = _unit.VehicleRepo.GetById(dto.VehicleId);
            if (vehicle == null) { return NotFound(); }
            if (vehicle.Status != "Available")
            {
                return BadRequest();
            }
            var sale = _mapper.Map<Sale>(dto);
            _unit.SaleRepo.Create(sale);
            vehicle.Status = "Sold";
            _unit.VehicleRepo.Update(vehicle);
            _unit.Save();
            return Created();
        }
        [HttpGet("Allsales")]
        public IActionResult GetAll()
        {
            var sales= _unit.SaleRepo.GetAll();
            var result = _mapper.Map<IEnumerable<SaleDTO>>(sales);
            return Ok(result);
        }
    }
}
