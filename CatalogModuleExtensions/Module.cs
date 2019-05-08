using System;

using CatalogModuleExtensions.Models.Domain;
using CatalogModuleExtensions.Models.Web;
using CatalogModuleExtensions.Repositories;

using Microsoft.Practices.Unity;

using VirtoCommerce.CatalogModule.Data.Model;
using VirtoCommerce.CatalogModule.Data.Repositories;
using VirtoCommerce.Domain.Catalog.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;

namespace CatalogModuleExtensions
{
	public class Module : ModuleBase
	{
		private const string ConnectionStringName = "VirtoCommerce";
		private readonly IUnityContainer _container;

		public Module(IUnityContainer container)
		{
			_container = container;
		}

		public override void SetupDatabase()
		{
			// Modify database schema with EF migrations
			using (var context = new CatalogModuleExtensionsRepository(ConnectionStringName, _container.Resolve<AuditableInterceptor>()))
			{
				var initializer = new SetupDatabaseInitializer<CatalogModuleExtensionsRepository, Migrations.Configuration>();

				initializer.InitializeDatabase(context);
			}
		}

		public override void Initialize()
		{
			_container.RegisterInstance<Func<ICatalogRepository>>(
				() => new CatalogModuleExtensionsRepository(ConnectionStringName, _container.Resolve<AuditableInterceptor>())
			);

			base.Initialize();
		}

		public override void PostInitialize()
		{
			AbstractTypeFactory<Category>.OverrideType<Category, CategoryDomainExtension>();
			AbstractTypeFactory<CategoryEntity>.OverrideType<CategoryEntity, CategoryExtensionDataEntity>();

			AbstractTypeFactory<VirtoCommerce.CatalogModule.Web.Model.Category>.OverrideType<VirtoCommerce.CatalogModule.Web.Model.Category, CategoryWebExtension>();

			base.PostInitialize();
		}
	}
}
