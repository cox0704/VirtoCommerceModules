using System;
using AddressExtensionModule;
using AddressExtensionModule.Model;
using Microsoft.Practices.Unity;

using VirtoCommerce.CustomerModule.Data.Model;
using VirtoCommerce.CustomerModule.Data.Repositories;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.Domain.Customer.Services;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;

namespace AddressExtensionModule
{
    public class Module : ModuleBase
    {
        private const string ConnectionStringName = "VirtoCommerce";
        private readonly IUnityContainer _container;

        public Module(IUnityContainer container)
        {
            _container = container;
        }
        #region IModule Members

        public override void SetupDatabase()
        {
            using (var db = new AddressExtensionRepository(ConnectionStringName, _container.Resolve<AuditableInterceptor>()))
            {
                var initializer = new SetupDatabaseInitializer<AddressExtensionRepository, Migrations.Configuration>();
                initializer.InitializeDatabase(db);
            }
        }

        public override void Initialize()
        {
	        _container.RegisterType<MemberRepositoryBase>(new InjectionFactory(c => new AddressExtensionRepository(ConnectionStringName, _container.Resolve<AuditableInterceptor>(),
		        new EntityPrimaryKeyGeneratorInterceptor())));

            base.Initialize();
        }

        public override void PostInitialize()
        {
	        AbstractTypeFactory<Address>.OverrideType<Address, AddressExtension>();
	        AbstractTypeFactory<AddressDataEntity>.OverrideType<AddressDataEntity, AddressExtensionDataEntity>();
            base.PostInitialize();
        }
        #endregion
    }
}
