calorieTrackerApp.controller('RegisterCtrl', function ($scope, Authentication) {
    console.log('register controller initialized');

    $scope.submitRegister = function () {
        $scope.Register($scope.user);
    };
});