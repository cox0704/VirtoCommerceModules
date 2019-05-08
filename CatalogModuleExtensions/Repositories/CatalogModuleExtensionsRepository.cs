using System.Data.Entity;
using System.Linq;

using CatalogModuleExtensions.Models.Domain;

using VirtoCommerce.CatalogModule.Data.Repositories;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;

namespace CatalogModuleExtensions.Repositories
{
	public class CatalogModuleExtensionsRepository : CatalogRepositoryImpl
	{
		public IQueryable<CategoryExtensionDataEntity> CatalogExtension => GetAsQueryable<CategoryExtensionDataEntity>();

		public CatalogModuleExtensionsRepository()
		{
		}

		public CatalogModuleExtensionsRepository(string nameOrConnectionString, params IInterceptor[] interceptors) 
			: base(nameOrConnectionString, interceptors)
		{
			Configuration.ProxyCreationEnabled = false;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CategoryExtensionDataEntity>().HasKey(x => x.Id).Property(x => x.Id);
			modelBuilder.Entity<CategoryExtensionDataEntity>().ToTable("CatalogModuleExtension");

			base.OnModelCreating(modelBuilder);
		}
	}
}