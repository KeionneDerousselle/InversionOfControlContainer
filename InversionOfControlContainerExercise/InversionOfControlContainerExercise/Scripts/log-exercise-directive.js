calorieTrackerApp.directive('logExerciseButton', function () {
    return {
        restrict: 'E',
        templateUrl: '/log/logExercise',
        controller: ['$scope', '$modal', function ($scope, $modal) {

            $scope.exercise =
                {
                    name: "",
                    calorieAmt: 0
                };
            $scope.openLogExerciseModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'LogExerciseModalTemplate.html',
                    controller: 'LogExerciseModalInstanceCtrl',
                    resolve:
                        {
                            exercise: function () {
                                return $scope.exercise;
                            }
                        }
                });

                modalInstance.result.then(function (exercise) {
                    console.log("Exercise Name : " + exercise.name + " Exercise Calorie Amount: " + exercise.calorieAmt);
                    $scope.LogExercise(exercise);
                });
            };
        }
        ]
    };
});

calorieTrackerApp.controller('LogExerciseModalInstanceCtrl', function ($scope, $modalInstance, exercise) {

    $scope.exercise = exercise;

    $scope.selected = {
        exercise:
            {
                name: $scope.exercise.name,
                calorieAmt: $scope.exercise.calorieAmt
            }
    };

    $scope.ok = function () {
        $modalInstance.close($scope.selected.exercise);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});