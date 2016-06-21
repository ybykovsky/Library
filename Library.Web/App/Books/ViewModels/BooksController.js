angular.module('Books')
    .controller('BookController', function ($scope, $http) {
        $scope.message = 'Books controller'

        $scope.books = [{ Title: 'Title 1' }, { Title: 'Title 2' }]

        $scope.getAll = function () {
            $http.get('/api/Book').success(function (data) {
                alert(111);
            });
        }

        $scope.getAll();
    });
