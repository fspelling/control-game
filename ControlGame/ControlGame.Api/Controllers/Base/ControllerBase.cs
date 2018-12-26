using ControlGame.Domain.Interfaces.Services.Base;
using ControlGame.Infra.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ControlGame.Api.Controllers.Base
{
    public class ControllerBase : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private IServiceBase _serviceBase;

        public ControllerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HttpResponseMessage> ResponseAsync(object result, IServiceBase service)
        {
            _serviceBase = service;

            if (!_serviceBase.Notifications.Any())
            {
                try
                {
                    _unitOfWork.Commit();
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.Conflict, $"Houve um erro: {e.Message}");
                }
            }
            else
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new { errors = service.Notifications });
        }

        public async Task<HttpResponseMessage> ResponseExceptionAsync(Exception exception)
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { errors = exception.Message, exception = exception.ToString() });
        }

        protected override void Dispose(bool disposing)
        {
            if (_serviceBase != null)
                _serviceBase.Dispose();

            base.Dispose(disposing);
        }
    }
}