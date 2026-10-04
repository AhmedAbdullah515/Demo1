using Demo1.Models;

namespace Demo1.Repo.Interfaces
{
    public interface ISale:IGenaricrepo<Sale>
    {
        public IEnumerable<Sale> Getallsalewithetails();
    }
}
