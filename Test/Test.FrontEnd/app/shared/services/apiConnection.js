(function () {
    'use strict';

    angular
        .module('app.services')
        .factory('apiConnection', apiConnection);

    apiConnection.$inject = ['$http', '$q', 'config', 'webConfigSettings'];

    function apiConnection($http, $q, config, webConfigSettings) {

        var apiConnectionFactory = this;

        var serviceBase = webConfigSettings.webApiBaseUrl;

        apiConnectionFactory.get = _get;
        //TODO:post if needed

        return apiConnectionFactory;

        function _get(url) {
            var defered = $q.defer();

            var requestHeaders = {};
            requestHeaders['Content-Type'] = 'application/json';

            var config = {
                method: 'GET',
                url: serviceBase + url,
                cache: false,
                headers: requestHeaders
            }
            $http(config)
                .then(function (success) {
                    defered.resolve(success);
                },
                function(data, status, headers, configs, statusText) {
                    console.log(statusText);
                    defered.reject(data);
                });

            return defered.promise;
        }
    };
})();