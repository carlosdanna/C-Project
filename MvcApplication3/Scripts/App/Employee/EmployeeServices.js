(function () {
    angular.module("EmployeeModule")
        .factory("EmployeeServices", EmployeeServices);

    function EmployeeServices($http, $q) {
        var EmployeeServices = {};

        var _getEmployee = function (params) {
            var deferred = $q.defer();
            $http.get('/Api/App/', {params: params}).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.resolve(data);
            });
            return deferred.promise;
        }

        var _getEmployees = function () {
            var deferred = $q.defer();
            $http.get('/Api/App').success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.resolve(data);
            });
            return deferred.promise;
        }

        var _createEmployee = function (data) {
            var deferred = $q.defer();
            $http.post('/Api/App',data).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.resolve(data);
            });
            return deferred.promise;
        }

        var _updateEmployee = function (params) {
            var deferred = $q.defer();

            $http.patch('/Api/App', params).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.resolve(data);
            });
            return deferred.promise;
        }

        var _deleteEmployee = function (params) {
            var deferred = $q.defer();
            console.log('Requesting Data...');
            $http.delete('/Api/App', {params: params}).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.resolve(data);
            });
            return deferred.promise;
        }

        EmployeeServices.GetEmployee = _getEmployee;
        EmployeeServices.GetEmployees = _getEmployees;
        EmployeeServices.CreateEmployee = _createEmployee;
        EmployeeServices.UpdateEmployee = _updateEmployee;
        EmployeeServices.DeleteEmployee = _deleteEmployee;



        return EmployeeServices;

    }
})();