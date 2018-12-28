using ControlGame.Api.Controllers.Base;
using ControlGame.Domain.Arguments.Jogador;
using ControlGame.Domain.Arguments.Jogo;
using ControlGame.Domain.Interfaces.Services;
using ControlGame.Infra.Transaction;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ControlGame.Api.Controllers
{
    [RoutePrefix("api/jogo")]
    public class JogoController : ControllerBase
    {
        private readonly IServiceJogo _service;

        public JogoController(IServiceJogo service, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _service = service;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(AdicionarJogoRequest request)
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

        [Route("Alterar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Alterar(AlterarJogoRequest request)
        {
            try
            {
                var response = _service.Alterar(request);
                return await ResponseAsync(response, _service);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        [Authorize]
        [Route("Alterar")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Excluir(Guid request)
        {
            try
            {
                var response = _service.Excluir(request);
                return await ResponseAsync(response, _service);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

        [Route("Listar")]
        [HttpGet ]
        public async Task<HttpResponseMessage> Listar()
        {
            try
            {
                var response = _service.Listar();
                return await ResponseAsync(response, _service);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }
    }
}