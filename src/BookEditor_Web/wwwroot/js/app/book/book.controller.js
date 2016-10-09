(function () {
    'use strict';

    angular
        .module('app.book')
        .controller('BookController', Book);

    Book.$inject = ['bookApi', 'cookiesFactory', 'commonFactory', 'authorApi', 'shareService', 'toastr',];

    function Book(bookApi, cookiesFactory, commonFactory, authorApi, shareService, toastr) {
        var vm = this;
        vm.books = shareService.books;

        vm.tempImage = {};
        vm.tempBook = { authors: [] };
        vm.tempIndex = 0;
        vm.isNewBook = true;
        vm.title = '';

        vm.authors = shareService.authors;
        
        vm.isbnRegex = '^(?:ISBN(?:-1[03])?:?\ )?(?=[-0-9\ ]{17}$|[-0-9X\ ]{13}$|[0-9X]{10}$)(?:97[89][-\ ]?)?[0-9]{1,5}[-\ ]?(?:[0-9]+[-\ ]?){2}[0-9X]$';

        vm.timelifeCookie = 30;
        vm.sortPredicateBook = cookiesFactory.get('predicate');
        vm.reverse = cookiesFactory.get('reverse') === 'true';

        //get all books
        vm.getBooks = function () {
            bookApi.getBooks()
                .then(function (data) {
                    shareService.addBooks(data);
                });
        };

        //pre add book
        vm.addBook = function () {
            vm.tempBook = { authors: [] };
            vm.isNewBook = true;
            vm.title = 'Add new book';
        };

        //pre edit book
        vm.editBook = function (book) {
            vm.tempBook = { authors: [] };
            commonFactory.copyProperties(book, vm.tempBook);
            vm.isNewBook = false;
            vm.title = 'Edit book';
        };

        //insert or update book
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
                        shareService.addBook(vm.tempBook);
                        commonFactory.closeModal();
                    }
                });
            } else {
                shareService.editBook(vm.tempBook);
                bookApi.editBook(vm.tempBook)
                .then(function (data) {
                    if (!data)
                        toastr.error('Server error, try one more time', 'Error');
                    else {
                        commonFactory.closeModal();
                    }
                });
            }
        };

        //delete book
        vm.deleteBook = function () {
            shareService.deleteBook(vm.tempBook.id);
            bookApi.deleteBook(vm.tempBook.id)
            .then(function (response) {
                commonFactory.closeModal();
                toastr.success('Book deleted', '');
            });
        };

        //save sort to cookie
        vm.sort = function (column) {
            vm.sortPredicateBook = column;
            vm.reverse = !vm.reverse;
            cookiesFactory.put('reverse', vm.reverse, vm.timelifeCookie);
            cookiesFactory.put('predicate', vm.sortPredicateBook, vm.timelifeCookie);
        };

        //close modal
        vm.closeModal = function () {
            commonFactory.closeModal();
        };
    }
})();
