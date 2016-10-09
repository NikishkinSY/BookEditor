(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('cookiesFactory', cookiesFactory);

    cookiesFactory.$inject = ['$cookies'];

    function cookiesFactory($cookies) {

        return {
            get: get,
            put: put
        };

        function get(key) {
            return $cookies.get(key);
        };

        function put(key, value, minutes) {
            var options = minutes ? { 'expires': getExpirationDate(minutes) } : undefined;
            $cookies.put(key, value, options);
        };

        function getExpirationDate(minutes) {
            return new Date(new Date().getTime() + minutes * 60000);
        };
    }
})();