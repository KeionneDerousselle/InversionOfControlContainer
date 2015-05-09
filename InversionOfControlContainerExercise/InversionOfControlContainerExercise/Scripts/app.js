var calorieTrackerApp = angular.module('calorieTrackerApp', ['ui.bootstrap', 'ui.router'])
.config(['$locationProvider', '$stateProvider', '$urlRouterProvider',function ($locationProvider, $stateProvider, $urlRouterProvider) {

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });

    $urlRouterProvider.otherwise("/myLog");

    $stateProvider
    .state('app', {
        url: "",
        controller: "CalorieTrackerCtrl",
        templateUrl: "/shared/"
    })
    .state('app.manageLog', {
        url: "/myLog",
        controller: "MyLogCtrl",
        templateUrl: "/log/"
    });
}]);