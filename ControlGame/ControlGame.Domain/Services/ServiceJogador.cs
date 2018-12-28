using System;
using System.Collections.Generic;
using System.Linq;
using ControlGame.Domain.Arguments.Base;
using ControlGame.Domain.Arguments.Jogador;
using ControlGame.Domain.Entities;
using ControlGame.Domain.Interfaces.Repositories;
using ControlGame.Domain.Interfaces.Services;
using ControlGame.Domain.Resources;
using ControlGame.Domain.ValueObjects;
using prmToolkit.NotificationPattern;

namespace ControlGame.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repository;

        protected ServiceJogador() { }

        public ServiceJogador(IRepositoryJogador repository)
        {
            _repository = repository;
        }

        public AdicionarJogadorResponse Adicionar(AdicionarJogadorRequest request)
        {
            if (request == null)
                AddNotification("AdicionarJogador", string.Format(Message.X_0_OBRIGATORIO, "request"));

            Email email = new Email(request.Email);
            Nome nome = new Nome(request.PrimeiroNome, request.UltimoNome);

            Jogador jogador = new Jogador(email, request.Senha, nome);

            AddNotifications(nome, email);

            if (_repository.Existe(p => p.Email.Endereco == email.Endereco))
                AddNotification("Email", string.Format(Message.X_OPERACAO_DUPLICIDADE, "email"));

            if (jogador.IsInvalid())
                return null;

            Jogador jogadorAdd = _repository.Adicionar(jogador);

            return (AdicionarJogadorResponse)jogadorAdd;
        }

        public AlterarJogadorResponse Alterar(AlterarJogadorRequest request)
        {
            if (request == null)
                AddNotification("AlterarJogador", string.Format(Message.X_0_OBRIGATORIO, "request"));

            Jogador jogadorBuscado = _repository.ObterPorId(request.Id);

            if (jogadorBuscado == null)
                AddNotification("Id", Message.X_DADOS_NAO_ENCONTRADOS);

            Email email = new Email(request.Email);
            Nome nome = new Nome(request.PrimeiroNome, request.UltimoNome);

            jogadorBuscado.Alterar(nome, email);

            AddNotifications(jogadorBuscado);

            if (jogadorBuscado.IsInvalid())
                return null;

            _repository.Alterar(jogadorBuscado);

            return (AlterarJogadorResponse)jogadorBuscado;
        }

        public AutenticarJogadorResponse Autenticar(AutenticarJogadorRequest request)
        {
            if (request == null)
                AddNotification("AutenticarJogador", string.Format(Message.X_0_OBRIGATORIO, "request"));

            Email email = new Email(request.Email);
            Jogador jogador = new Jogador(email, request.Senha);

            AddNotifications(jogador, email);

            if (jogador.IsInvalid())
                return null;

            Jogador jogadorAuth = _repository.ObterPor(p => p.Email.Endereco == jogador.Email.Endereco, p => p.Senha == jogador.Senha);

            return (AutenticarJogadorResponse)jogadorAuth;
        }

        public ResponseBase Excluir(Guid id)
        {
            Jogador jogador = _repository.ObterPorId(id);

            if (jogador == null)
            {
                AddNotification("Id", Message.X_DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repository.Remover(jogador);

            return new ResponseBase();
        }

        public IEnumerable<JogadorResponse> Listar()
        {
            return _repository.Listar().Select(jogador => (JogadorResponse)jogador).ToList();
        }
    }
}
