services.factory('Authentication', ['$resource',
    function ($resource) {
        return $resource('/authentication/:action', {},
         {
             'login': { method: 'POST', params: { action: 'login' } },
             'register': { method: 'POST', params: { action: 'register' } },
         });
    }]);