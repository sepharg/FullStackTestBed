(function () {
    'use strict';

    var serviceId = 'broadbandChoicesService';

    angular.module('BroadbandChoices-TestApp').factory(serviceId,
        ['$http', broadbandChoicesService]);

    function broadbandChoicesService($http) {

        function getBundle() {
            return $http.get("/api/BroadbandChoices/GetBundleAsync/1");
        }

        var service = {
            getBundle: getBundle
        };

        return service;
    }
})();