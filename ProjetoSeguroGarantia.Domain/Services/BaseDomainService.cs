﻿using ProjetoSeguroGarantia.Domain.Interfaces.Repositories;
using ProjetoSeguroGarantia.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeguroGarantia.Domain.Services
{
    /// <summary>
    /// Classe abstrata para operações de serviço de dominio
    /// </summary>
    public abstract class BaseDomainService<TEntity, TKey>:IBaseDomainService<TEntity, TKey>
        where TEntity : class
    {
        private readonly IBaseRepository<TEntity, TKey> _baseRepository;

        protected BaseDomainService(IBaseRepository<TEntity, TKey> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async virtual Task Add(TEntity entity)
        {
            await _baseRepository.Add(entity);
        }

        public async virtual Task Update(TEntity entity)
        {
            await _baseRepository.Update(entity);
        }

        public async virtual Task Delete(TEntity entity)
        {
            await _baseRepository.Delete(entity);
        }

        public async virtual Task<List<TEntity>>? GetAll()
        {
            return await _baseRepository.GetAll();
        }

        public async virtual Task<TEntity>? GetById(TKey id)
        {
            return await _baseRepository.GetById(id);
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}
