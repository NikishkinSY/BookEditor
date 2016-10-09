(function () {
    'use strict';

    angular.module('app', [
        // Angular modules 
        'ngMaterial',
        'ngCookies',
        'ngMessages',
        // Custom modules 
        'app.core',
        'app.book',
        'app.author',
        // 3rd Party Modules
        'angularjs-dropdown-multiselect',
        'naif.base64'
    ]);
})();