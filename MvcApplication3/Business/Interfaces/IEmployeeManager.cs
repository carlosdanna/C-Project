using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Crud.Employee.Shared;

namespace Crud.Employee.Api.Business.Interfaces
{
    public interface IEmployeeManager 
    {
        IList<EmployeeViewModel> GetEmployeeList();
        
        EmployeeViewModel FindByIdAsync(string id);
        
        Task<IdentityResult> CreateAsync(EmployeeViewModel employeeModel);
        
        Task<IdentityResult> UpdateAsync(EmployeeViewModel employeeModel);
        
        Task<IdentityResult> DeleteAsync(string employeeId);

    }
}
