using System.Data.Entity;
using System.Linq;
using PriceExtensionModule.Model;
using VirtoCommerce.PricingModule.Data.Repositories;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;

namespace PriceExtensionModule
{
    public class PriceExtensionRepository : PricingRepositoryImpl
    {
        public PriceExtensionRepository()
        {
        }

        public PriceExtensionRepository(string nameOrConnectionString, params IInterceptor[] interceptors)
            : base(nameOrConnectionString, interceptors)
        {
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region PriceExtension
            modelBuilder.Entity<PriceExtensionDataEntity>().HasKey(x => x.Id)
                .Property(x => x.Id);
            modelBuilder.Entity<PriceExtensionDataEntity>().ToTable("PriceExtension");

			Precision.ConfigureModelBuilder(modelBuilder);
            #endregion

            base.OnModelCreating(modelBuilder);
        }

	    public IQueryable<PriceExtensionDataEntity> PriceExtensions
	    {
		    get { return GetAsQueryable<PriceExtensionDataEntity>(); }
	    }
    }
}
