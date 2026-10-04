using Demo1.App_Context;
using Demo1.Models;
using Demo1.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Repo.Implemintation
{
    public class SaleRepo : GenaricRepo<Sale>, ISale
    {
        public SaleRepo(AppDBContext context) : base(context)
        {
        }
        public IEnumerable<Sale> Getallsalewithetails()
        {
            return _context.Sales.Include(a => a.Vehicle).Include(a => a.Customer).Include(a => a.Employee).OrderByDescending(a => a.SaleDate).ToList();
        }
    }

}
