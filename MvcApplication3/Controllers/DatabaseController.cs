using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MvcApplication3.Models.Employees;

namespace MvcApplication3.Controllers
{
    public class DatabaseController : Controller
    {

        public static IMongoClient _client;
        public static IMongoDatabase _database;
        private string DbConnectionString = 
            "mongodb://user:password@ds056688.mongolab.com:56688/employeesdb";
        protected IMongoCollection<BsonDocument> collection;

        public DatabaseController()
        {

            _client = new MongoClient(DbConnectionString);
            _database = _client.GetDatabase("employeesdb");

            //This function check if the database is connected
            _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait() ;

            collection = _database.GetCollection<BsonDocument>("employee");
        }

        public EmployeeVm GetEmployee(string id) {
            var filter = new BsonDocument("_id",ObjectId.Parse(id));
            var result = collection.Find<BsonDocument>(filter).ToListAsync().Result;
            EmployeeVm employee = new EmployeeVm();
            employee.Firstname = result[0].GetValue("firstname").ToString();
            employee.Lastname = result[0].GetValue("lastname").ToString();
            employee.Email = result[0].GetValue("email").ToString();
            employee.id = result[0].GetValue("_id").ToString();
            return employee;
        }

        public List<EmployeeVm> GetEmployees()
        {
            var filter = new BsonDocument();

            var employeesFound = collection.Find<BsonDocument>(filter).ToListAsync().Result;
            
            List<EmployeeVm> employees = new List<EmployeeVm>();
            
            foreach (BsonDocument item in employeesFound) {
                EmployeeVm employee = new EmployeeVm();
                employee.Firstname = item.GetValue("firstname").ToString();
                employee.Lastname = item.GetValue("lastname").ToString();
                employee.Email = item.GetValue("email").ToString();
                employee.id = item.GetValue("_id").ToString();
                employees.Add(employee);
            
            }
            return employees;

            
        }

        public void CreateEmployee(EmployeeVm employee){
            BsonDocument bsonEmployee = new BsonDocument();
            bsonEmployee.Set("firstname", employee.Firstname.ToString());
            bsonEmployee.Set("lastname", employee.Lastname.ToString());
            bsonEmployee.Set("email", employee.Email.ToString());
            collection.InsertOneAsync(bsonEmployee);

        }

        public void UpdateEmployee(EmployeeVm employee) {
            BsonDocument bsonNewData = new BsonDocument();
            BsonDocument filter = new BsonDocument("_id", ObjectId.Parse(employee.id));

            
            bsonNewData.Set("firstname", employee.Firstname.ToString());
            bsonNewData.Set("lastname", employee.Lastname.ToString());
            bsonNewData.Set("email", employee.Email.ToString());
            collection.FindOneAndReplaceAsync(filter, bsonNewData);
        }

        public void DeleteEmployee(string id)
        {
            var filter = new BsonDocument("_id",ObjectId.Parse(id));

            var result = collection.DeleteOneAsync(filter);
            
            
        }
    }
}
