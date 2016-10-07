(function () {
    'use strict';

    angular
        .module('app.books')
        .factory('booksApi', booksApi);

    booksApi.$inject = ['$http'];

    function booksApi($http) {
        var service = {
            getBooks: getBooks,
            getBook: getBook,
            addBook: addBook,
            updateBook: updateBook,
            deleteBook: deleteBook
        };

        return service;

        function getBooks() {
            return $http({
                url: "/api/Book",
                method: "GET",
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        function getBook(id) {
            return $http({
                url: "/api/Book/" + id,
                method: "GET",
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        function addBook(book) {
            return $http({
                url: "/api/Book",
                method: "POST",
                data: book
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        function updateBook(book) {
            return $http({
                url: "/api/Book",
                method: "POST",
                data: book
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        function deleteBook(id) {
            return $http({
                url: "/api/Book/" + id,
                method: "POST"
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };
    }
})();