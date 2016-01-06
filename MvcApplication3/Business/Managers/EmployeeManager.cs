using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Crud.Employee.Shared;
using Crud.Employee.Api.Business.Interfaces;
using Crud.Employee.Api.Data.Interfaces;

namespace Crud.Employee.Api.Business.Managers
{
    public class EmployeeManager
    {
        #region Private Fields

        IEmployeeRepository _employeeRepository = null;
        
        #endregion

        #region Constructor
       
        public EmployeeManager(IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;
        }

        #endregion

        #region Public Mehtods

        public IList<EmployeeViewModel> GetEmployeeList() 
        {
            IList<EmployeeViewModel> employeeList = _employeeRepository.GetEmployeeList();
            return employeeList;
        }

        public EmployeeViewModel FindByIdAsync(string id) {
            if (id == null) {
                throw new ArgumentNullException("id");
            }

            EmployeeViewModel employee = _employeeRepository.FindByIdAsync(id);
            return employee;

        }

        public async Task<IdentityResult> CreateAsync(EmployeeViewModel employeeModel)
        {
            await _employeeRepository.CreateAsync(employeeModel);
            return IdentityResult.Success;

        }

        public async Task<IdentityResult> UpdateAsync(EmployeeViewModel employeeModel) 
        {
            await _employeeRepository.UpdateAsync(employeeModel);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(string employeeId) {
            if (employeeId == null) {
                throw new ArgumentNullException("employeeId");
            }
            await _employeeRepository.DeleteAsync(employeeId);
            return IdentityResult.Success;
        }

        #endregion

        #region Private Mehtods

        #endregion

    }
}
