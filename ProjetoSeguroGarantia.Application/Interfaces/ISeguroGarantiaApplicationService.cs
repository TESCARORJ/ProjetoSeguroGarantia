using ProjetoSeguroGarantia.Application.Commands;
using ProjetoSeguroGarantia.Application.DTOs;

namespace ProjetoSeguroGarantia.Application.Interfaces
{
    /// <summary>
    /// Contrato dos métodos de serviço da aplicação
    /// </summary>
    public interface ISeguroGarantiaApplicationService
    {
        Task<SeguroGarantiaDTO> Create(SeguroGarantiaCreateCommand command);
        Task<SeguroGarantiaDTO> Update(SeguroGarantiaUpdateCommand command);
        Task<SeguroGarantiaDTO> Delete(SeguroGarantiaDeleteCommand command);

        List<SeguroGarantiaDTO>? GetAll();
        SeguroGarantiaDTO? GetById(Guid id);
    }
}
