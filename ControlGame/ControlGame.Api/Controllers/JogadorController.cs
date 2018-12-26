using ControlGame.Api.Controllers.Base;
using ControlGame.Domain.Arguments.Jogador;
using ControlGame.Domain.Interfaces.Services;
using ControlGame.Infra.Transaction;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ControlGame.Api.Controllers
{
    [RoutePrefix("api/jogador")]
    public class JogadorController : ControllerBase
    {
        private readonly IServiceJogador _service;

        public JogadorController(IServiceJogador service, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _service = service;
        }

        [Route("Adicionat")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(AdicionarJogadorRequest request)
        {
            try
            {
                var response = _service.Adicionar(request);
                return await ResponseAsync(response, _service);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }
    }
}