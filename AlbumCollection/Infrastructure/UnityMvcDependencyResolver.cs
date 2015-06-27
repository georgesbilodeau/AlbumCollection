using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AlbumCollection.Services.Repo;
using Microsoft.Practices.Unity;

namespace AlbumCollection.Infrastructure {
    public class UnityMvcDependencyResolver : IDependencyResolver {
        private IUnityContainer container;

        public UnityMvcDependencyResolver(IUnityContainer container) {
            this.container = container;
            RegisterDependencies();
        }

        #region IDependencyResolver Members

        public object GetService(Type serviceType) {
            if (!this.container.IsRegistered<Type>())
                return null;

            return this.container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            if (!this.container.IsRegistered<Type>())
                return new object[] { };

            return this.container.ResolveAll(serviceType);
        }

        #endregion

        private void RegisterDependencies() {
            this.container.RegisterType<IAlbumRepo, AlbumRepo>(new TransientLifetimeManager());
        }

    }
}