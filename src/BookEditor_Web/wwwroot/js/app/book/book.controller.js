(function () {
    'use strict';

    angular
        .module('app.book')
        .controller('BookController', Book);

    Book.$inject = ['bookApi', 'cookiesFactory', 'commonFactory'];

    function Book(bookApi, cookiesFactory, commonFactory) {
        var vm = this;
        vm.newBook = {};
        vm.books = [];
        vm.modalName = '#bookModal';

        vm.tempBook = {};
        vm.tempIndex = 0;
        vm.isNewBook = true;
        vm.title = '';

        vm.isbnRegex = '^(?:ISBN(?:-1[03])?:?\ )?(?=[0-9X]{10}$|(?=(?:[0-9]+[-\ ]){3})[-\ 0 - 9X]{13}$|97[89][0-9]{10}$|(?=(?:[0-9]+[-\ ]){4})[-\ 0-9]{17}$)(?:97[89][-\ ]?)?[0 - 9]{1,5}[-\ ]?[0 - 9]+[-\ ]?[0 - 9]+[-\ ]?[0 - 9X]$';
        
        vm.timelifeCookie = 30;
        vm.sortPredicateBook = cookiesFactory.get('predicate');
        vm.reverse = cookiesFactory.get('reverse') === 'true';

        vm.getBooks = function () {
            bookApi.getBooks()
                .then(function (data) {
                    vm.books = data;
                });
        };

        vm.addBook = function () {
            vm.tempBook = {};
            vm.isNewBook = true;
            vm.title = 'Add new book';
        };

        vm.editBook = function (book, index) {
            vm.tempBook = {};
            commonFactory.copyProperties(book, vm.tempBook);
            vm.isNewBook = false;
            vm.title = 'Edit book';
        };

        vm.saveBook = function () {
            if (vm.isNewBook) {
                bookApi.addBook(vm.tempBook)
                .then(function (response) {
                    vm.tempBook.id = response;
                    vm.books.push(vm.tempBook);
                    commonFactory.closeModal(vm.modalName);
                });
            } else {
                commonFactory.copyProperties(vm.tempBook, findById(vm.tempBook.id));
                bookApi.editBook(vm.tempBook)
                .then(function (data) {
                    commonFactory.closeModal(vm.modalName);
                });
            }
        };

        vm.deleteBook = function () {
            var index = vm.books.indexOf(findById(vm.tempBook.id));
            if (index > -1) { vm.books.splice(index, 1); }
            bookApi.deleteBook(vm.tempBook.id)
            .then(function (response) {
                commonFactory.closeModal(vm.modalName);
            });
        };

        vm.sort = function (column) {
            vm.sortPredicateBook = column;
            vm.reverse = !vm.reverse;
            cookiesFactory.put('reverse', vm.reverse, vm.timelifeCookie);
            cookiesFactory.put('predicate', vm.sortPredicateBook, vm.timelifeCookie);
        };

        vm.closeModal = function () {
            commonFactory.closeModal(vm.modalName);
        };

        function findById(id) {
            for (var i = 0; i < vm.books.length; i++) {
                if (vm.books[i].id == vm.tempBook.id) {
                    return vm.books[i];
                }
            }
        };
    }
})();
