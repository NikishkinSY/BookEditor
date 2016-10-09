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

        //close modal
        function closeModal() {
            $('#bookModal').modal('hide');
            //angular.element(modalName).modal('hide');
        };

        //copy all properties
        function copyProperties(src, dst) {
            for (var propety in src)
                dst[propety] = src[propety];
        };

        //find element in array
        function findById(items, id) {
            for (var i = 0; i < items.length; i++) {
                if (items[i].id == id) {
                    return items[i];
                }
            }
        };
    }
})();