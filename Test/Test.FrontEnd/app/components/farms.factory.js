(function () {
    'use strict';

    angular
        .module("app.Farms")
        .factory("farmsFactory", farmsFactory);

    farmsFactory.$inject = ["$q", "apiConnection"];

    function farmsFactory($q, apiConnection) {

        var service = {
            getAllFarms: getAllFarms,
            getFarm: getFarm,
            getServer: getServer,
        };

        function getAllFarms() {

            var defered = $q.defer();

            var url = "api/Farms";

            apiConnection.get(url).then(
                function (data) {
                    defered.resolve(data);
                }, function (reason) {
                    defered.reject("You couldn't get permissions. Reason: " + JSON.stringify(reason));
                });

            return defered.promise;
        };
        function getFarm(id) {

            var defered = $q.defer();

            var url = "api/Farms/"+id;

            apiConnection.get(url).then(
                function (data) {
                    defered.resolve(data);
                }, function (reason) {
                    defered.reject("You couldn't get permissions. Reason: " + JSON.stringify(reason));
                });

            return defered.promise;
        };
        function getServer(id) {

            var defered = $q.defer();

            var url = "api/Servers/"+id;

            apiConnection.get(url).then(
                function (data) {
                    defered.resolve(data);
                }, function (reason) {
                    defered.reject("You couldn't get permissions. Reason: " + JSON.stringify(reason));
                });

            return defered.promise;
        };

        return service;

    }
})();