using System.ComponentModel.DataAnnotations;

using VirtoCommerce.CustomerModule.Data.Model;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.Platform.Core.Common;

namespace AddressExtensionModule.Model
{
    public class AddressExtensionDataEntity : AddressDataEntity
    {
        public bool SplitShipments { get; set; }

	    public FulfillmentMethod FulfillmentMethod { get; set; }

	    public string PreferredCarrier { get; set; }

	    public string DefaultPickupLocation { get; set; }

	    public override AddressDataEntity FromModel(Address address)
	    {
		    base.FromModel(address);

		    var addressExtension = (AddressExtension)address;

		    SplitShipments = addressExtension.SplitShipments;
		    FulfillmentMethod = addressExtension.FulfillmentMethod;
		    PreferredCarrier = addressExtension.PreferredCarrier;
		    DefaultPickupLocation = addressExtension.DefaultPickupLocation;

		    return this;
	    }

	    public override Address ToModel(Address address)
	    {
		    var result = base.ToModel(address);

		    var addressExtension = (AddressExtension) result;

		    addressExtension.SplitShipments = SplitShipments;
		    addressExtension.FulfillmentMethod = FulfillmentMethod;
		    addressExtension.PreferredCarrier = PreferredCarrier;
		    addressExtension.DefaultPickupLocation = DefaultPickupLocation;

		    return addressExtension;
	    }

	    public override void Patch(AddressDataEntity target)
	    {
		    base.Patch(target);

		    var addressExtensionEntity = (AddressExtensionDataEntity) target;

		    addressExtensionEntity.SplitShipments = SplitShipments;
		    addressExtensionEntity.FulfillmentMethod = FulfillmentMethod;
		    addressExtensionEntity.PreferredCarrier = PreferredCarrier;
		    addressExtensionEntity.DefaultPickupLocation = DefaultPickupLocation;
	    }
    }
}