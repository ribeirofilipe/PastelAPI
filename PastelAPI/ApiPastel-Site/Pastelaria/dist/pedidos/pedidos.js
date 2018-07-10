(function () {

    angular
        .module('pastelaria')
        .controller('PedidoController', PedidoController);

    PedidoController.$inject = ['$scope', '$state', 'PedidosService', 'UsuariosService'];

    function PedidoController($scope, $state, PedidosService, UsuariosService) {

        var vm = this;

        vm.pedidos = [];
        vm.usuarios = [];

        vm.criterioDeOrdenacao = "";

        vm.ordenarPor = ordenarPor;
        vm.excluir = excluir;
        vm.editar = editar;
        vm.deletarSelecionados = deletarSelecionados;

        init();

        function init() {
            getAllPedidos();   
            getAllUsuarios();   
        }
        
        function getAllUsuarios() {
            UsuariosService.getAll()
                .then(function (result) {
                    vm.usuarios = result.data;
                })
                .catch(function (result) {
                    console.log(result);
                });
        }

        function getAllPedidos() {
            PedidosService.getAll()
                .then(function (result) {
                    console.log(result);
                    vm.pedidos = result.data;
                    
                })
                .catch(function (result) {
                    console.log(result);
                });
        }        

        function ordenarPor(campo) {
            vm.criterioDeOrdenacao = campo;
            vm.direcaoDaOrdenacao = !vm.direcaoDaOrdenacao;
        }

        function excluir(idPedido) {
            if (confirm("Tem certeza que deseja excluir esse pedido?")) {
                PedidosService.delet(idPedido)
                    .then(function () {
                        getAllPedidos();
                    })
                    .catch(function () {
                        console.log("Deu Ruim");
                    });
            }
        }

        function excluirTodos(idPedido) {
            PedidosService.delet(idPedido)
                .then(function () {
                    getAllPedidos();
                })
                .catch(function () {
                    console.log("Deu Ruim");
                });
        }

        function editar(idPedido) {
            $state.go("alterar-pedido", { "pedidoId": idPedido });
        }

        function deletarSelecionados() {
            if (confirm("Tem certeza que deseja excluir os pedidos selecionados?")) {
                vm.pedidos.forEach(element => {
                    if (element.selecionado) {
                        excluirTodos(element.Id);
                    }
                });
            }
        }

    }
})();