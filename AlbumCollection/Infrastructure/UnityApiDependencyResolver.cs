using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

namespace AlbumCollection.Infrastructure {
    public class UnityApiDependencyResolver : IDependencyResolver {
        private IUnityContainer container;

        public UnityApiDependencyResolver(IUnityContainer container) {
            this.container = container;
        }

        #region IDependencyResolver Members

        public IDependencyScope BeginScope() {
            var childCtn = this.container.CreateChildContainer();
            return new UnityApiDependencyResolver(childCtn);
        }

        #endregion

        #region IDependencyScope Members

        public object GetService(Type serviceType) {
            if (!this.container.IsRegistered(serviceType))
                return null;

            return this.container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            if (!this.container.IsRegistered<Type>())
                return new object[] { };

            return this.container.ResolveAll(serviceType);
        }

        #endregion

        #region IDisposable Members

        public void Dispose() {
            this.container.Dispose();
        }

        #endregion

    }
}