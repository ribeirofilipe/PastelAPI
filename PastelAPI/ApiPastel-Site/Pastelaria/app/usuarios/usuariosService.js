(function () {

    angular.module('pastelaria')
        .factory("UsuariosService", UsuariosService);

    UsuariosService.$inject = ['$http', 'ApiSettingsConstant'];

    function UsuariosService($http, ApiSettingsConstant) {

        var baseUrl = ApiSettingsConstant.apiServiceBaseUri + "/cliente";

        console.log(baseUrl);

        return {
            getAll: getAll,
            get: get,
            post: post,
            put: put,
            delet: delet
        };

        function getAll() {
            return $http.get(baseUrl);
        }

        function get(id) {
            return $http.get(baseUrl + "/" + id);
        }

        function post(usuario) {
            return $http.post(baseUrl, usuario);
        }

        function put(id, usuario) {
            return $http.put(baseUrl + "/" + id, usuario);
        }

        function delet(id) {
            return $http.delete(baseUrl + "/" + id);
        }
    }
    
})();