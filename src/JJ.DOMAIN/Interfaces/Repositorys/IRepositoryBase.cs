namespace JJ.DOMAIN.Interfaces.Repositorys
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<(IEnumerable<TEntity> data, int TotalCount)> GetAllPaginatedAsync(int pageNumber, int pageSize);
        void Delete(TEntity obj);
        Task<int> SaveChangesAsync();
    }
}