(function () {
    angular.module("EmployeeModule")
        .controller("employeeCreateController", ["EmployeeServices", "$state", function (EmployeeServices, $state) {
            vm = this;
            vm.employee = {};

            vm.initialize = function () {
                vm.employee = {
                    "firstname": "",
                    "lastname": "",
                    "email": ""
                };
            }

            vm.cancel = function () {
                $state.go('app.employee', '', { reload: true });
            }

            vm.createNewEmployee = function () {
                console.log(vm.employee);
                EmployeeServices.CreateEmployee(vm.employee).then(function (data) {
                    console.log(data);
                    $state.go("app.employee", '', { reload: true });
                });

            }
        }]);
})();