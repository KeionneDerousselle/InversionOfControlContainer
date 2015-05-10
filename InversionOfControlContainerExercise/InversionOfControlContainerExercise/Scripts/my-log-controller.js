calorieTrackerApp.controller('MyLogCtrl', function ($scope, Log) {
    console.log('my log controller initialized');

    $scope.LogExercise = function (exercise) {
        Log.logExercise(exercise);
    };

    $scope.LogAMeal = function (meal) {
        Log.logAMeal(meal);
    };
});