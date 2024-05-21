using MediatR;
using ProjetoSeguroGarantia.Application.DTOs;

namespace ProjetoSeguroGarantia.Application.Commands
{
    public class SeguroGarantiaDeleteCommand : IRequest<SeguroGarantiaDTO>
    {
        public Guid? Guid { get; set; }

    }
}
