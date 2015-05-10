services.factory('Authentication', ['$resource',
    function ($resource) {
        return $resource('/authentication/:action', {},
         {
             'login': { method: 'POST', params: { action: 'loginUser' } },
             'register': { method: 'POST', params: { action: 'registerUser' } },
         });
    }]);