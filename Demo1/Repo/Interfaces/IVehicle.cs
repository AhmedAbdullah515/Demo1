using Demo1.Models;

namespace Demo1.Repo.Interfaces
{
    public interface IVehicle:IGenaricrepo<Vehicle>
    {
        public IEnumerable<Vehicle> GetAvailableVehicles();
    }
}
