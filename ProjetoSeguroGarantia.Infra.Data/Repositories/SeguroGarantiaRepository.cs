using ProjetoSeguroGarantia.Domain.Entities;
using ProjetoSeguroGarantia.Domain.Interfaces.Repositories;
using ProjetoSeguroGarantia.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeguroGarantia.Infra.Data.Repositories
{
    public class SeguroGarantiaRepository : BaseRepository<SeguroGarantia, Guid>, ISeguroGarantiaRepository
    {
        private readonly DataContext? _dataContext;

        public SeguroGarantiaRepository(DataContext? dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

    }
}
