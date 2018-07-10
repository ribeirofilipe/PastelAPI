(function () {
    angular
        .module('pastelaria')
        .controller('PedidoItemCreateCtrl', PedidoItemCreateCtrl);

        PedidoItemCreateCtrl.$inject = ['$scope', '$state', '$stateParams', 'PedidoItemService', 'PedidosService', 'PastelService'];

    function PedidoItemCreateCtrl($scope, $state, $stateParams, PedidoItemService, PedidosService, PastelService) {

        var vm = this;
        vm.titulo = "";
        vm.pedidos = [];
        vm.pasteis = [];

        vm.estado = "";
        vm.estados = {
            inserir: 1,
            editar: 2
        };

        vm.salvar = salvar;

        init();

        function init() {
            verificarEstadoTela($stateParams.pedidoItemId);
            getAllPedidos();
            getAllPasteis();         
            
        }

        function getAllPedidos() {
            PedidosService.getAll()
                .then(function (result) {
                    vm.pedidos = result.data;
                })
                .catch(function (result) {
                    console.log(result);
                });
        } 

        function getAllPasteis() {
            PastelService.getAll()
                .then(function (result) {
                    vm.pasteis = result.data;
                })
                .catch(function (result) {
                    console.log(result);
                });
        }


        function verificarEstadoTela(idPedidoItem) {
            if (idPedidoItem) {
                getPedidoItem(idPedidoItem);
                vm.estado = vm.estados.editar;
                vm.titulo = "Editar Pedido Item";                
            }
            else {
                novoPedidoItem();
                vm.estado = vm.estados.inserir;
                vm.titulo = "Inserir Pedido Item";
            }
        }

        function getPedidoItem(idPedidoItem) {
            PedidoItemService.get(idPedidoItem)
                .then(function (result) {
                    vm.pedidoItem = result.data;                    
                })
                .catch(function (result) {
                    console.log(result.error);
                });
        }

        function novoPedidoItem() {
            vm.pedidoItem = {
                id: 0
            };
        }

        function salvar(pedidoItem, clean) {
            var acao = vm.estado == vm.estados.inserir ? InsertPedidoItem : UpdatePedidoItem;
            return acao(pedidoItem, clean);
            
        }

        function InsertPedidoItem(pedidoItem, clean) { 
            PedidoItemService.post(pedidoItem)
                .then(function () {
                    if (clean) {
                        delete vm.pedidoItem;
                        $scope.pedidoItemForm.$setUntouched();
                    }
                    else {
                        $state.go("pedidosItens");
                    }
                })
                .catch(function () {
                });
        }

        function UpdatePedidoItem(pedidoItem) {            
            PedidoItemService.put(vm.pedidoItem.Id, pedidoItem)
                .then(function () {
                    delete vm.pedidoItem;
                    $scope.pedidoItemForm.$setUntouched();
                    getPedidoItem();
                })
                .catch(function () {
                    $state.go("pedidosItens");
                });
        }
    }

})();