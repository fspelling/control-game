using ControlGame.Domain.Resources;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGame.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        public string PrimeiroNome { get; private set; }

        public string UltimoNome { get; private set; }

        protected Nome() { }

        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            (new AddNotifications<Nome>(this))
                .IfNullOrInvalidLength(p => p.PrimeiroNome, 3, 50, string.Format(Message.X_OBRIGATORIO_QUANTIDADE_RANGE, "primeiro nome", "3", "50"))
                .IfNullOrInvalidLength(p => p.UltimoNome, 3, 50, string.Format(Message.X_OBRIGATORIO_QUANTIDADE_RANGE, "ultimo nome", "3", "50"));
        }
    }
}
