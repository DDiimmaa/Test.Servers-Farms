(function () {
    'use strict';

    angular
        .module('app')
        .config(config);
        //.run(routeAuth);

    function config($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise('/farms');

        $stateProvider
            .state('Farms', {
                url: "/farms",
                templateUrl: "/app/components/farms.html",
                controller: 'farmsController',
                controllerAs: 'fvm',
                data: { }
            })
    }

    function routeAuth($rootScope, $state, $location) {
        ////be carefull! this thing is user after relogin with return url
        //var currentUrl = window.location.pathname;
        //if (currentUrl.indexOf("Pipeline") != -1) {
        //    $state.go("projects");
        //}
        //else if (currentUrl.indexOf("ExternalSystemsManagement") != -1) {
        //    $state.go("ES_add");
        //}
        //else if (currentUrl.indexOf("ResourceManagement") != -1) {
        //    $state.go("UIG_list");
        //}

        //$state.go("Farms");
    };
})();