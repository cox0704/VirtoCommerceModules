using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.Platform.Core.Common;

namespace AddressExtensionModule.Model
{
    public class AddressExtension : Address
    {
		public bool SplitShipments { get; set; }

		public FulfillmentMethod FulfillmentMethod { get; set; }

		public string PreferredCarrier { get; set; }

		public string DefaultPickupLocation { get; set; }
	}
}