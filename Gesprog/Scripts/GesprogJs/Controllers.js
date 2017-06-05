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
    //busca as tecnologias
    Service.GetTecnologias().then(function (response) {
        $scope.ListTecnologias = response.data;
    });

    //seta as tecnologias escolhidas e seus respectivos valores
    $scope.Tecnologias = [];
    $scope.TecnologiasSelecionadas=[];
    $scope.SetTecnologiasSelecionada = function (nivel, tecnologia) {
        if ($scope.Tecnologias.length == 0) {
            $scope.Tecnologias.push({
                ID_TECNO: tecnologia.ID_TECNO,
                DESC_TECNO: tecnologia.DESC_TECNO,
                NIVEL: nivel

            });
        }
        else {
            console.log($scope.Tecnologias);
            for (var i = $scope.Tecnologias.length - 1; i >= 0; i--) {
                alert(i + " " + $scope.Tecnologias[i].ID_TECNO + " " + tecnologia.ID_TECNO);
                if ($scope.Tecnologias[i].ID_TECNO == tecnologia.ID_TECNO) {
                    $scope.Tecnologias.splice(i, 1);
                };
            };
            $scope.Tecnologias.push({
                ID_TECNO: tecnologia.ID_TECNO,
                DESC_TECNO: tecnologia.DESC_TECNO,
                NIVEL: nivel

            });
            console.log($scope.Tecnologias);
        };
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
    fac.GetTecnologias = function () {
        return $http.get('Tecnologias/GetAllTecnologias');
    }
    return fac;
});