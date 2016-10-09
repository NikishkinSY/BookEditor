(function () {
    'use strict';

    angular
        .module('app.author')
        .controller('AuthorController', Author);

    Author.$inject = ['authorApi', 'shareService'];

    function Author(authorApi, shareService) {
        var vm = this;
        vm.authors = shareService.authors;
        vm.tempAuthor = {};
        vm.show = false;

        vm.getAuthors = function () {
            authorApi.getAuthors()
                .then(function (data) {
                    shareService.addAuthors(data);
                });
        };

        vm.addAuthor = function () {
            authorApi.addAuthor(vm.tempAuthor)
                .then(function (data) {
                    vm.tempAuthor.id = data;
                    shareService.addAuthor(vm.tempAuthor);
                    vm.tempAuthor = {};
                });
        };

        vm.editAuthor = function (author) {

        };

        vm.deleteAuthor = function (id) {
            authorApi.deleteAuthor(id)
                .then(function (data) {
                    shareService.deleteAuthor(id);
                });
        };


    }
})();
