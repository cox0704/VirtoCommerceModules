using VirtoCommerce.Domain.Catalog.Model;

namespace CatalogModuleExtensions.Models.Domain
{
	public class CategoryDomainExtension : Category
	{
		public string CategoryAlias { get; set; }
		public string CategoryAliasPath { get; set; }
	}
}