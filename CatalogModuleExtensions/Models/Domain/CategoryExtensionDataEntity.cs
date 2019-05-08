using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using VirtoCommerce.CatalogModule.Data.Model;
using VirtoCommerce.Domain.Catalog.Model;
using VirtoCommerce.Platform.Core.Common;

namespace CatalogModuleExtensions.Models.Domain
{
	public class CategoryExtensionDataEntity : CategoryEntity
	{
		[Required]
		[Index("IX_CategoryAlias", 0, IsUnique = true)]
		[StringLength(64, ErrorMessage = "Category alias exceeds max allowed length.")]
		public string CategoryAlias { get; set; }

		[Required]
		[Index("IX_CategoryAliasPath", 0, IsUnique = true)]
		[StringLength(2000, ErrorMessage = "Category alias path exceeds max allowed length.")]
		public string CategoryAliasPath { get; set; }

		public override void Patch(CategoryEntity categoryEntity)
		{
			base.Patch(categoryEntity);

			var originalCategoryEntity = categoryEntity;
			var extendedCategory = (CategoryExtensionDataEntity)originalCategoryEntity;

			extendedCategory.CategoryAlias = CategoryAlias;
			extendedCategory.CategoryAliasPath = CategoryAliasPath;
		}

		public override Category ToModel(Category category)
		{
			var categoryModel = (CategoryDomainExtension)base.ToModel(category);

			//ToDo: create regex to strip invalid characters
			categoryModel.CategoryAlias = CategoryAlias;
			categoryModel.CategoryAliasPath = CategoryAliasPath;

			return categoryModel;
		}

		public override CategoryEntity FromModel(Category category, PrimaryKeyResolvingMap pkMap)
		{
			base.FromModel(category, pkMap);

			var categoryExtension = (CategoryDomainExtension)category;

			CategoryAlias = categoryExtension.CategoryAlias;
			CategoryAliasPath = categoryExtension.CategoryAliasPath;

			return this;
		}
	}
}