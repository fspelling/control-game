using ControlGame.Domain.Arguments.Jogador;
using ControlGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGame.Domain.Interfaces.Services
{
    public interface IServiceJogador
    {
        AutenticarJogadorResponse Autenticar(AutenticarJogadorRequest request);

        AdicionarJogadorResponse Adicionar(AdicionarJogadorRequest request);

        AlterarJogadorResponse Alterar(AlterarJogadorRequest request);

        IEnumerable<JogadorResponse> Listar();
    }
}
