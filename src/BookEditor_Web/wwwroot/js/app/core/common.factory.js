(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('commonFactory', commonFactory);
    
    function commonFactory() {

        return {
            closeModal: closeModal,
            copyProperties: copyProperties,
            findById: findById
        };

        function closeModal(modalName) {
            $('#bookModal').modal('hide');
            //angular.element(modalName).modal('hide');
        };

        function copyProperties(src, dst) {
            for (var propety in src)
                dst[propety] = src[propety];
        };

        function findById(items, id) {
            for (var i = 0; i < items.length; i++) {
                if (items[i].id == id) {
                    return items[i];
                }
            }
        };
    }
})();