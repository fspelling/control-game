using ControlGame.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGame.Domain.Arguments.Base
{
    public class ResponseBase
    {
        public string Mensagem { get; set; }

        public ResponseBase()
        {
            Mensagem = Message.X_OPERACAO_REALIZADA_SUCESSO;
        }
    }
}
