using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IRepository<TEntity, TKey> where TEntity : Entity
    {
        TEntity? Get(TKey id, List<string>? includes = null);
        Task<IQueryable<TEntity>> GetAllAsync(List<string>? includes = null, Dictionary<string, bool>? order = null, CancellationToken cancellationToken = default);
        Task<TEntity?> GetAsync(TKey id, List<string>? includes = null, CancellationToken cancellationToken = default);
        Task AddAsync(TEntity item, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity item, CancellationToken cancellationToken = default);

        Task<int> CommitChangesAsync();

    }
}
