(function () {
    'use strict';

    angular
        .module('app.core')
        .service('shareService', shareService);

    shareService.$inject = ['commonFactory'];

    function shareService(commonFactory) {

        this.authors = [];

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
            var index = this.authors.indexOf(commonFactory.findById(this.authors, id));
            if (index > -1) { this.authors.splice(index, 1); }
        };
    }
})();