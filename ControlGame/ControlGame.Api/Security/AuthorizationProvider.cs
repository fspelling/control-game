using ControlGame.Domain.Arguments.Jogador;
using ControlGame.Domain.Interfaces.Services;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Unity;

namespace ControlGame.Api.Security
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private readonly UnityContainer _container;

        public AuthorizationProvider(UnityContainer container)
        {
            _container = container;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                IServiceJogador serviceJogador = _container.Resolve<IServiceJogador>();

                AutenticarJogadorRequest request = new AutenticarJogadorRequest()
                {
                    Email = context.UserName,
                    Senha = context.Password
                };

                AutenticarJogadorResponse response = serviceJogador.Autenticar(request);

                if (serviceJogador.IsInvalid())
                {
                    if (response == null)
                    {
                        context.SetError("invalid_grant", "Preencha e-mail e senha validos");
                        return;
                    }
                }

                serviceJogador.ClearNotifications();

                if (response == null)
                {
                    context.SetError("invalid_grant", "Jogador nao encontrado");
                    return;
                }

                //Definindo clains
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Jogador", JsonConvert.SerializeObject(response)));

                var principal = new GenericPrincipal(identity, new string[] { });
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception e)
            {
                context.SetError("invalid_grant", e.Message);
                return;
            }
        }
    }
}