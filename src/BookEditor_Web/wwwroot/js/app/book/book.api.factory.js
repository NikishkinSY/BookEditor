(function () {
    'use strict';

    angular
        .module('app.book')
        .factory('bookApi', bookApi);

    bookApi.$inject = ['$http'];

    function bookApi($http) {
        var service = {
            getBooks: getBooks,
            getBook: getBook,
            addBook: addBook,
            editBook: editBook,
            deleteBook: deleteBook
        };

        return service;

        function getBooks() {
            return $http({
                url: "/book/get",
                method: "GET",
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        function getBook(id) {
            return $http({
                url: "/book/" + id,
                method: "GET",
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        function addBook(book) {
            return $http({
                url: "/book/add",
                method: "POST",
                data: book
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        function editBook(book) {
            return $http({
                url: "/book/edit",
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
                url: "/book/delete/" + id,
                method: "POST"
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };
    }
})();