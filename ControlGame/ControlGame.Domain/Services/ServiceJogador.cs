using ControlGame.Domain.Arguments.Jogador;
using ControlGame.Domain.Entities;
using ControlGame.Domain.Interfaces.Repositories;
using ControlGame.Domain.Interfaces.Services;
using ControlGame.Domain.Resources;
using ControlGame.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using System;

namespace ControlGame.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repository;

        public ServiceJogador(IRepositoryJogador repository)
        {
            _repository = repository;
        }

        public AdicionarJogadorResponse Adicionar(AdicionarJogadorRequest request)
        {
            Email email = new Email(request.Email);
            Nome nome = new Nome(request.PrimeiroNome, request.UltimoNome);

            Jogador jogador = new Jogador(email, request.Senha, nome);

            AddNotifications(jogador);

            if (jogador.IsInvalid())
                return null;

            Jogador jogadorAdd = _repository.Adicionar(jogador);

            return new AdicionarJogadorResponse() { Id = jogadorAdd.Id, Mensagem = "Criacao realizada com sucesso" };
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

            Jogador jogadorAuth = _repository.Autenticar(jogador.Email.Endereco, jogador.Senha);

            return new AutenticarJogadorResponse() { Email = jogadorAuth.Email.Endereco, Nome = jogadorAuth.Nome.PrimeiroNome, Status = (int)jogadorAuth.Status };
        }
    }
}
