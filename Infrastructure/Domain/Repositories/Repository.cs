using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Repositories
{
    internal class Repository<TEntity> : IRepository<TEntity, Guid> where TEntity : Entity
    {
        private DbContext DbContext { get; set; }

        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public TEntity? Get(Guid id, List<string>? includes)
        {
            return DbContext.Set<TEntity>().FirstOrDefault(e => e.Id == id);
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(List<string>? includes, Dictionary<string, bool>? order, CancellationToken cancellationToken)
        {
            return await Task.FromResult(DbContext.Set<TEntity>());
        }

        public Task<TEntity?> GetAsync(Guid id, List<string>? includes = default, CancellationToken cancellationToken = default)
        {
            return DbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public async Task AddAsync(TEntity item, CancellationToken cancellationToken)
        {
            await DbContext.Set<TEntity>().AddAsync(item, cancellationToken);
        }

        public async Task UpdateAsync(TEntity item, CancellationToken cancellationToken)
        {
            var itemToUpdate = await GetAsync(item.Id, cancellationToken: cancellationToken) ?? throw new ArgumentException("Item to update must be valid and present in database");
            DbContext.Entry(itemToUpdate).CurrentValues.SetValues(item);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(TEntity item, CancellationToken cancellationToken)
        {
            DbContext.Set<TEntity>().Remove(item);
            await Task.CompletedTask;
        }

    }
}
