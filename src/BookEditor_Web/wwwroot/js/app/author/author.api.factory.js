(function () {
    'use strict';

    angular
        .module('app.author')
        .factory('authorApi', authorApi);

    authorApi.$inject = ['$http'];

    function authorApi($http) {
        return {
            getAuthors: getAuthors,
            addAuthor: addAuthor,
            editAuthor: editAuthor,
            deleteAuthor: deleteAuthor
        };

        function getAuthors() {
            return $http({
                url: "/author/get",
                method: "GET",
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        //function getBook(id) {
        //    return $http({
        //        url: "/book/" + id,
        //        method: "GET",
        //    })
        //    .then(function (response) {
        //        return response.data;
        //    })
        //    .catch(console.log.bind(console));
        //};

        function addAuthor(author) {
            return $http({
                url: "/author/add",
                method: "POST",
                data: author
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        function editAuthor(author) {
            return $http({
                url: "/author/edit",
                method: "POST",
                data: author
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        function deleteAuthor(id) {
            return $http({
                url: "/author/delete/" + id,
                method: "POST"
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };
    }
})();