using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;

namespace ControlGame.IOC.Unity
{
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentException("container");

            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (Exception e)
            {
                return new List<object>();
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (Exception e)
            {
                return new List<object>();
            }
        }
    }
}
