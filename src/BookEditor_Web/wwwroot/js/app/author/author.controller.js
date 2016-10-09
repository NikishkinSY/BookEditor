(function () {
    'use strict';

    angular
        .module('app.author')
        .controller('AuthorController', Author);

    Author.$inject = ['authorApi', 'shareService', 'toastr'];

    function Author(authorApi, shareService, toastr) {
        var vm = this;
        vm.authors = shareService.authors;
        vm.tempAuthor = {};
        vm.show = false;

        //get all authors
        vm.getAuthors = function () {
            authorApi.getAuthors()
                .then(function (data) {
                    shareService.addAuthors(data);
                });
        };

        //insert author
        vm.addAuthor = function () {
            authorApi.addAuthor(vm.tempAuthor)
                .then(function (data) {
                    if (data < 0)
                        toastr.error('Server error, try one more time', 'Error');
                    else {
                        vm.tempAuthor.id = data;
                        shareService.addAuthor(vm.tempAuthor);
                        vm.tempAuthor = {};
                        toastr.success('Author added', '');
                    }
                });
        };

        //delete author
        vm.deleteAuthor = function (id) {
            authorApi.deleteAuthor(id)
                .then(function (data) {
                    shareService.deleteAuthor(id);
                    toastr.success('Author deleted', '');
                });
        };
    }
})();
