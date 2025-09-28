using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Repositories
{
    internal class Repository<TEntity> : IRepository<TEntity, Guid> where TEntity : Entity
    {
        private AppDbContext UnitOfWork { get; set; }

        public Repository(AppDbContext dbContext)
        {
            UnitOfWork = dbContext;
        }

        public TEntity? Get(Guid id, List<string>? includes)
        {
            return UnitOfWork.Set<TEntity>().FirstOrDefault(e => e.Id == id);
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(List<string>? includes, Dictionary<string, bool>? order, CancellationToken cancellationToken)
        {
            return await Task.FromResult(UnitOfWork.Set<TEntity>());
        }

        public Task<TEntity?> GetAsync(Guid id, List<string>? includes = default, CancellationToken cancellationToken = default)
        {
            return UnitOfWork.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public async Task AddAsync(TEntity item, CancellationToken cancellationToken)
        {
            await UnitOfWork.Set<TEntity>().AddAsync(item, cancellationToken);
        }

        public async Task UpdateAsync(TEntity item, CancellationToken cancellationToken)
        {
            var itemToUpdate = await GetAsync(item.Id, cancellationToken: cancellationToken) ?? throw new ArgumentException("Item to update must be valid and present in database");
            UnitOfWork.Entry(itemToUpdate).CurrentValues.SetValues(item);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(TEntity item, CancellationToken cancellationToken)
        {
            UnitOfWork.Set<TEntity>().Remove(item);
            await Task.CompletedTask;
        }

        public async Task<int> CommitChangesAsync()
        {
            return await UnitOfWork.SaveChangesAsync();
        }

    }
}
