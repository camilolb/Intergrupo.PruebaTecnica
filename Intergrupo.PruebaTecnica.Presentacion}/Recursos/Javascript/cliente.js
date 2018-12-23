(function () {

    var app = angular.module('pruebaTecnica');

    app.controller("ClienteController", function ($scope, $route, $routeParams, $http
                                                , ClienteService) {

        $scope.cliente = {};

        $scope.crear = function (cliente)
        {
            var resultado = ClienteService.guardar(cliente);
            resultado.then(success, error);

            function success(e) {

                var cliente = angular.fromJson(e.data);

                if (cliente != null)
                {
                    alert("Cliente guardado exitosamente");
                    setTimeout(function () { window.location.href = './#/'; }, 1000);
                }
            };

            function error(e) {
                alert("Error al guardar el cliente");
            }
        };
    });


    app.service("ClienteService", function ($http, $q) {

        this.guardar = function (cliente) {

            var response = $q.defer();

            var data = cliente;
            var config = {};

            $http.post('./api/Cliente', data, config).then(successCallback, errorCallback);

            function successCallback(e) {

                var resultado = {
                    error: false
                    , mensaje: ""
                    , data: e.data
                }

                response.resolve(resultado);

            };

            function errorCallback(e) {

                var resultado = {
                    error: true
                    , mensaje: ""
                    , data: e.data
                }

                response.reject(resultado);

            };

            return response.promise;
        };

    });
})();

