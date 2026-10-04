using System.Reflection.Metadata.Ecma335;
using Demo1.App_Context;
using Demo1.Repo.Implemintation;
using Demo1.Repo.Interfaces;

namespace Demo1.UnitOfWork
{
    public class UnitWork : IUitOfWork
    {
        private readonly AppDBContext _context;
        public IVehicle VehicleRepo { get; }
        public ISale SaleRepo { get; }
        public UnitWork(AppDBContext context)
        {
            _context = context;
            VehicleRepo = new VehicleRepo(_context);
            SaleRepo=new SaleRepo(_context);
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        
    }
}
