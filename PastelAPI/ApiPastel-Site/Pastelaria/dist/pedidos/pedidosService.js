(function () {

    angular.module('pastelaria')
        .factory("PedidosService", PedidosService);

        PedidosService.$inject = ['$http', 'ApiSettingsConstant'];

    function PedidosService($http, ApiSettingsConstant) {

        var baseUrl = ApiSettingsConstant.apiServiceBaseUri + "/pedido";

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

        function post(pedido) {
            return $http.post(baseUrl, pedido);
        }

        function put(id, pedido) {
            return $http.put(baseUrl + "/" + id, pedido);
        }

        function delet(id) {
            return $http.delete(baseUrl + "/" + id);
        }
    }
    
})();