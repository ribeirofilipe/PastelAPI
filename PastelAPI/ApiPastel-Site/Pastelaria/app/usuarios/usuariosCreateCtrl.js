(function () {
    angular
        .module('pastelaria')
        .controller('UsuariosCreateController', UsuariosCreateController);

    UsuariosCreateController.$inject = ['$scope', '$state', '$stateParams', 'UsuariosService'];

    function UsuariosCreateController($scope, $state, $stateParams, UsuariosService) {

        var vm = this;
        vm.titulo = "";
        
        vm.estado = "";
        vm.estados = {
            inserir: 1,
            editar: 2
        };

        vm.salvar = salvar;

        init();

        function init() {
            verificarEstadoTela($stateParams.usuarioId);
        }

        function verificarEstadoTela(idUsuario) {
            if (idUsuario) {
                getUsuario(idUsuario);
                vm.estado = vm.estados.editar;
                vm.titulo = "Editar Cliente";                
            }
            else {
                novoUsuario();
                vm.estado = vm.estados.inserir;
                vm.titulo = "Inserir Cliente";
            }
        }

        function getUsuario(idUsuario) {
            UsuariosService.get(idUsuario)
                .then(function (result) {
                    vm.usuario = result.data;
                })
                .catch(function (result) {
                    console.log(result.error);
                });
        }

        function novoUsuario() {
            vm.usuario = {
                id: 0
            };
        }

        function salvar(usuario, clean) {
            var acao = vm.estado == vm.estados.inserir ? insertUsuario : updateUsuario;
            return acao(usuario, clean);
        }

        function insertUsuario(usuario, clean) {
            UsuariosService.post(usuario)
                .then(function () {
                    if (clean) {
                        delete vm.usuario;
                        $scope.usuariosForm.$setUntouched();
                    }
                    else {
                        $state.go("usuarios");
                    }
                })
                .catch(function () {
                });
        }

        function updateUsuario(usuario) {
            UsuariosService.put(vm.usuario.Id, usuario)
                .then(function () {
                    delete vm.usuario;
                    $scope.usuariosForm.$setUntouched();
                    getPastel();
                })
                .catch(function () {
                    $state.go("usuarios");
                });
        }
    }

})();