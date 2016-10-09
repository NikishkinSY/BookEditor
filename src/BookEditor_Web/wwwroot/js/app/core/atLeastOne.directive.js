(function () {
    'use strict';

    angular
        .module('app.core')
        .directive('ngAtLeastOne', ngAtLeastOne)

    ngAtLeastOne.$inject = [];

    function ngAtLeastOne() {
        return {
            link: function (scope, element, attr) {
                
            }
        };
    }
})();