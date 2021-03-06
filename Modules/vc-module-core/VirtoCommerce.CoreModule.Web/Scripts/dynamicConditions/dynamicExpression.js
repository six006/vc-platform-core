﻿angular.module('virtoCommerce.coreModule.common', [])
    .run(
        ['$http', '$compile', 'virtoCommerce.coreModule.common.dynamicExpressionService', function ($http, $compile, dynamicExpressionService) {

            //Register PROMOTION expressions
            dynamicExpressionService.registerExpression({
                id: 'BlockCustomerCondition',
                newChildLabel: '+ add user group',
                getValidationError: function () {
                    return (this.children && this.children.length) ? undefined : 'Promotion requires at least one eligibility';
                }
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionIsEveryone',
                displayName: 'Everyone'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionIsFirstTimeBuyer',
                displayName: 'First time buyer'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionIsRegisteredUser',
                displayName: 'Registered user'
            });
            dynamicExpressionService.registerExpression({
                id: 'UserGroupsContainsCondition',
                displayName: 'User groups contains []'
            });

            var availableExcludings = [
                {
                    id: 'ExcludingCategoryCondition'
                },
                {
                    id: 'ExcludingProductCondition'
                }
            ];
            dynamicExpressionService.registerExpression({
                id: 'ExcludingCategoryCondition',
                displayName: 'Items of category'
            });
            dynamicExpressionService.registerExpression({
                id: 'ExcludingProductCondition',
                displayName: 'Items of entry'
            });

            dynamicExpressionService.registerExpression({
                id: 'BlockCatalogCondition',
                newChildLabel: '+ add condition'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionEntryIs',
                // templateURL: 'expression-ConditionEntryIs.html',
                // controller: 'conditionEntryIsController'
                displayName: 'Product is []'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionCurrencyIs',
                displayName: 'Currency is []'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionCodeContains',
                displayName: 'Product code contains []'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionCategoryIs',
                displayName: 'Category is []',
                availableChildren: availableExcludings,
                newChildLabel: '+ excluding'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionInStockQuantity',
                displayName: 'InStock quantity is []'
            });

            dynamicExpressionService.registerExpression({
                id: 'BlockCartCondition',
                newChildLabel: '+ add condition'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionCartSubtotalLeast',
                displayName: 'Cart subtotal is []',
                availableChildren: availableExcludings,
                newChildLabel: '+ excluding'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionAtNumItemsInCart',
                displayName: '[] [] items are in shopping cart',
                availableChildren: availableExcludings,
                newChildLabel: '+ excluding'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionAtNumItemsInCategoryAreInCart',
                displayName: '[] [] items of category are in shopping cart',
                availableChildren: availableExcludings,
                newChildLabel: '+ excluding'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionAtNumItemsOfEntryAreInCart',
                displayName: '[] [] items of entry are in shopping cart'
            });
            dynamicExpressionService.registerExpression({
                id: 'BlockReward',
                newChildLabel: '+ add effect',
                getValidationError: function () {
                    return (this.children && this.children.length) ? undefined : 'Promotion requires at least one reward';
                }
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardCartGetOfAbsSubtotal',
                displayName: 'Get $[] off cart subtotal'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardCartGetOfRelSubtotal',
                displayName: 'Get [] % off cart subtotal not to exceed $ []'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardItemGetFreeNumItemOfProduct',
                displayName: 'Get [] free items of product []'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardItemGiftNumItem',
                displayName: 'Gift [] of product []'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardItemGetOfAbs',
                displayName: 'Get $[] off'
            });

            dynamicExpressionService.registerExpression({
                id: 'RewardItemGetOfRel',
                displayName: 'Get [] % off [] not to exceed $ []'
            });

            dynamicExpressionService.registerExpression({
                id: 'RewardItemGetOfAbsForNum',
                displayName: 'Get $[] off [] items of entry []'
                //availableChildren: availableExcludings,
                //newChildLabel: '+ excluding'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardItemGetOfRelForNum',
                displayName: 'Get [] % off [] items of entry [] not to exceed $ []'
                //availableChildren: availableExcludings,
                //newChildLabel: '+ excluding'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardShippingGetOfAbsShippingMethod',
                displayName: 'Get $[] off shipping []'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardShippingGetOfRelShippingMethod',
                displayName: 'Get [] % off shipping [] not to exceed $ []'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardPaymentGetOfAbs',
                displayName: 'Get $[] off payment method []'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardPaymentGetOfRel',
                displayName: 'Get [] % off payment method [] not to exceed $ []'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardItemForEveryNumInGetOfRel',
                displayName: 'For [] in every [] items of entry [] get [] % off…'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardItemForEveryNumOtherItemInGetOfRel',
                displayName: 'For [] items of entry [] in every [] items of entry [] get [] % off…'
            });

            //Register COMMON expressions
            var groupNames = ['Browse behavior', 'Shopper profile', 'Shopping cart', 'Geo location'];
            dynamicExpressionService.registerExpression({
                groupName: groupNames[0],
                id: 'ConditionStoreSearchedPhrase',
                displayName: 'Shopper searched for phrase [] in store'
            });
            dynamicExpressionService.registerExpression({
                groupName: groupNames[0],
                id: 'ConditionLanguageIs',
                displayName: 'Current language is []'
            });

            dynamicExpressionService.registerExpression({
                groupName: groupNames[1],
                id: 'ConditionAgeIs',
                displayName: 'Shopper age is []'
            });
            dynamicExpressionService.registerExpression({
                groupName: groupNames[1],
                id: 'ConditionGenderIs',
                displayName: 'Shopper gender is []'
            });

            dynamicExpressionService.registerExpression({
                groupName: groupNames[3],
                id: 'ConditionGeoTimeZone',
                displayName: 'Browsing from a time zone -/+ offset from UTC []'
            });
            dynamicExpressionService.registerExpression({
                groupName: groupNames[3],
                id: 'ConditionGeoZipCode',
                displayName: 'Browsing from zip/postal code []'
            });
            dynamicExpressionService.registerExpression({
                groupName: groupNames[3],
                id: 'ConditionGeoCity',
                displayName: 'Browsing from city []'
            });
            dynamicExpressionService.registerExpression({
                groupName: groupNames[3],
                id: 'ConditionGeoCountry',
                displayName: 'Browsing from country []'
            });
            dynamicExpressionService.registerExpression({
                groupName: groupNames[3],
                id: 'ConditionGeoState',
                displayName: 'Browsing from state []'
            });

            //Register CONTENT PUBLISHING expressions
            dynamicExpressionService.registerExpression({
                id: 'BlockContentCondition',
                newChildLabel: '+ add condition'
            });

            //Register PRICELIST ASSIGNMENT expressions
            dynamicExpressionService.registerExpression({
                id: 'BlockPricingCondition',
                newChildLabel: '+ add condition'
            });
            
            dynamicExpressionService.registerExpression({
                groupName: groupNames[1],
                id: 'UserGroupsContainsCondition',
                displayName: 'User groups contains []'
            });

            $http.get('Modules/$(VirtoCommerce.Core)/Scripts/dynamicConditions/all-templates.html').then(function (response) {
                // compile the response, which will put stuff into the cache
                $compile(response.data);
            });
        }])
    .controller('virtoCommerce.dynamicExpressions.conditionLanguageIsController', ['$scope', 'platformWebApp.settings', function ($scope, settings) {
        $scope.availableLanguages = settings.getValues({ id: 'VirtoCommerce.Core.General.Languages' });
    }])
    .controller('virtoCommerce.dynamicExpressions.conditionGeoCountryController', ['$scope', 'virtoCommerce.coreModule.common.countries', function ($scope, countries) {
        $scope.countries = countries.query();
    }])
    .controller('virtoCommerce.dynamicExpressions.conditionGeoTimeZoneController', ['$scope', 'virtoCommerce.coreModule.common.countries', function ($scope, countries) {
        $scope.timeZones = countries.getTimeZones();
    }])
    .controller('virtoCommerce.dynamicExpressions.shippingMethodRewardController', ['$scope', function ($scope) {
        function initialize(storeIds) {
            //Use stores ($scope.stores) from parent controller virtoCommerce.marketingModule.promotionDetailController
            let selectedStores = _.filter($scope.stores, function (x) { return (storeIds && storeIds.length > 0) ? storeIds.indexOf(x.id) >= 0 : true });
            $scope.shippingMethods = _.uniq(_.flatten(_.pluck(selectedStores, 'shippingMethods')), function (x) { return x.code; });
            if ($scope.shippingMethods.length === 0) {
                $scope.shippingMethods = [{ code: 'No methods found' }];
            }
        }
        $scope.$watch('stores', function () { initialize($scope.blade.currentEntity.storeIds); }, true);
        $scope.$watch('blade.currentEntity.storeIds', initialize);
    }])
    .controller('virtoCommerce.dynamicExpressions.paymentMethodRewardController', ['$scope', function ($scope) {
        function initialize(storeIds) {
            //Use stores ($scope.stores) from parent controller virtoCommerce.marketingModule.promotionDetailController
            let selectedStores = _.filter($scope.stores, function (x) { return (storeIds && storeIds.length > 0) ? storeIds.indexOf(x.id) >= 0 : true });
            $scope.paymentMethods = _.uniq(_.flatten(_.pluck(selectedStores, 'paymentMethods')), function (x) { return x.code; });
            if ($scope.paymentMethods.length === 0) {
                $scope.paymentMethods = [{ code: 'No methods found' }];
            }
        }
        $scope.$watch('stores', function () { initialize($scope.blade.currentEntity.storeIds); }, true);
        $scope.$watch('blade.currentEntity.storeIds', initialize);
    }])
    .filter('compareConditionToText', function () {
        return function (input) {
            var retVal;

            switch (input) {
                case 'IsMatching': retVal = 'matching'; break;
                case 'IsNotMatching': retVal = 'not matching'; break;
                case 'IsGreaterThan': retVal = 'greater than'; break;
                case 'IsGreaterThanOrEqual': retVal = 'greater than or equals'; break;
                case 'IsLessThan': retVal = 'less than'; break;
                case 'IsLessThanOrEqual': retVal = 'less than or equals'; break;
                case 'Contains': retVal = 'containing'; break;
                case 'NotContains': retVal = 'not containing'; break;
                case 'Matching': retVal = 'matching'; break;
                case 'NotMatching': retVal = 'not matching'; break;
                case 'Exactly': retVal = 'exactly'; break;
                case 'AtLeast': retVal = 'at least'; break;
                case 'Between': retVal = 'between'; break;
                default:
                    retVal = input;
            }
            return retVal;
        };
    });
