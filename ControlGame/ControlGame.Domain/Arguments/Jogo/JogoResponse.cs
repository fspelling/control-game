using System;
using ControlGame.Domain.Entities;

namespace ControlGame.Domain.Arguments.Jogo
{
    public class JogoResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Produtora { get; set; }

        public string Destribuidora { get; set; }

        public string Genero { get; set; }

        public string Site { get; set; }

        public static explicit operator JogoResponse(Entities.Jogo jogo)
        {
            return new JogoResponse()
            {
                Id = jogo.Id,
                Descricao = jogo.Descricao,
                Destribuidora = jogo.Destribuidora,
                Genero = jogo.Genero,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Site = jogo.Site
            };
        }
    }
}
