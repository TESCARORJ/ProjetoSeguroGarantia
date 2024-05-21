using AutoMapper;
using MediatR;
using ProjetoSeguroGarantia.Infra.Storage.Collections;
using ProjetoSeguroGarantia.Infra.Storage.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjetoSeguroGarantia.Application.Handlers.Notifications.SeguroGarantiaNotification;

namespace ProjetoSeguroGarantia.Application.Handlers.Notifications
{
    /// <summary>
    /// Classe para escutar as notificações de seguroGarantias
    /// </summary>
    public class SeguroGarantiaNotificationHandler:INotificationHandler<SeguroGarantiaNotification>
    {
        //atributo
        private readonly SeguroGarantiaPersistence _seguroGarantiaPersistence;
        private readonly IMapper _mapper;

        public SeguroGarantiaNotificationHandler(SeguroGarantiaPersistence seguroGarantiaPersistence, IMapper mapper)
        {
            _seguroGarantiaPersistence = seguroGarantiaPersistence;
            _mapper = mapper;
        }

        public async Task Handle(SeguroGarantiaNotification notification, CancellationToken cancellationToken)
        {
            switch (notification.Action)
            {
                case SeguroGarantiaNotificationAction.SeguroGarantiaCriada:
                    _seguroGarantiaPersistence.Insert(_mapper.Map<SeguroGarantiaCollection>(notification.SeguroGarantiaDTO));
                    break;

                case SeguroGarantiaNotificationAction.SeguroGarantiaAlterada:
                    _seguroGarantiaPersistence.Update(_mapper.Map<SeguroGarantiaCollection>(notification.SeguroGarantiaDTO));
                    break;

                case SeguroGarantiaNotificationAction.SeguroGarantiaExcluida:
                    _seguroGarantiaPersistence.Delete(_mapper.Map<SeguroGarantiaCollection>(notification.SeguroGarantiaDTO));
                    break;
            }

            await Task.CompletedTask;
        }
    }
}
