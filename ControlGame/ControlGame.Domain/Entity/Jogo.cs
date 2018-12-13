using System;

namespace ControlGame.Domain.Entities
{
    public class Jogo
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Produtora { get; set; }

        public string Destribuidora { get; set; }

        public string Genero { get; set; }

        public string Site { get; set; }
    }
}
