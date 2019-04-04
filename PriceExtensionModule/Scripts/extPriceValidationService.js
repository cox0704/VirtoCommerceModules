//Call this to register our module to main application
var moduleName = "PriceExtensionModule.extPriceValidationService";

if (AppDependencies != undefined) {
	AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
	.factory('virtoCommerce.PriceExtensionModule.extPriceValidationService', [function() {
		return {
			isErpListPriceValid: function(data) {
				return data.erpListPrice === void 0 || data.erpListPrice >= 0;
			},
			isErpSalePriceValid: function(data) {
				return data.erpSalePrice === void 0 || data.erpListPrice >= data.erpSalePrice;
			}
		};
	}]);