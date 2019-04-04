//Call this to register our module to main application
var moduleName = "PriceExtensionModule";

if (AppDependencies != undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
	.run([
		'platformWebApp.ui-grid.extension', 'virtoCommerce.PriceExtensionModule.extPriceValidationService',
		'uiGridValidateService', function(gridOptionExtension, priceValidatorsService, uiGridValidateService) {
			uiGridValidateService.setValidator('erpListValidator',
				function(argument) {
					return function(oldValue, newValue, rowEntity, colDef) {
						return priceValidatorsService.isErpListPriceValid(rowEntity);
					}
				},
				function(argument) { return 'Erp List Price is invalid '; });

			uiGridValidateService.setValidator('erpSaleValidator',
				function(argument) {
					return function(oldValue, newValue, rowEntity, colDef) {
						return priceValidatorsService.isErpSalePriceValid(rowEntity);
					};
				},
				function(argument) { return 'Erp Sale Price should not exceed Erp List Price'; });

			console.log(gridOptionExtension);

			gridOptionExtension.registerExtension('pricelist-grid',
				function(gridOptions) {
					gridOptions.columnDefs.push({
							name: 'erpListPrice',
							displayName: 'Erp List Price',
							editableCellTemplate:
								'/Modules/RBH.PriceExtensionModule/Scripts/GridTemplates/extErpPriceEditor.html',
							validators: { required: true, erpListValidator: true },
							cellTemplate:
								'/Modules/RBH.PriceExtensionModule/Scripts/GridTemplates/extErpPriceTitleValidator.html',
							enableCellEdit: true
						},
						{
							name: 'erpSalePrice',
							displayName: 'Erp Sale Price',
							editableCellTemplate:
								'/Modules/RBH.PriceExtensionModule/Scripts/GridTemplates/extErpPriceEditor.html',
							validators: { required: true, erpSaleValidator: true },
							cellTemplate:
								'/Modules/RBH.PriceExtensionModule/Scripts/GridTemplates/extErpPriceTitleValidator.html',
							enableCellEdit: true
						});
				});
		}
	]);


