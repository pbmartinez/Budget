using Application.Dtos;
using Domain.Entities;

namespace Application.IAppServices
{
    public interface IAppService<TEntityDto, TEntity, TKey> 
        where TEntityDto : DtoBase
        where TEntity : Entity
    {
        TEntityDto Get(TKey id, List<string>? includes = null);
        Task<bool> AddAsync(TEntityDto item, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(TEntityDto item, CancellationToken cancellationToken = default);
        Task<TEntityDto> GetAsync(TKey id, List<string>? includes = null, CancellationToken cancellationToken = default);
        Task<List<TEntityDto>> GetAllAsync(List<string>? includes = null, Dictionary<string, bool>? order = null, CancellationToken cancellationToken = default);
        Task<bool> RemoveAsync(TKey id, CancellationToken cancellationToken = default);
    }
}
