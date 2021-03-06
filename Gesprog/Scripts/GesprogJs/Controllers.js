﻿//localiza o modulo e cria o controller
angular.module("Gesprog")
.controller("GesprogCtrl", function ($scope, Service) {
    //declarações de variaveis
    $scope.HorariosSelecionados = [];
    $scope.Tecnologias = [];
    $scope.TecnologiasSelecionadas = [];
    $scope.Niveis = [];

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
    // toggle selection for a given employee by name
    $scope.toggleSelection = function toggleSelection(item) {
        var idx = $scope.HorariosSelecionados.indexOf(item.ID_HR);
        // is currently selected
        if (idx > -1) {
            $scope.HorariosSelecionados.splice(idx, 1);
        }

            // is newly selected
        else {
            $scope.HorariosSelecionados.push({
                "ID_HR": item.ID_HR,
                "DESC_HR":item.DESC_HR
            });
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
    $scope.SetTecnologiasSelecionada = function (nivel, i) {
        $scope.Niveis[i]=nivel;
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