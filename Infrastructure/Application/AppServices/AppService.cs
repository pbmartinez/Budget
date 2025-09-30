using Application.Dtos;
using Application.IAppServices;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;

namespace Infrastructure.Application.AppServices
{
    public class AppService<TDtoBase, TEntity, TKey> : IAppService<TDtoBase, TKey>
           where TDtoBase : DtoBase
           where TEntity : Entity
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TEntity, TKey> _repository;
        public AppService(IRepository<TEntity, TKey> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(TDtoBase item, CancellationToken cancellationToken = default)
        {
            await _repository.AddAsync(_mapper.Map<TEntity>(item), cancellationToken);
            return (await _repository.CommitChangesAsync()) > 0;
        }

        public TDtoBase Get(TKey id, List<string>? includes = null)
        {
            return _mapper.Map<TDtoBase>(_repository.Get(id, includes));
        }

        public async Task<List<TDtoBase>> GetAllAsync(List<string>? includes = null, Dictionary<string, bool>? order = null, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<List<TDtoBase>>(await _repository.GetAllAsync(includes, order, cancellationToken));
        }

        public async Task<TDtoBase> GetAsync(TKey id, List<string>? includes = null, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<TDtoBase>(await _repository.GetAsync(id, includes, cancellationToken));
        }

        public async Task<bool> RemoveAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = _repository.Get(id) ?? throw new Exception();
            await _repository.DeleteAsync(entity, cancellationToken);
            return (await _repository.CommitChangesAsync()) > 0;
        }

        public async Task<bool> UpdateAsync(TDtoBase item, CancellationToken cancellationToken = default)
        {
            await _repository.UpdateAsync(_mapper.Map<TEntity>(item), cancellationToken);
            return (await _repository.CommitChangesAsync()) > 0;
        }
    }
}
