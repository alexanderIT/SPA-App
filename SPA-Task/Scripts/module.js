var app;
(function () {
    app = angular.module("APIModule", []);
})();

app.service("EngineService", ['$http', function ($http) {
    this.getMatches = function () {
        var result = $http.get("api/Engine");
        return result;
    }
}]);

app.controller('APIController', ['$scope','$timeout', 'EngineService', function ($scope, $timeout, EngineService) {
    getAll();
    function getAll() {
        (function tick() {
            var servCall = EngineService.getMatches();
            servCall.then(function (data) {
                $scope.matches = data;
                $timeout(tick, 50000);
            }, function (error) {
                $log.error('Oops! Something went wrong while fetching the data.');
            });
        })();       
    }
}])