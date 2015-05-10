calorieTrackerApp.controller('AuthenticationCtrl', function ($scope, Authentication) {
    console.log('authentication controller initialized');

    $scope.user =
        {
            name: "",
            gender: "",
            weight: "",
        };

    $scope.Register = function (user) {
        Authentication.register(user);
    };

    $scope.Login = function (user) {
        Authentication.login(user);
    };
});