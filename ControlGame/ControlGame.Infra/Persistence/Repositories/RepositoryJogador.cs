using ControlGame.Domain.Entities;
using ControlGame.Domain.Interfaces.Repositories;
using ControlGame.Domain.Interfaces.Repositories.Base;
using ControlGame.Infra.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ControlGame.Infra.Persistence.Repositories
{
    public class RepositoryJogador : RepositoryBase<Jogador, Guid>, IRepositoryJogador
    {
        protected readonly ControlGameContext _context;

        public RepositoryJogador(ControlGameContext context) : base(context)
        {
            _context = context;
        }
    }
}
