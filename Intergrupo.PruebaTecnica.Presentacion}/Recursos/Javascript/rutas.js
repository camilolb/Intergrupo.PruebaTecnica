(function () {

    var app = angular.module('pruebaTecnica', ["ngRoute"]);

    app.config(function ($routeProvider, $httpProvider) {

        $routeProvider
            .when("/", {
                templateUrl: "./Index.html"
                , controller: "ClienteController"
                //Pagina Solicitud RMO

            }).when("/MisSolicitudes", {
                templateUrl: "./Paginas/Solicitud/Index.html"
                , controller: "MisSolicitudesController"
            }).when("/MisSolicitudes/Crear", {
                templateUrl: "./Paginas/Solicitud/Crear.html"
                , controller: "MisSolicitudesController"
            });

    });

})();