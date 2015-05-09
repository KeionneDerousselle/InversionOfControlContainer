services.factory('Log', ['$resource',
    function ($resource) {
        return $resource('/log/:action', {},
         {
             'logAMeal': { method: 'POST', params: { action: 'logAMeal' } },
         });
    }]);