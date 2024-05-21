using AutoMapper;
using MediatR;
using ProjetoSeguroGarantia.Application.Commands;
using ProjetoSeguroGarantia.Application.DTOs;
using ProjetoSeguroGarantia.Application.Interfaces;
using ProjetoSeguroGarantia.Infra.Storage.Persistence;

namespace ProjetoSeguroGarantia.Application.Services
{
    /// <summary>
    /// Implementação dos serviços de seguroGarantia da aplicação
    /// </summary>
    public class SeguroGarantiaApplicationService : ISeguroGarantiaApplicationService
    {
        //atributo
        private readonly SeguroGarantiaPersistence _seguroGarantiaPersistence;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SeguroGarantiaApplicationService(SeguroGarantiaPersistence seguroGarantiaPersistence, IMediator mediator, IMapper mapper)
        {
            _seguroGarantiaPersistence = seguroGarantiaPersistence;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<SeguroGarantiaDTO> Create(SeguroGarantiaCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<SeguroGarantiaDTO> Update(SeguroGarantiaUpdateCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<SeguroGarantiaDTO> Delete(SeguroGarantiaDeleteCommand command)
        {
            return await _mediator.Send(command);
        }

        public List<SeguroGarantiaDTO>? GetAll()
        {
            var result = _seguroGarantiaPersistence.FindAll().Result;
            return _mapper.Map<List<SeguroGarantiaDTO>>(result);
        }

        public SeguroGarantiaDTO? GetById(Guid id)
        {
            var result = _seguroGarantiaPersistence.Find(id).Result;
            return _mapper.Map<SeguroGarantiaDTO>(result);
        }
    }
}
