(function () {
    'use strict'
    angular.module("EmployeeModule")
        .config(function ($stateProvider) {
            $stateProvider.state('app.employee', {
                url: '/employee',
                templateUrl: 'Scripts/App/Employee/view/view.employee.tmpl.html',
                controller: 'employeeViewController',
                controllerAs: 'vm'
            });

            $stateProvider.state('app.employee.create', {
                url: '/create',
                templateUrl: 'Scripts/App/Employee/create/create.employee.tmpl.html',
                controller: 'employeeCreateController',
                controllerAs: 'vm'
            });

            $stateProvider.state('app.employee.update', {
                url: '/update/:id',
                templateUrl: 'Scripts/App/Employee/update/update.employee.tmpl.html',
                controller: 'employeeUpdateController',
                controllerAs: 'vm'
            });

        });

})();