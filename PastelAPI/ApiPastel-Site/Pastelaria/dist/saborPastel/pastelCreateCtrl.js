(function () {
    angular
        .module('pastelaria')
        .controller('PastelCreateController', PastelCreateController);

        PastelCreateController.$inject = ['$scope', '$state', '$stateParams', 'PastelService'];

    function PastelCreateController($scope, $state, $stateParams, PastelService) {

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
            verificarEstadoTela($stateParams.pastelId);
        }

        function verificarEstadoTela(idPastel) {
            if (idPastel) {
                getPastel(idPastel);
                vm.estado = vm.estados.editar;
                vm.titulo = "Editar Pastel";                
            }
            else {
                novoPastel();
                vm.estado = vm.estados.inserir;
                vm.titulo = "Inserir Pastel";
            }
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

        function novoPastel() {
            vm.pastel = {
                id: 0
            };
        }

        function salvar(pastel, clean) {
            var acao = vm.estado == vm.estados.inserir ? insertPastel : updatePastel;
            return acao(pastel, clean);
        }

        function insertPastel(pastel, clean) {
            PastelService.post(pastel)
                .then(function () {
                    if (clean) {
                        delete vm.pastel;
                        $scope.pastelForm.$setUntouched();
                    }
                    else {
                        $state.go("pasteis");
                    }
                })
                .catch(function () {
                });
        }

        function updatePastel(pastel) {
            PastelService.put(vm.pastel.Id, pastel)
                .then(function () {
                    delete vm.pastel;
                    $scope.pastelForm.$setUntouched();
                    getPastel();
                })
                .catch(function () {
                    $state.go("pasteis");
                });
        }
    }

})();