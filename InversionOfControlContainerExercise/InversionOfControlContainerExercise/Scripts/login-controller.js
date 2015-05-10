calorieTrackerApp.controller('LoginCtrl', function ($scope, Authentication) {
    console.log('login controller initialized');

    $scope.submitLogin = function () {
        $scope.Login($scope.user);
    };
});