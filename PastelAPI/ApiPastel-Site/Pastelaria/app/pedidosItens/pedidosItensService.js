(function () {

    angular.module('pastelaria')
        .factory("PedidoItemService", PedidoItemService);

        PedidoItemService.$inject = ['$http', 'ApiSettingsConstant'];

    function PedidoItemService($http, ApiSettingsConstant) {

        var baseUrl = ApiSettingsConstant.apiServiceBaseUri + "/pedidoItem";

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

        function post(pedidoItem) {
            return $http.post(baseUrl, pedidoItem);
        }

        function put(id, pedidoItem) {
            return $http.put(baseUrl + "/" + id, pedidoItem);
        }

        function delet(id) {
            return $http.delete(baseUrl + "/" + id);
        }
    }
    
})();