using ProjetoSeguroGarantia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeguroGarantia.Domain.Interfaces.Repositories
{
    public interface ISeguroGarantiaRepository : IBaseRepository<SeguroGarantia, Guid>
    {
    }
}
