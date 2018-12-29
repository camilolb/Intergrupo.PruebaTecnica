(function () {

    var app = angular.module('pruebaTecnica');

    app.controller("ClienteController", function ($scope, $route, $routeParams, $http
                                                , ClienteService) {
        // Variables globales
        $scope.cliente = {};
        $scope.listaClientes = [];


        // Metodos de carga
        CargarClientes();

        $scope.crear = function (cliente)
        {
            var resultado = ClienteService.guardar(cliente);
            resultado.then(success, error);

            function success(e) {

                var cliente = angular.fromJson(e.data);

                if (cliente != null)
                {
                    alert("Cliente guardado exitosamente");
                    location.reload();
                }
            }

            function error(e) {
                alert("Error al guardar el cliente");
            }
        };


        function CargarClientes()
        {
            ClienteService.obtenerClientes().then(function (e)
            {
                var listaClientes = angular.fromJson(e.data);

                if (listaClientes != null
                    && listaClientes.length > 0)
                {
                    $scope.listaClientes = listaClientes;
                } else {
                    $scope.listaClientes = "No hay ningún cliente creado recientemente.";
                }
            });
        }
    });


    app.service("ClienteService", function ($http, $q) {

        this.obtenerClientes = function () {

            var response = $q.defer();

            var data = {};
            var config = {};

            $http.get('./api/Cliente', data, config).then(successCallback, errorCallback);

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
        }

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

