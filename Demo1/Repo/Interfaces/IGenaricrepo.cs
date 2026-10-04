namespace Demo1.Repo.Interfaces
{
    public interface IGenaricrepo<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Create(T Entity);
        public void Update(T Entity);
        public void Delete(int Id);
        
    }
}
