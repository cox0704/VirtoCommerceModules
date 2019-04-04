using VirtoCommerce.Domain.Pricing.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.PricingModule.Data.Model;

namespace PriceExtensionModule.Model
{
    public class PriceExtensionDataEntity : PriceEntity
    {
		[Precision(18, 4)]
        public decimal? ErpListPrice { get; set; }

		[Precision(18, 4)]
	    public decimal? ErpSalePrice { get; set; }

	    public override Price ToModel(Price price)
	    {
		    var result = base.ToModel(price);

		    var priceExtension = (PriceExtension) result;

		    priceExtension.ErpListPrice = ErpListPrice;
		    priceExtension.ErpSalePrice = ErpSalePrice;

		    return priceExtension;
	    }

	    public override PriceEntity FromModel(Price price, PrimaryKeyResolvingMap pkMap)
	    {
			base.FromModel(price, pkMap);

		    var priceExtension = (PriceExtension) price;

		    ErpListPrice = priceExtension.ErpListPrice;
		    ErpSalePrice = priceExtension.ErpSalePrice;

		    return this;
	    }
 
	    public override void Patch(PriceEntity priceDataEntity)
        {
            base.Patch(priceDataEntity);
            var target = (PriceExtensionDataEntity)priceDataEntity;

            target.ErpListPrice = ErpListPrice;
            target.ErpSalePrice = ErpSalePrice;
            
        }
    }
}