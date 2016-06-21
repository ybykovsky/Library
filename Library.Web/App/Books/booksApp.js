var bookModule = angular.module('Books', ['common'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/books', {
            templateUrl: '/app/books/views/bookList.html',
            controller: 'BookController'
        });

        $routeProvider.when('/books/details/:bookId', {
            templateUrl: '/app/books/views/bookDetails.html',
            controller: 'BookController'
        });

        $routeProvider.otherwise({ redirectTo: '/books' });
        $locationProvider.html5Mode(true);
    });