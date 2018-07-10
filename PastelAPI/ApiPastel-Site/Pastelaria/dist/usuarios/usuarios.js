(function () {
    angular
        .module('pastelaria')
        .controller('UsuariosController', UsuariosController);

    UsuariosController.$inject = ['$scope', '$state', 'UsuariosService'];

    function UsuariosController($scope, $state, UsuariosService) {

        var vm = this;

        vm.usuarios = [];
        vm.criterioDeOrdenacao = "";
        vm.deletados = [];

        vm.ordenarPor = ordenarPor;
        vm.excluir = excluir;
        vm.editar = editar;
        vm.deletarSelecionados = deletarSelecionados;

        init();

        function init() {
            getAllUsuarios();
        }

        function deletarSelecionados() {
            if (confirm("Tem certeza que deseja excluir os usuários selecionados?")) {
                vm.usuarios.forEach(element => {
                    if (element.selecionado) {
                        excluirTodos(element.Id);
                    }
                });
            }
        }

        function getAllUsuarios() {
            UsuariosService.getAll()
                .then(function (result) {
                    console.log(result);
                    vm.usuarios = result.data;
                })
                .catch(function (result) {
                    console.log(result);
                });
        }

        function ordenarPor(campo) {
            vm.criterioDeOrdenacao = campo;
            vm.direcaoDaOrdenacao = !vm.direcaoDaOrdenacao;
        }

        function excluirTodos(idUsuario) {
            UsuariosService.delet(idUsuario)
                .then(function () {
                    getAllUsuarios();
                })
                .catch(function () {
                    console.log("Deu Ruim");
                });
        }

        function excluir(idUsuario) {
            if (confirm("Tem certeza que deseja excluir esse usuário?")) {
                UsuariosService.delet(idUsuario)
                    .then(function () {
                        getAllUsuarios();
                    })
                    .catch(function () {
                        console.log("Deu Ruim");
                    });
            }
        }

        function editar(idUsuario) {
            $state.go("alterar-usuario", { "usuarioId": idUsuario });
        }
    }

})();