(function () {

    angular
        .module('pastelaria')
        .controller('PedidoItemCtrl', PedidoItemCtrl);

    PedidoItemCtrl.$inject = ['$scope', '$state', 'PedidoItemService', 'PastelService', 'PedidosService'];

    function PedidoItemCtrl($scope, $state, PedidoItemService, PastelService, PedidosService) {

        var vm = this;

        vm.criterioDeOrdenacao = "";
        vm.ordenarPor = ordenarPor;
        vm.excluir = excluir;
        vm.editar = editar;

        init();

        vm.pedidosItens = [];
        vm.pasteis = [];
        vm.pedidos = [];
        
        function init() {
            getAllPedidosItens();
            getAllPasteis();      
            getAllPedidos();      
        }

        function getAllPasteis() {
            PastelService.getAll()
                .then(function (result) {
                    vm.pasteis = result.data;
                })
                .catch(function (error) {
                    console.log(error);
                });
        }

        function getAllPedidos() {
            PedidosService.getAll()
                .then(function (result) {
                    vm.pedidos = result.data;
                    console.log(result);
                })
                .catch(function (result) {
                    console.log(result);
                });
        } 

        function getAllPedidosItens() {
            PedidoItemService.getAll()
                .then(function (result) {
                    vm.pedidosItens = result.data;
                })
                .catch(function (error) {
                    console.log(error);
                });
        }

        function ordenarPor(campo) {
            vm.criterioDeOrdenacao = campo;
            vm.direcaoDaOrdenacao = !vm.direcaoDaOrdenacao;
        }

        function excluir(idPedidoItem) {
            if (confirm("Tem certeza que deseja excluir esse pedido com item?")) {
                PedidoItemService.delet(idPedidoItem)
                    .then(function () {
                        getAllPedidosItens();
                    })
                    .catch(function () {
                        console.log("Deu Ruim");
                    });
            }
        }

        function editar(idPedidoItem) {
            $state.go("alterar-pedidoItem", { "pedidoItemId": idPedidoItem });
        }

    }
})();