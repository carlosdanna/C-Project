(function () {
    angular.module("EmployeeModule")
        .controller("employeeUpdateController", ["EmployeeServices", "$state",'$stateParams', function (EmployeeServices, $state, $stateParams) {
            vm = this;
            vm.employee = {};

            vm.initialize = function () {
                EmployeeServices.GetEmployee($stateParams).then(function (data) {
                    vm.employee = {
                        "id": data.id,
                        "firstname": data.Firstname,
                        "lastname": data.Lastname,
                        "email": data.Email
                    };
                });
            }


            vm.cancel = function () {
                $state.go('app.employee', '', { reload: true });
            }


            vm.updateEmployee = function() {
                console.log(vm.employee);
                
                EmployeeServices.UpdateEmployee(vm.employee).then(function (data) {
                    console.log(data);
                    $state.go("app.employee", '', { reload: true });
                });
            }




        }]);
})();