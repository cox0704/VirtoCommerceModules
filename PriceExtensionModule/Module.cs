using Microsoft.Practices.Unity;
using PriceExtensionModule.Model;
using VirtoCommerce.PricingModule.Data.Model;
using VirtoCommerce.PricingModule.Data.Repositories;
using VirtoCommerce.Domain.Pricing.Model;
using VirtoCommerce.Domain.Pricing.Services;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;

namespace PriceExtensionModule
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
			base.SetupDatabase();

            using (var db = new PriceExtensionRepository(ConnectionStringName, _container.Resolve<AuditableInterceptor>()))
            {
                var initializer = new SetupDatabaseInitializer<PriceExtensionRepository, Migrations.Configuration>();
                initializer.InitializeDatabase(db);
            }
        }

        public override void Initialize()
        {
	        base.Initialize();

	        _container.RegisterType<IPricingRepository>(new InjectionFactory(c => new PriceExtensionRepository(ConnectionStringName, _container.Resolve<AuditableInterceptor>(),
		        new EntityPrimaryKeyGeneratorInterceptor())));

        }

        public override void PostInitialize()
        {
	        base.PostInitialize();
	        AbstractTypeFactory<Price>.RegisterType<PriceExtension>();
	        AbstractTypeFactory<Price>.OverrideType<Price, PriceExtension>().MapToType<PriceExtensionDataEntity>();
            AbstractTypeFactory<PriceEntity>.OverrideType<PriceEntity, PriceExtensionDataEntity>();
        }
        #endregion
    }
}
