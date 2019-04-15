var moduleName = "AddressExtensionModule";

if (AppDependencies != undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
	.run(
	['$rootScope', 'platformWebApp.metaFormsService', function ($rootScope, metaFormsService) {

		metaFormsService.registerMetaFields("addressDetails",
			[
				{
					name: "splitShipments",
					title: "Split Shipments?",
					valueType: "Boolean"
				},
				{
					name: "preferredCarrier",
					title: "Preferred Carrier",
					valueType: "ShortText"
				},
				{
					name: "defaultPickupLocation",
					title: "Default Pickup Location",
					valueType: "ShortText"
				}
			])
	}]);