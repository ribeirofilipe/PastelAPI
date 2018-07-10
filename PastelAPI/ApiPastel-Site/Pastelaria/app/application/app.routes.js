(function () {
    angular
        .module('pastelaria')
        .config(Router);

    Router.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];

    function Router($stateProvider, $urlRouterProvider, $locationProvider) {

        $urlRouterProvider.otherwise('/dashboard');
        $locationProvider.hashPrefix('');

        $stateProvider
            .state('dashboard', {
                url: '/dashboard',
                templateUrl: 'dashboard/dashboard.html',
                controller: 'Dashboard',
                controllerAs: 'vm'
            })
            .state('usuarios', {
                url: '/usuarios',
                templateUrl: 'usuarios/usuarios.html',
                controller: 'UsuariosController',
                controllerAs: 'vm'
            })
            .state('inserir-usuario', {
                url: '/inserir-usuario',
                templateUrl: 'usuarios/usuariosCreate.html',
                controller: 'UsuariosCreateController',
                controllerAs: 'vm'
            })
            .state('alterar-usuario', {
                url: '/alterar-usuario/:usuarioId',
                templateUrl: 'usuarios/usuariosCreate.html',
                controller: 'UsuariosCreateController',
                controllerAs: 'vm'

            })
            .state('pasteis', {
                url: '/pasteis',
                templateUrl: 'saborPastel/pastel.html',
                controller: 'PastelController',
                controllerAs: 'vm'

            })
            .state('inserir-pastel', {
                url: '/inserir-pastel',
                templateUrl: 'saborPastel/pastelCreate.html',
                controller: 'PastelCreateController',
                controllerAs: 'vm'
            })
            .state('alterar-pastel', {
                url: '/alterar-pastel/:pastelId',
                templateUrl: 'saborPastel/pastelCreate.html',
                controller: 'PastelCreateController',
                controllerAs: 'vm'

            })
            .state('pedidos', {
                url: '/pedidos',
                templateUrl: 'pedidos/pedidos.html',
                controller: 'PedidoController',
                controllerAs: 'vm'

            })
            .state('inserir-pedido', {
                url: '/inserir-pedido',
                templateUrl: 'pedidos/pedidosCreate.html',
                controller: 'PedidoCreateCtrl',
                controllerAs: 'vm'
            })
            .state('alterar-pedido', {
                url: '/alterar-pedido/:pedidoId',
                templateUrl: 'pedidos/pedidosCreate.html',
                controller: 'PedidoCreateCtrl',
                controllerAs: 'vm'

            })
            .state('pedidosItens', {
                url: '/pedidosItens',
                templateUrl: 'pedidosItens/pedidosItens.html',
                controller: 'PedidoItemCtrl',
                controllerAs: 'vm'

            })
            .state('inserir-pedidoItem', {
                url: '/inserir-pedidoItem',
                templateUrl: 'pedidosItens/pedidosItensCreate.html',
                controller: 'PedidoItemCreateCtrl',
                controllerAs: 'vm'
            })
            .state('alterar-pedidoItem', {
                url: '/alterar-pedidoItem/:pedidoItemId',
                templateUrl: 'pedidosItens/pedidosItensCreate.html',
                controller: 'PedidoItemCreateCtrl',
                controllerAs: 'vm'

            });
    }

})();