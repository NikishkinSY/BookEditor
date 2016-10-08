(function () {
    'use strict';

    angular
        .module('app.book')
        .controller('BookController', Book);

    Book.$inject = ['bookApi'];

    function Book(bookApi) {
        var vm = this;
        vm.title = 'book';
        vm.newBook = {};
        vm.books = [];

        vm.sortPredicateBook;
        vm.reverse;

        vm.getBooks = function () {
            bookApi.getBooks()
                .then(function (data) {
                    vm.books = data;
                });
        };

        vm.addBook = function () {
            bookApi.addBook(vm.newBook)
                .then(function (response) {
                    vm.books.push(vm.newBook);
                    vm.newBook = {};
                    closeModal();
                });
        };

        vm.sort = function (column) {
            vm.sortPredicateBook = column;
            vm.reverse = !vm.reverse
        };

        function closeModal() {
            angular.element('#addBookModal').modal('hide');
        };
    }
})();
