//localiza o modulo e cria o controller
angular.module("Gesprog")
.controller("GesprogCtrl", function ($scope, Service) {
    //função que preenche o combo cidades em função do estado
    $scope.getCities = function (id) {
        alert("teste");
        Service.GetCidades(id).then(function (response) {
            $scope.cities = response.data;
        });
    }
    //função que cria os checkbox de horarios
    Service.GetHorarios().then(function (response) {
        $scope.ListHorarios = response.data;
    });
    $scope.HorariosSelecionados = [];
    // toggle selection for a given employee by name
    $scope.toggleSelection = function toggleSelection(IdChecked) {
        var idx = $scope.HorariosSelecionados.indexOf(IdChecked);
        // is currently selected
        if (idx > -1) {
            $scope.HorariosSelecionados.splice(idx, 1);
        }

            // is newly selected
        else {
            $scope.HorariosSelecionados.push(IdChecked);
        }
    };
    //função que seta a disponibilidade de horario por dia 
    $scope.SetDisponibilidade = function (op) {
        $scope.programador.DISPHRTRDIA_PROG = op;
    };

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