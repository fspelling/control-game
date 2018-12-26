using ControlGame.Domain.Entities;
using ControlGame.Domain.Interfaces.Repositories.Base;
using System;

namespace ControlGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador : IRepositoryBase<Jogador, Guid>
    {
    }
}
