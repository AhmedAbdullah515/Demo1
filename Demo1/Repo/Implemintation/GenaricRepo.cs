using Demo1.App_Context;
using Demo1.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Repo.Implemintation
{
    public class GenaricRepo<T>:IGenaricrepo<T> where T : class
    {
        protected readonly AppDBContext _context;
        DbSet<T> _dbSet;
        public GenaricRepo(AppDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Create(T Entity)
        {
            _dbSet.Add(Entity);
        }
        public void Update(T Entity)
        {
            _dbSet.Update(Entity);
        }
        public void Delete(int Id)
        {
            var i = _dbSet.Find(Id);
            if (i != null) { _dbSet.Remove(i); }
        }
    }

   
}
