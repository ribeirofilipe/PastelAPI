(function () {

    angular
        .module('pastelaria')
        .controller('Dashboard', Dashboard);

    Dashboard.$inject = ['$scope', '$state', 'PedidosService'];

    function Dashboard($scope, $state, PedidosService) {

        var vm = this;

        vm.pedidos = [];

        vm.estado = "";
        vm.estados = {
            inserir: 1,
            editar: 2
        };

        vm.criterioDeOrdenacao = "";
        vm.ordenarPor = ordenarPor;


        init();

        function init() {            
            getAllPedidos();
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

        function ordenarPor(campo) {
            vm.criterioDeOrdenacao = campo;
            vm.direcaoDaOrdenacao = !vm.direcaoDaOrdenacao;
        }       

    }
})();