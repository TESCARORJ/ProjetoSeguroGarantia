using ProjetoSeguroGarantia.Domain.Entities;
using ProjetoSeguroGarantia.Domain.Interfaces.Repositories;
using ProjetoSeguroGarantia.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeguroGarantia.Domain.Services
{
    public class SeguroGarantiaDomainService : BaseDomainService<SeguroGarantia, Guid>, ISeguroGarantiaDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeguroGarantiaDomainService(IUnitOfWork unitOfWork) : base(unitOfWork.SeguroGarantiaRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task Add(SeguroGarantia seguroGarantia)
        {
            _unitOfWork.SeguroGarantiaRepository?.Add(seguroGarantia);
            await _unitOfWork.SaveChanges();
        }

        public async override Task Update(SeguroGarantia seguroGarantia)
        {
            _unitOfWork.SeguroGarantiaRepository?.Update(seguroGarantia);
            await _unitOfWork.SaveChanges();
        }

        public async override Task Delete(SeguroGarantia seguroGarantia)
        {
            _unitOfWork.SeguroGarantiaRepository?.Delete(seguroGarantia);
            await _unitOfWork.SaveChanges();
        }


    }
}
