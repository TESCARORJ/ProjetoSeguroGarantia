using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoSeguroGarantia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeguroGarantia.Infra.Data.Mappings
{
    public class SeguroGarantiaMap:IEntityTypeConfiguration<SeguroGarantia>
    {
        public void Configure(EntityTypeBuilder<SeguroGarantia> builder)
        {
            builder.ToTable("tbl_SeguraGarantia");

            builder.HasKey(x => x.Guid);

            builder.Property(x => x.Finalidade);
            builder.Property(x => x.Beneficiarios);
            builder.Property(x => x.TiposDeProcessos);
            builder.Property(x => x.Vantagens);
            builder.Property(x => x.Funcionamento);
            builder.Property(x => x.Exigencias);
            builder.Property(x => x.DataHoraCadastro);
        }
    }
}
