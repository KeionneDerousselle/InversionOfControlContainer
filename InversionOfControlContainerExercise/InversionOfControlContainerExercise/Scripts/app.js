var calorieTrackerApp = angular.module('calorieTrackerApp', ['ui.bootstrap', 'ui.router', 'calorieTrackerApp.services', 'calorieTrackerApp.directives', 'ngResource'])
.config(['$locationProvider', '$stateProvider', '$urlRouterProvider',function ($locationProvider, $stateProvider, $urlRouterProvider) {

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });

    $urlRouterProvider.otherwise("/calorieTracker/myLog");

    $stateProvider
    .state('app', {
        url: "/calorieTracker",
        controller: "CalorieTrackerCtrl",
        templateUrl: "/shared/"
    })
    .state('app.authentication', {
        url: "/authenticate",
        controller: "AuthenticationCtrl",
        templateUrl: "/authentication"
    })
    .state('app.authentication.login', {
        url: "/login",
        controller: "LoginCtrl",
        templateUrl:"/authentication/login"
    })
    .state('app.authentication.register', {
        url: "/register",
        controller: "RegisterCtrl",
        templateUrl: "/authentication/register"
    })
    .state('app.manageLog', {
        url: "/myLog",
        controller: "MyLogCtrl",
        templateUrl: "/log/"
    });
}]);