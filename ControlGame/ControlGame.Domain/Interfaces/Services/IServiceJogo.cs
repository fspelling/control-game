using ControlGame.Domain.Arguments.Base;
using ControlGame.Domain.Arguments.Jogo;
using ControlGame.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace ControlGame.Domain.Interfaces.Services
{
    public interface IServiceJogo : IServiceBase
    {
        AdicionarJogoResponse Adicionar(AdicionarJogoRequest request);

        ResponseBase Excluir(Guid id);

        ResponseBase Alterar(AlterarJogoRequest request);

        IEnumerable<JogoResponse> Listar();
    }
}
