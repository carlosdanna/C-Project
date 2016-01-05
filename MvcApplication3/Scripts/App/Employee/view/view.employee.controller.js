(function () {
    angular.module("EmployeeModule")
        .controller("employeeViewController", ["$state","EmployeeServices", function($state, EmployeeServices){
            vm = this;

            vm.name = "View Employees";

            vm.employees = [];
            
            
            vm.initialize = function(){
                vm.isView = true;
                EmployeeServices.GetEmployees().then(function (data) {
                    vm.employees = data;
                });

            }

            vm.goToCreateEmployee = function () {
                $state.go('app.employee.create');
                vm.isView = false;
            }

            vm.goToUpdateEmployee = function(params) {
                console.log(params);
                $state.go('app.employee.update', { id: params.id });
                vm.isView = false;
            }

            vm.deleteEmployee = function (params) {
                EmployeeServices.DeleteEmployee({id: params}).then(function (data) {
                    $state.go("app.employee", '', { reload: true });
                })
            }


        }]);
})();