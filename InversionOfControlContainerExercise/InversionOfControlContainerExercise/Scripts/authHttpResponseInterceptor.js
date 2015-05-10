calorieTrackerApp.factory('authHttpResponseInterceptor', ['$q', '$location', '$window', function ($q, $location, $window) {
    return {
        responseError: function (rejection) {
            if (rejection.status === 401 || rejection.status === 403) {
                $window.location.assign("/calorieTracker/authenticate");
            }
            else if (rejection.status === 500) {
                $window.location.assign("/calorieTracker/internalServerError");
            }
            return $q.reject(rejection);
        }
    }
}])
.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.interceptors.push('authHttpResponseInterceptor');
}]);