using VirtoCommerce.Domain.Pricing.Model;

namespace PriceExtensionModule.Model
{
    public class PriceExtension : Price
    {
		[Precision(18, 4)]
        public decimal? ErpListPrice { get; set; }
		[Precision(18, 4)]
	    public decimal? ErpSalePrice { get; set; }
    }
}