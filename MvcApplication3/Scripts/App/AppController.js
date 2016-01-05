(function () {
    angular.module('myApp')
        .controller("appController",["$state", function ($state) {
            var vm = this;
            vm.name = "AppController";
            vm.something = 'something';
            vm.employees = [];

            vm.otherfunction = function () {
                console.log('Carlos');
            }

           vm.initialize = function () {
               $state.go('app.employee');
            };

        }]);
})();