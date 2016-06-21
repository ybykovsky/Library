var commonModule = angular.module('common', ['ngRoute']);
var mainModule = angular.module('main', ['common']);

mainModule.controller('HomeController', function ($scope) {
    $scope.appName = 'Library with Angular';
});