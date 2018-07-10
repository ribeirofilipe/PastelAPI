(function () {

    angular.module('pastelaria')
        .factory("PastelService", PastelService);

        PastelService.$inject = ['$http', 'ApiSettingsConstant'];

    function PastelService($http, ApiSettingsConstant) {

        var baseUrl = ApiSettingsConstant.apiServiceBaseUri + "/produto";

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

        function post(pastel) {
            return $http.post(baseUrl, pastel);
        }

        function put(id, pastel) {
            return $http.put(baseUrl + "/" + id, pastel);
        }

        function delet(id) {
            return $http.delete(baseUrl + "/" + id);
        }
    }
    
})();