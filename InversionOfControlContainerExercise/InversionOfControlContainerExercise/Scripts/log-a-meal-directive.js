﻿transcriptionApp.directive('submitCourseButton', function () {
    return {
        restrict: 'E',
        templateUrl: 'views/Log/logAMeal.html',
        controller: ['$scope', 'Log', '$modal', function ($scope, Course, $modal) {

            $scope.meal =
                {
                    name: "",
                    calorieAmt:0
                };
            $scope.openLogMealModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'LogMealModalTemplate.html',
                    controller: 'LogMealModalInstanceCtrl',
                    resolve:
                        {
                            meal: function () {
                                return $scope.meal;
                            }
                        }
                });

                modalInstance.result.then(function (meal) {
                    console.log("Meal Name : " + meal.name + " Meal Calorie Amount: " + meal.calorieAmt);
                    $scope.LogAMeal(meal);
                });
            };
        }
        ]
    };
});

transcriptionApp.controller('LogMealModalInstanceCtrl', function ($scope, $modalInstance, meal) {

    $scope.meal = meal;

    $scope.selected = {
        meal: 
            {
                name: $scope.meal.name,
                calorieAmt: $scope.meal.calorieAmt
            }
    };

    $scope.ok = function () {
        $modalInstance.close($scope.selected.meal);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});