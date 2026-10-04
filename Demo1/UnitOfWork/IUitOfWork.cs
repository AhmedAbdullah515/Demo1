using Demo1.Models;
using Demo1.Repo.Implemintation;
using Demo1.Repo.Interfaces;

namespace Demo1.UnitOfWork
{
    public interface IUitOfWork
    {
        
          IVehicle VehicleRepo { get; }
          ISale SaleRepo { get; }
          void Save();
    }
}
