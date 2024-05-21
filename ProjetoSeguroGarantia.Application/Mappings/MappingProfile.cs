using AutoMapper;
using ProjetoSeguroGarantia.Application.Commands;
using ProjetoSeguroGarantia.Application.DTOs;
using ProjetoSeguroGarantia.Domain.Entities;
using ProjetoSeguroGarantia.Infra.Storage.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeguroGarantia.Application.Mappings
{
    /// <summary>
    /// Classe para mapeamento de/para do automapper
    /// </summary>
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //SeguroGarantiaCreateCommand > SeguroGarantia
            CreateMap<SeguroGarantiaCreateCommand, SeguroGarantia>()
                .AfterMap((src, dest) => {
                    dest.Guid = Guid.NewGuid();
                    dest.DataHoraCadastro = DateTime.Now;
                });

            //SeguroGarantiaUpdateCommand > SeguroGarantia
            CreateMap<SeguroGarantiaUpdateCommand, SeguroGarantia>();

            //SeguroGarantia > SeguroGarantiaCollection
            CreateMap<SeguroGarantia, SeguroGarantiaCollection>()
                .AfterMap((src, dest) => {
                    dest.DataHoraCadastro = DateTime.Now;
                });

            //SeguroGarantia > SeguroGarantiaDTO
            CreateMap<SeguroGarantia, SeguroGarantiaDTO>();           

            //SeguroGarantiaCollection > SeguroGarantiaDTO
            CreateMap<SeguroGarantiaCollection, SeguroGarantiaDTO>().ReverseMap();
        }
    }
}
