using System;
using System.Collections.Generic;
using System.Linq;
using ControlGame.Domain.Arguments.Base;
using ControlGame.Domain.Arguments.Jogo;
using ControlGame.Domain.Entities;
using ControlGame.Domain.Interfaces.Repositories;
using ControlGame.Domain.Interfaces.Services;
using ControlGame.Domain.Resources;
using prmToolkit.NotificationPattern;

namespace ControlGame.Domain.Services
{
    public class ServiceJogo : Notifiable, IServiceJogo
    {
        private readonly IRepositoryJogo _repository;

        protected ServiceJogo() { }

        public ServiceJogo(IRepositoryJogo repository)
        {
            _repository = repository;
        }

        public AdicionarJogoResponse Adicionar(AdicionarJogoRequest request)
        {
            if (request == null)
                AddNotification("AdicionarJogo", string.Format(Message.X_0_OBRIGATORIO, "request"));

            var jogo = new Jogo(request.Nome, request.Descricao, request.Produtora, request.Destribuidora, request.Genero, request.Site);

            AddNotifications(jogo);

            if (IsInvalid())
                return null;

            Jogo jogoAdd = _repository.Adicionar(jogo);

            return (AdicionarJogoResponse)jogoAdd;
        }

        public ResponseBase Alterar(AlterarJogoRequest request)
        {
            if (request == null)
                AddNotification("AlterarJogo", string.Format(Message.X_0_OBRIGATORIO, "request"));

            Jogo jogo = _repository.ObterPorId(request.Id);

            if (jogo == null)
                AddNotification("Id", string.Format(Message.X_DADOS_NAO_ENCONTRADOS, "request"));

            jogo.Alterar(request.Nome, request.Descricao, request.Produtora, request.Destribuidora, request.Genero, request.Site);

            if (IsInvalid())
                return null;

            jogo = _repository.Alterar(jogo);

            return (ResponseBase)jogo;
        }
        
        public ResponseBase Excluir(Guid id)
        {
            Jogo jogo = _repository.ObterPorId(id);

            if (jogo == null)
                AddNotification("Id", string.Format(Message.X_DADOS_NAO_ENCONTRADOS, "request"));

            if (IsInvalid())
                return null;

            jogo = _repository.Remover(jogo);

            return (ResponseBase)jogo;
        }

        public IEnumerable<JogoResponse> Listar()
        {
            return _repository.Listar().Select(jogo => (JogoResponse)jogo).ToList();
        }
    }
}
