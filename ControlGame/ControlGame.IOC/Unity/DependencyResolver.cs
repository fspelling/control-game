using ControlGame.Domain.Interfaces.Repositories;
using ControlGame.Domain.Interfaces.Repositories.Base;
using ControlGame.Domain.Interfaces.Services;
using ControlGame.Domain.Services;
using ControlGame.Infra.Persistence;
using ControlGame.Infra.Persistence.Repositories;
using ControlGame.Infra.Persistence.Repositories.Base;
using ControlGame.Infra.Transaction;
using prmToolkit.NotificationPattern;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;

namespace ControlGame.IOC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<DbContext, ControlGameContext>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Domain
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceJogador, ServiceJogador>(new HierarchicalLifetimeManager());

            //Repository
            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
            container.RegisterType<IRepositoryJogador, RepositoryJogador>(new HierarchicalLifetimeManager());
        }
    }
}
