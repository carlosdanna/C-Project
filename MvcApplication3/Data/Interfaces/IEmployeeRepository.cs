using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud.Employee.Shared;

namespace Crud.Employee.Api.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        IList<EmployeeViewModel> GetEmployeeList();

        EmployeeViewModel FindByIdAsync(string id);

        Task<IdentityResult> CreateAsync(EmployeeViewModel employeeModel);

        Task<IdentityResult> UpdateAsync(EmployeeViewModel employeeModel);

        Task<IdentityResult> DeleteAsync(string employeeId);

    }
}
