using Crud.Employee.Api.Business.Interfaces;
using Crud.Employee.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Crud.Employee.Api.Controllers
{
    
    public class EmployeeController : ApiController
    {
        #region Private Properties

        private readonly IEmployeeManager _employeeManager = null;
        
        #endregion

        #region Private Constants

        #endregion

        #region Constructor

        public EmployeeController(IEmployeeManager employeeManager) {
            _employeeManager = employeeManager;
        }

        #endregion

        #region Public Methods
        public IList<EmployeeViewModel> Get() 
        {
            var employeeList = _employeeManager.GetEmployeeList();
            return employeeList;
        }

        
        public EmployeeViewModel Get(string id) 
        {
            var employee = _employeeManager.FindByIdAsync(id);
            return employee;
        }

        public async Task<IdentityResult> Post(EmployeeViewModel employee)
        {
            return await _employeeManager.CreateAsync(employee); 
        }

        public async Task<IdentityResult> Patch(EmployeeViewModel employee)
        {
            return await _employeeManager.UpdateAsync(employee);
        }

        public async Task<IdentityResult> Delete(string id)
        {
            return await _employeeManager.DeleteAsync(id);
        }
        
        #endregion

    }
}
