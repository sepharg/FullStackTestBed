(function () {
    'use strict';

    var controllerId = 'bundleController';

    angular.module('BroadbandChoices-TestApp').controller(controllerId,
        ['$scope', 'broadbandChoicesService', bundleController]);

    function bundleController($scope, broadbandChoicesService) {
        $scope.bundle = '';
        $scope.getBundle = function getBundle(userId) {
            broadbandChoicesService.getBundle(userId).success(function (data) {
                $scope.bundle = data;
                $('#bundleResults').show();
            }).error(function (error) {
                // ToDo: log errors
            });
        }
    }
})();