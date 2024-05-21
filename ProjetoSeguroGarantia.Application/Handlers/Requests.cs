using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using ProjetoSeguroGarantia.Application.Commands;
using ProjetoSeguroGarantia.Application.DTOs;
using ProjetoSeguroGarantia.Application.Handlers.Notifications;
using ProjetoSeguroGarantia.Domain.Entities;
using ProjetoSeguroGarantia.Domain.Interfaces.Services;
using ProjetoSeguroGarantia.Infra.Messages.Models;
using ProjetoSeguroGarantia.Infra.Messages.Producers;
using System.Xml;
using static ProjetoSeguroGarantia.Application.Handlers.Notifications.SeguroGarantiaNotification;

namespace ProjetoSeguroGarantia.Application.Handlers
{
    /// <summary>
    /// Classe para receber as requisições COMMANDS (CREATE, UPDATE e DELETE)
    /// </summary>
    public class SeguroGarantiaRequestHandler:
        IRequestHandler<SeguroGarantiaCreateCommand, SeguroGarantiaDTO>,
        IRequestHandler<SeguroGarantiaUpdateCommand, SeguroGarantiaDTO>,
        IRequestHandler<SeguroGarantiaDeleteCommand, SeguroGarantiaDTO>
    {
        //atributo
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ISeguroGarantiaDomainService _seguroGarantiaDomainService;
        //private readonly MessageProducer _messageProducer;

        //construtor para injeção de dependência
        public SeguroGarantiaRequestHandler(
            IMediator mediator, IMapper mapper
            , ISeguroGarantiaDomainService seguroGarantiaDomainService
            //, MessageProducer messageProducer
            )
        {
            _mediator = mediator;
            _mapper = mapper;
            _seguroGarantiaDomainService = seguroGarantiaDomainService;
            //_messageProducer = messageProducer;
        }

        public async Task<SeguroGarantiaDTO> Handle(SeguroGarantiaCreateCommand request, CancellationToken cancellationToken)
        {
            //Gravar os dados no domínio
            var seguroGarantia = _mapper.Map<SeguroGarantia>(request);
            await _seguroGarantiaDomainService.Add(seguroGarantia);

            //Gerar uma notificação para que os dados
            //sejam replicados em um banco de consulta
            var seguroGarantiaDTO = _mapper.Map<SeguroGarantiaDTO>(seguroGarantia);
            var seguroGarantiaNotification = new SeguroGarantiaNotification
            {
                SeguroGarantiaDTO = seguroGarantiaDTO,
                Action = SeguroGarantiaNotificationAction.SeguroGarantiaCriada
            };

            await _mediator.Publish(seguroGarantiaNotification);

            


            //enviar mensagem para a fila
            //_messageProducer.SendMessage(new EmailMessageModel
            //{
            //    To = "thiago.tescaro@outlook.com",
            //    Subject = $"Novo Seguro Garantia criado com sucesso em {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}",
            //    Body = JsonConvert.SerializeObject(seguroGarantiaDTO, Newtonsoft.Json.Formatting.Indented)
            //}); ;

            return seguroGarantiaDTO;
        }

        public async Task<SeguroGarantiaDTO> Handle(SeguroGarantiaUpdateCommand request, CancellationToken cancellationToken)
        {
            //Atualizar os dados no domínio
            var seguroGarantia = _mapper.Map<SeguroGarantia>(request);
            await _seguroGarantiaDomainService.Update(seguroGarantia);

            //Gerar uma notificação para que os dados
            //sejam replicados em um banco de consulta
            var seguroGarantiaDTO = _mapper.Map<SeguroGarantiaDTO>(seguroGarantia);
            var seguroGarantiaNotification = new SeguroGarantiaNotification
            {
                SeguroGarantiaDTO = seguroGarantiaDTO,
                Action = SeguroGarantiaNotificationAction.SeguroGarantiaAlterada
            };

            await _mediator.Publish(seguroGarantiaNotification);
            return seguroGarantiaDTO;
        }

        public async Task<SeguroGarantiaDTO> Handle(SeguroGarantiaDeleteCommand request, CancellationToken cancellationToken)
        {
            //Excluir os dados no domínio
            var seguroGarantia = await _seguroGarantiaDomainService.GetById(request.Guid.Value);
            await _seguroGarantiaDomainService.Delete(seguroGarantia);

            //Gerar uma notificação para que os dados
            //sejam replicados em um banco de consulta
            var seguroGarantiaDTO = _mapper.Map<SeguroGarantiaDTO>(seguroGarantia);
            var seguroGarantiaNotification = new SeguroGarantiaNotification
            {
                SeguroGarantiaDTO = seguroGarantiaDTO,
                Action = SeguroGarantiaNotificationAction.SeguroGarantiaExcluida
            };

            await _mediator.Publish(seguroGarantiaNotification);
            return seguroGarantiaDTO;
        }
    }
}
