using Demo1.App_Context;
using Demo1.Models;
using Demo1.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Repo.Implemintation
{
    public class VehicleRepo : GenaricRepo<Vehicle>, IVehicle
    {
        public VehicleRepo(AppDBContext context) : base(context)
        {
        }

        public IEnumerable<Vehicle> GetAvailableVehicles()
        {
            return _context.Vehicles.Include(a=>a.Category).Where(a => a.Status == "Available").OrderByDescending(a=>a.Year).ThenBy(a=>a.Price).ToList();
        }

    }
}
