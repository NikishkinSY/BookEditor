(function () {
    'use strict';

    angular
        .module('app.book')
        .controller('BookController', Book);

    Book.$inject = ['bookApi', 'cookiesFactory', 'commonFactory', 'authorApi', 'shareService', 'toastr', '$scope'];

    function Book(bookApi, cookiesFactory, commonFactory, authorApi, shareService, toastr, $scope) {
        var vm = this;

        //all books and authors for all controllers
        vm.books = shareService.books;
        vm.authors = shareService.authors;

        //temp book for edit and add
        vm.tempBook = { authors: [] };
        //flag for new or edit book
        vm.isNewBook = true;
        //changable title for modal window
        vm.title = '';
        
        //regex for ISBN
        vm.isbnRegex = '^(?:ISBN(?:-1[03])?:?\ )?(?=[-0-9\ ]{17}$|[-0-9X\ ]{13}$|[0-9X]{10}$)(?:97[89][-\ ]?)?[0-9]{1,5}[-\ ]?(?:[0-9]+[-\ ]?){2}[0-9X]$';

        //cookie settings
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
            makeValidation();
            vm.isNewBook = true;
            vm.title = 'Add new book';
        };

        //pre edit book
        vm.editBook = function (book) {
            vm.tempBook = { authors: [] };
            commonFactory.copyProperties(book, vm.tempBook);
            makeValidation();
            vm.selectedAuthors = 
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
                        toastr.success('Book added', '');
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
                        toastr.success('Book edited', '');
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

        //validation for input select authors
        vm.selectAuthorsEvents = {
            onUnselectAll: function (item) {
                makeValidation();
            },
            onSelectAll: function (item) {
                makeValidation();
            },
            onItemSelect: function (item) {
                makeValidation();
            },
            onItemDeselect: function (item) {
                makeValidation();
            }
        };
        function makeValidation() {
            $scope.formBookModal.selectedAuthors.$setValidity("atLeastOne", vm.tempBook.authors.length > 0);
        };
    }
})();
