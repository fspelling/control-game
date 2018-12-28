using ControlGame.Domain.Enum;
using ControlGame.Domain.Resources;
using ControlGame.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using System;
using ControlGame.Domain.Extensions;
using ControlGame.Domain.Entity.Base;

namespace ControlGame.Domain.Entities
{
    public class Jogador : EntityBase
    {
        public Nome Nome { get; private set; }

        public Email Email { get; private set; }

        public string Senha { get; private set; }

        public EnumSituacaoJogador Status { get; private set; }

        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;
            Status = EnumSituacaoJogador.EmAnalise;

            NotificarSenha();
        }

        public Jogador(Email email, string senha, Nome nome)
        {
            Id = Guid.NewGuid();
            Email = email;
            Nome = nome;
            Senha = senha;
            Status = EnumSituacaoJogador.EmAnalise;

            NotificarSenha();
        }

        public void Alterar(Nome nome, Email email)
        {
            Nome = nome;
            Email = email;

            (new AddNotifications<Jogador>(this)).IfFalse(p => p.Status == EnumSituacaoJogador.Ativo, string.Format(Message.X_ALTERAR_INATIVO, "jogador"));

            AddNotifications(nome, email);
        }

        private void NotificarSenha()
        {
            (new AddNotifications<Jogador>(this)).IfNullOrInvalidLength(p => p.Senha, 6, 32, string.Format(Message.X_6_QUANTIDADE, "senha"));

            if(IsValid())
                Senha = Senha.ConvertToMD5();
        }

        public override string ToString()
        {
            return $"{Nome.PrimeiroNome} ${Nome.UltimoNome}";
        }
    }
}
