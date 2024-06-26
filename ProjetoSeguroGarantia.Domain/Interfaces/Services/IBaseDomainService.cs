﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeguroGarantia.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface de serviço de domínio genérico
    /// </summary>
    /// <typeparam name="TEntity">Representa o tipo da entidade</typeparam>
    /// <typeparam name="TKey">Representa o tipo da chave</typeparam>
    public interface IBaseDomainService<TEntity, TKey>:IDisposable
        where TEntity : class
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);

        Task<List<TEntity>>? GetAll();
        Task<TEntity>? GetById(TKey id);
    }
}
