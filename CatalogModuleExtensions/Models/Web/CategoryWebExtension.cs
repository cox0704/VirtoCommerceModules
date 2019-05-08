using VirtoCommerce.CatalogModule.Web.Model;

namespace CatalogModuleExtensions.Models.Web
{
	public class CategoryWebExtension : Category
	{
		public string CategoryAlias { get; set; }
		public string CategoryAliasPath { get; set; }
	}
}