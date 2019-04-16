using System.Data.Entity;
using System.Linq;
using AddressExtensionModule.Model;
using VirtoCommerce.CustomerModule.Data.Model;
using VirtoCommerce.CustomerModule.Data.Repositories;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;

namespace AddressExtensionModule
{
	public class AddressExtensionRepository : CustomerRepositoryImpl
	{
		public AddressExtensionRepository()
		{
		}

		public AddressExtensionRepository(string nameOrConnectionString, params IInterceptor[] interceptors)
			: base(nameOrConnectionString, interceptors)
		{
			Configuration.ProxyCreationEnabled = false;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			#region AddressExtension
			modelBuilder.Entity<AddressExtensionDataEntity>().HasKey(x => x.Id)
				.Property(x => x.Id);
			modelBuilder.Entity<AddressExtensionDataEntity>().ToTable("AddressShippingExtension");

			#endregion

			base.OnModelCreating(modelBuilder);
		}

		public IQueryable<AddressExtensionDataEntity> AddressExtensions
		{
			get { return GetAsQueryable<AddressExtensionDataEntity>(); }
		}

		public override MemberDataEntity[] GetMembersByIds(string[] ids, string responseGroup = null, string[] memberTypes = null)
		{
			var retVal = base.GetMembersByIds(ids, responseGroup, memberTypes);

			var memberResponseGroup = EnumUtility.SafeParseFlags(responseGroup, MemberResponseGroup.Full);

			// Need to load Addresses only if we have this response group included
			// https://github.com/VirtoCommerce/vc-module-customer/blob/dev/VirtoCommerce.CustomerModule.Data/Repositories/MemberRepositoryBase.cs#L257
			if (memberResponseGroup.HasFlag(MemberResponseGroup.WithAddresses))
			{
				var addresses = AddressExtensions.Where(x => ids.Contains(x.MemberId)).ToArray();
			}

			return retVal;
		}
	}
}
