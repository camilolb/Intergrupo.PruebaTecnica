(function () {

    var app = angular.module('pruebaTecnica', ["ngRoute"]);

    app.config(function ($routeProvider, $httpProvider) {

        $routeProvider
            .when("/", {
                templateUrl: "./Index.html"
                , controller: "ClienteController"
            });

    });

})();