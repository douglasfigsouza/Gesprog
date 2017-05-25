//localiza o modulo e cria o controller
angular.module("Gesprog")
.controller("GesprogCtrl", function ($scope, Service) {
    //função que preenche o combo cidades em função do estado
    $scope.getCities = function (id) {
            Service.GetCidades(id).then(function (response) {
            $scope.cities = response.data;
        });
    }
    //função que cria os checkbox de horarios
    Service.GetHorarios().then(function (response) {
          $scope.ListHorarios = response.data;
    });

})
.factory('Service', function ($http) {
    var fac = {};
    fac.GetCidades = function (id) {
        return $http.get('Cidades/GetCityId/' + id);
    }
    fac.GetHorarios = function () {
        return $http.get('Programadores/GetHorarios');
    }
    return fac;
});