(function () {
    'use strict';

    angular
        .module('app.core')
        .directive('ngAtLeastOne', ngAtLeastOne)

    ngAtLeastOne.$inject = [];

    function ngAtLeastOne() {
        return {
            link: function (scope, element, attr) {
                var test = 0;
                //var blacklist = attr.blacklist.split(',');

                ////For DOM -> model validation
                //ngModel.$parsers.unshift(function (value) {
                //    var valid = blacklist.indexOf(value) === -1;
                //    ngModel.$setValidity('blacklist', valid);
                //    return valid ? value : undefined;
                //});

                ////For model -> DOM validation
                //ngModel.$formatters.unshift(function (value) {
                //    ngModel.$setValidity('blacklist', blacklist.indexOf(value) === -1);
                //    return value;
                //});
            }
        };
    }
})();