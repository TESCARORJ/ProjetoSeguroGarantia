using MediatR;
using ProjetoSeguroGarantia.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeguroGarantia.Application.Handlers.Notifications
{
    public class SeguroGarantiaNotification : INotification
    {
        public SeguroGarantiaDTO SeguroGarantiaDTO { get; set; } 
        public SeguroGarantiaNotificationAction Action { get; set; }

        public enum SeguroGarantiaNotificationAction
        {
            SeguroGarantiaCriada = 1,
            SeguroGarantiaAlterada = 2,
            SeguroGarantiaExcluida = 3
        }
    }
}
