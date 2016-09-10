using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using SportsStore.DAL;

namespace SportsStore.Infrastructre.DI
{
    public class CustomResolver : IDependencyResolver, IDependencyScope
    {
        public void Dispose()
        {
            //do nothing
        }

        public object GetService(Type serviceType)
        {
            return serviceType == typeof(IRepository) ? new Repository() : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}