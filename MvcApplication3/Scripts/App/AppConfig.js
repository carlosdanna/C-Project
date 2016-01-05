(function () {
    angular.module('myApp')
        .config(function ($stateProvider, $urlRouterProvider) {
            $stateProvider.state('app', {
                url: '/app',
                templateUrl: 'Scripts/App/App.tmpl.html',
                controller: 'appController',
                controllerAs: 'vm'
            });

            $urlRouterProvider.when('', 'app');
        })
})();