angular.module("Gesprog")
.controller("GesprogCtrl", function ($scope, CidadesService) {
    $scope.getCities = function (id) {
        CidadesService.GetCidades(id).then(function (response) {
            $scope.cities = response.data;
        });
    }
})
.factory('CidadesService', function ($http) {
    var fac = {};
    fac.GetCidades = function (id) {
        return $http.get('Cidades/GetCityId/' + id);
    }
    return fac;
});