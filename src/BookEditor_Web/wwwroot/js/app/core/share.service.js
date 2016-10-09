// common place for books and authors arrays
(function () {
    'use strict';

    angular
        .module('app.core')
        .service('shareService', shareService);

    shareService.$inject = ['commonFactory'];

    function shareService(commonFactory) {

        this.authors = [];
        this.books = [];
        
        this.addAuthor = function (author) {
            author.fullName = author.firstName + ' ' + author.secondName;
            this.authors.push(author);
        };
        this.addAuthors = function (authors) {
            for (var i = 0; i < authors.length; i++) {
                this.addAuthor(authors[i]);
            }
        };
        this.deleteAuthor = function (id) {
            var result = removeItem(this.authors, id);
            if (result) {
                for (var i = 0; i < this.books.length; i++) {
                    for (var j = 0; j < this.books[i].authors.length; j++) {
                        if (this.books[i].authors[j].id == id) {
                            this.books[i].authors.splice(j, 1);
                        }
                    }
                }
            }
        };

        /////////////////////////////////////////////////////////////////////////
        this.addBook = function (book) {
            this.books.push(book);
        };
        this.addBooks = function (books) {
            for (var i = 0; i < books.length; i++) {
                this.addBook(books[i]);
            }
        };
        this.editBook = function (book) {
            commonFactory.copyProperties(book, commonFactory.findById(this.books, book.id));
        };
        this.deleteBook = function (id) {
            removeItem(this.books, id);
        };

        function removeItem(array, id) {
            var index = array.indexOf(commonFactory.findById(array, id));
            if (index > -1) { array.splice(index, 1); }
            return index > -1;
        };
    }
})();