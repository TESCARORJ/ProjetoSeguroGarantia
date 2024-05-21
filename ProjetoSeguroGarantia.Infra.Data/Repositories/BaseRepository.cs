using Microsoft.EntityFrameworkCore;
using ProjetoSeguroGarantia.Domain.Interfaces.Repositories;
using ProjetoSeguroGarantia.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeguroGarantia.Infra.Data.Repositories
{
    /// <summary>
    /// Classe abstrata para implementar os métodos base do repositório
    /// </summary>
    public abstract class BaseRepository<TEntity, TKey>:IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        private readonly DataContext _dataContext;

        protected BaseRepository(DataContext dataContext) => _dataContext = dataContext;

        public async virtual Task Add(TEntity entity)
            => await _dataContext.AddAsync(entity);

        public async virtual Task Update(TEntity entity)
            => _dataContext.Update(entity);

        public async virtual Task Delete(TEntity entity)
            => _dataContext.Remove(entity);

        public async virtual Task<List<TEntity>>? GetAll()
            => await _dataContext.Set<TEntity>().ToListAsync();

        public async virtual Task<TEntity>? GetById(TKey id)
            => await _dataContext.Set<TEntity>().FindAsync(id);

        public void Dispose() => _dataContext.Dispose();
    }
}
