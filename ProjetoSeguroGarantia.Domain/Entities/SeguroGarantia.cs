using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeguroGarantia.Domain.Entities
{
    public class SeguroGarantia
    {
        public Guid Guid { get; set; }
        public string? Finalidade { get; set; }
        public string? Beneficiarios { get; set; }
        public string? TiposDeProcessos { get; set; }
        public string? Vantagens { get; set; }
        public string? Funcionamento { get; set; }
        public string? Exigencias { get; set; }
        public DateTime? DataHoraCadastro { get; set; }

    }
}
