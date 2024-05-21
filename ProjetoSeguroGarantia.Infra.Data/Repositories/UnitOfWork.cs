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
    /// Implementação da unidade de trabalho dos repositórios
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext? _dataContext;

        public UnitOfWork(DataContext? dataContext)
            => _dataContext = dataContext;

        public ISeguroGarantiaRepository? SeguroGarantiaRepository => new SeguroGarantiaRepository(_dataContext);       

        public async Task SaveChanges()
        {
            await _dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
