(function () {
    angular
        .module('pastelaria')
        .controller('PedidoCreateCtrl', PedidoCreateCtrl);

    PedidoCreateCtrl.$inject = ['$scope', '$state', '$stateParams', 'PedidosService', 'UsuariosService', 'PastelService'];

    function PedidoCreateCtrl($scope, $state, $stateParams, PedidosService, UsuariosService, PastelService) {

        var vm = this;
        vm.titulo = "";
        vm.usuarios = [];
        vm.pasteis = [];

        vm.estado = "";
        vm.estados = {
            inserir: 1,
            editar: 2
        };

        vm.salvar = salvar;

        init();

        function init() {
            verificarEstadoTela($stateParams.pedidoId);
            getAllUsuarios();
            getAllPasteis();
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

        function getAllUsuarios() {
            UsuariosService.getAll()
                .then(function (result) {
                    vm.usuarios = result.data;
                })
                .catch(function (result) {
                    console.log(result);
                });
        }

        function verificarEstadoTela(idPedido) {
            if (idPedido) {
                getPedido(idPedido);
                getPastel(idPedido);
                vm.estado = vm.estados.editar;
                vm.titulo = "Editar Pedido";
            }
            else {
                novoPedido();
                vm.estado = vm.estados.inserir;
                vm.titulo = "Inserir Pedido";
            }
        }

        function getPedido(idPedido) {
            PedidosService.get(idPedido)
                .then(function (result) {
                    vm.pedido = result.data;
                })
                .catch(function (result) {
                    console.log(result.error);
                });
        }

        function getPastel(idPastel) {
            PastelService.get(idPastel)
                .then(function (result) {
                    vm.pastel = result.data;
                })
                .catch(function (result) {
                    console.log(result.error);
                }); 
        }

        function novoPedido() {
            vm.pedido = {
                id: 0
            };
        }

        function salvar(pedido, clean) {
            var acao = vm.estado == vm.estados.inserir ? insertPedido : updatePedido;

            return acao(pedido, clean);
        }

        function insertPedido(pedido, clean) {
            pedido.produtoId = pedido.Produto.Id;
            pedido.clienteId = pedido.Cliente.Id;
            PedidosService.post(pedido)
                .then(function () {
                    if (clean) {
                        delete vm.pedido;
                        $scope.pedidoForm.$setUntouched();
                    }
                    else {
                        $state.go("pedidos");
                    }
                })
                .catch(function () {
                });
        }

        function updatePedido(pedido) {
            PedidosService.put(vm.pedido.Id, pedido)
                .then(function () {
                    delete vm.pedido;
                    $scope.pedidoForm.$setUntouched();
                    getPedido();
                    getPastel();
                })
                .catch(function () {
                    $state.go("pedidos");
                });
        }
    }

})();