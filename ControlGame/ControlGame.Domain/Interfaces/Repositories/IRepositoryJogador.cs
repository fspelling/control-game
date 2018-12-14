using ControlGame.Domain.Arguments.Jogador;
using ControlGame.Domain.Entities;
using System;

namespace ControlGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        Jogador Autenticar(string email, string senha);

        Jogador Adicionar(Jogador request);
    }
}
