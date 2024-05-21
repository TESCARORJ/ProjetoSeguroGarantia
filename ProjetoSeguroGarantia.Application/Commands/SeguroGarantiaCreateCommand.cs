using MediatR;
using ProjetoSeguroGarantia.Application.DTOs;

namespace ProjetoSeguroGarantia.Application.Commands
{
    public class SeguroGarantiaCreateCommand : IRequest<SeguroGarantiaDTO>
    {
        public string? Finalidade { get; set; }
        public string? Beneficiarios { get; set; }
        public string? TiposDeProcessos { get; set; }
        public string? Vantagens { get; set; }
        public string? Funcionamento { get; set; }
        public string? Exigencias { get; set; }
    }
}
