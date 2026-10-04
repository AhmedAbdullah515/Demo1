using AutoMapper;
using Demo1.DTOs.SaleDTOs;
using Demo1.DTOs.VehicleDTOs;
using Demo1.Models;

namespace Demo1.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<Vehicle, CreateVehicleDTO>().ReverseMap();
            CreateMap<Vehicle, UpdateVehicleDTO>().ReverseMap();
            CreateMap<Sale, SaleDTO>().ReverseMap();


            CreateMap<Sale, CreateSaleDTO>().ReverseMap()
                .ForMember(a => a.SaleDate, a => a.MapFrom(a => DateTime.UtcNow));
            CreateMap<Sale, UpdateSaleDTO>().ReverseMap();



        }
    }
}
