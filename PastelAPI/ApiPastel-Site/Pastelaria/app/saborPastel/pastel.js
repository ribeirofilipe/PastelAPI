(function () {

    angular
        .module('pastelaria')
        .controller('PastelController', PastelController);

    PastelController.$inject = ['$scope', '$state', 'PastelService'];

    function PastelController($scope, $state, PastelService) {

        var vm = this;

        vm.pasteis = [];
        vm.criterioDeOrdenacao = "";

        vm.ordenarPor = ordenarPor;
        vm.excluir = excluir;
        vm.editar = editar;
        vm.deletarSelecionados = deletarSelecionados;

        init();

        function init() {
            getAllPasteis();
        }

        function getAllPasteis() {
            PastelService.getAll()
                .then(function (result) {
                    console.log(result);
                    vm.pasteis = result.data;
                })
                .catch(function (result) {
                    console.log(result);
                });
        }

        function ordenarPor(campo) {
            vm.criterioDeOrdenacao = campo;
            vm.direcaoDaOrdenacao = !vm.direcaoDaOrdenacao;
        }

        function excluir(idPastel) {
            if (confirm("Tem certeza que deseja excluir esse pastel?")) {
                PastelService.delet(idPastel)
                    .then(function () {
                        getAllPasteis();
                    })
                    .catch(function () {
                        console.log("Deu Ruim");
                    });
            }
        }

        function excluirTodos(idPastel) {
            PastelService.delet(idPastel)
                .then(function () {
                    getAllPasteis();
                })
                .catch(function () {
                    console.log("Deu Ruim");
                });
        }

        function editar(idPastel) {
            $state.go("alterar-pastel", { "pastelId": idPastel });
        }

        function deletarSelecionados() {
            if (confirm("Tem certeza que deseja excluir os pastéis selecionados?")) {
                vm.pasteis.forEach(element => {
                    if (element.selecionado) {
                        excluirTodos(element.Id);
                    }
                });
            }
        }

    }
})();