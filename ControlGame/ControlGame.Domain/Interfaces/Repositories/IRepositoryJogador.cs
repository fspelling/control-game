using ControlGame.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ControlGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        Jogador Autenticar(string email, string senha);

        Jogador Adicionar(Jogador request);

        IEnumerable<Jogador> Listar();

        void Alterar(Jogador request);

        Jogador ObterPorId(Guid id);
    }
}
