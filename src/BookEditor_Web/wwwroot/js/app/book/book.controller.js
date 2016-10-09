(function () {
    'use strict';

    angular
        .module('app.book')
        .controller('BookController', Book);

    Book.$inject = ['bookApi', 'cookiesFactory', 'commonFactory', 'authorApi', 'shareService', 'toastr',];

    function Book(bookApi, cookiesFactory, commonFactory, authorApi, shareService, toastr) {
        var vm = this;
        vm.books = [];
        vm.modalName = '#bookModal';

        vm.tempBook = { authors: [], base64Image: {} };
        vm.tempIndex = 0;
        vm.isNewBook = true;
        vm.title = '';

        vm.authors = shareService.authors;
        
        vm.isbnRegex = '^(?:ISBN(?:-1[03])?:?\ )?(?=[-0-9\ ]{17}$|[-0-9X\ ]{13}$|[0-9X]{10}$)(?:97[89][-\ ]?)?[0-9]{1,5}[-\ ]?(?:[0-9]+[-\ ]?){2}[0-9X]$';

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
            vm.tempBook = { authors: [], base64Image: {} };
            vm.isNewBook = true;
            vm.title = 'Add new book';
        };

        vm.editBook = function (book) {
            vm.tempBook = { authors: [], base64Image: {} };
            commonFactory.copyProperties(book, vm.tempBook);
            vm.isNewBook = false;
            vm.title = 'Edit book';
        };

        vm.saveBook = function (valid) {
            if (!valid)
                return;

            if (vm.isNewBook) {
                bookApi.addBook(vm.tempBook)
                .then(function (response) {
                    if (response < 0)
                        toastr.error('Server error, try one more time', 'Error');
                    else {
                        vm.tempBook.id = response;
                        vm.books.push(vm.tempBook);
                        commonFactory.closeModal(vm.modalName);
                    }
                });
            } else {
                commonFactory.copyProperties(vm.tempBook, commonFactory.findById(vm.books, vm.tempBook.id));
                bookApi.editBook(vm.tempBook)
                .then(function (data) {
                    if (!data)
                        toastr.error('Server error, try one more time', 'Error');
                    else {
                        commonFactory.closeModal(vm.modalName);
                    }
                });
            }
        };

        vm.deleteBook = function () {
            var index = vm.books.indexOf(commonFactory.findById(vm.books, vm.tempBook.id));
            if (index > -1) { vm.books.splice(index, 1); }
            bookApi.deleteBook(vm.tempBook.id)
            .then(function (response) {
                commonFactory.closeModal(vm.modalName);
                toastr.success('Book deleted', '');
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
    }
})();
