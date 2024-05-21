using Microsoft.EntityFrameworkCore;
using ProjetoSeguroGarantia.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeguroGarantia.Infra.Data.Contexts
{
    public class DataContext:DbContext
    {
        /// <summary>
        /// Construtor para injeção de dependência
        /// </summary>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SeguroGarantiaMap());
        }
    }
}
