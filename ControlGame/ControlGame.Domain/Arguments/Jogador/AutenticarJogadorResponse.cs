using ControlGame.Domain.Interfaces.Arguments;

namespace ControlGame.Domain.Arguments.Jogador
{
    public class AutenticarJogadorResponse: IResponse
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }

        public static explicit operator AutenticarJogadorResponse(Entities.Jogador jogador)
        {
            return new AutenticarJogadorResponse()
            {
                Email = jogador.Email.Endereco,
                Nome = jogador.Nome.PrimeiroNome,
                Status = (int)jogador.Status
            };
        }
    }
}
