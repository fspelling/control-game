using ControlGame.Domain.Resources;
using prmToolkit.NotificationPattern;

namespace ControlGame.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public string Endereco { get; private set; }

        protected Email() { }

        public Email(string endereco)
        {
            Endereco = endereco;

            (new AddNotifications<Email>(this)).IfNotEmail(p => p.Endereco, string.Format(Message.X_0_INVALIDO, "e-mail"));
        }
    }
}
