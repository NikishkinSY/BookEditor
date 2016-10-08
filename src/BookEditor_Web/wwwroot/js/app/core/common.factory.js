(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('commonFactory', commonFactory);
    
    function commonFactory() {

        var service = {
            closeModal: closeModal,
            copyProperties: copyProperties
        };

        return service;

        function closeModal(modalName) {
            $('#bookModal').modal('hide');
            //angular.element(modalName).modal('hide');
        };

        function copyProperties(src, dst) {
            for (var propety in src)
                dst[propety] = src[propety];
        };
    }
})();