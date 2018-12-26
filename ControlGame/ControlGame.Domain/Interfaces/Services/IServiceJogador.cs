using ControlGame.Domain.Arguments.Base;
using ControlGame.Domain.Arguments.Jogador;
using ControlGame.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace ControlGame.Domain.Interfaces.Services
{
    public interface IServiceJogador : IServiceBase
    {
        AutenticarJogadorResponse Autenticar(AutenticarJogadorRequest request);

        AdicionarJogadorResponse Adicionar(AdicionarJogadorRequest request);

        AlterarJogadorResponse Alterar(AlterarJogadorRequest request);

        IEnumerable<JogadorResponse> Listar();

        ResponseBase Excluir(Guid id);
    }
}
