using ControlGame.Domain.Entity.Base;
using ControlGame.Domain.Resources;
using prmToolkit.NotificationPattern;

namespace ControlGame.Domain.Entities
{
    public class Jogo : EntityBase
    {
        protected Jogo() { }

        public Jogo(string nome, string descricao, string produtora, string destribuidora, string genero, string site)
        {
            Nome = nome;
            Descricao = descricao;
            Produtora = produtora;
            Destribuidora = destribuidora;
            Genero = genero;
            Site = site;

            ValidarJogo();
        }

        public void Alterar(string nome, string descricao, string produtora, string destribuidora, string genero, string site)
        {
            Nome = nome;
            Descricao = descricao;
            Produtora = produtora;
            Destribuidora = destribuidora;
            Genero = genero;
            Site = site;

            ValidarJogo();
        }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public string Produtora { get; private set; }

        public string Destribuidora { get; private set; }

        public string Genero { get; private set; }

        public string Site { get; private set; }

        private void ValidarJogo()
        {
            (new AddNotifications<Jogo>(this))
                .IfNullOrInvalidLength(p => p.Nome, 1, 100, string.Format(Message.X_OBRIGATORIO_QUANTIDADE_RANGE, 1, 100))
                .IfNullOrInvalidLength(p => p.Nome, 1, 255, string.Format(Message.X_OBRIGATORIO_QUANTIDADE_RANGE, 1, 255))
                .IfNullOrInvalidLength(p => p.Genero, 1, 30, string.Format(Message.X_OBRIGATORIO_QUANTIDADE_RANGE, 1, 30));
        }
    }
}
