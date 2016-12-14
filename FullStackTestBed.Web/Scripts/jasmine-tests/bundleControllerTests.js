/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="../angular.js" />
/// <reference path="../angular-mocks.js" />
/// <reference path="../app/app.js" />
/// <reference path="../app/controllers/bundleController.js" />

describe("When using bundleController", function () {
    var $scope, ctrl;

    var broadbandChoicesServiceMock;
    var bundleData = { "bundleId": 5490, "providerName": "Onebill Telecom" };

    beforeEach(function () {
        broadbandChoicesServiceMock = jasmine.createSpyObj('broadbandChoicesService', ['getBundle']);

        module('BroadbandChoices-TestApp');

        inject(function ($rootScope, $controller, $q) {

            $scope = $rootScope.$new();

            var promise = $q.resolve(bundleData);

            promise.success = function (callback) {
                promise.then(callback(bundleData));
                return promise;
            };
            
            promise.error = function (callback) {
                promise.then(null, callback);
                return promise;
            };

            broadbandChoicesServiceMock.getBundle.and.returnValue(promise);
            
            ctrl = $controller('bundleController', { $scope: $scope, broadbandChoicesService: broadbandChoicesServiceMock });
        });
    });

    it('should start with empty bundle', function () {

        expect($scope.bundle).toEqual('');
    });

    it('should return data from API when calling getBundle', function () {
        $scope.getBundle(1);

        expect(broadbandChoicesServiceMock.getBundle).toHaveBeenCalled();
        expect($scope.bundle).not.toBe('');
        expect($scope.bundle.bundleId).toBe(bundleData.bundleId);
        expect($scope.bundle.providerName).toBe(bundleData.providerName);
    });

    it('should show bundle on successful result', function () {

        var selectorSpy = spyOn($.fn, "show").and.callThrough();

        $scope.getBundle(1);
        
        expect(selectorSpy).toHaveBeenCalled();
    });

});
