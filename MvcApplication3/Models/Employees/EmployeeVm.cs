using MongoDB.Bson;
using MongoDB.Driver;
namespace MvcApplication3.Models.Employees
{
    public class EmployeeVm
    {
        public string id { get; set; }
        public string Firstname {get;set;}
        public string Lastname { get; set; }
        public string Email { get; set; }

        public EmployeeVm() {
            Firstname = "";
            Lastname = "";
            Email = "";
        }

        public EmployeeVm(string _firstname, string _lastname, string _email){
            Firstname = _firstname;
            Lastname = _lastname;
            Email = _email;
        }

    }
}