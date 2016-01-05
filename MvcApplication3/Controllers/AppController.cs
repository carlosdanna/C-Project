using System.Threading;
using System.Web.Http;
using System.Web.Mvc;
using System.Collections.Generic;
using MvcApplication3.Models.Employees;
using MvcApplication3.Controllers;
using MongoDB.Bson;



namespace MvcApplication3.Controllers
{
    public class AppController : ApiController{

        private readonly DatabaseController db= new DatabaseController();
        


        public List<EmployeeVm> Get()
        {
            return db.GetEmployees();
        }
        
        
        public ActionResult Post(EmployeeVm data)
        { 
            
            db.CreateEmployee(data);
            return null;
        }

        public ActionResult Patch(EmployeeVm employee) {
            db.UpdateEmployee(employee);
            return null;
        }

        public EmployeeVm Get(string id)
        {
            return db.GetEmployee(id);
        }

        public ActionResult Delete(string id) 
        {
            db.DeleteEmployee(id);
            return null;
        }



    }
}
