using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Crud.Employee.Api.Data.Interfaces;
using Crud.Employee.Shared;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Crud.Employee.Api.Data.Repositories
{
    public class EmployeeRepository<T> : IEmployeeRepository
    {
        #region Private Properties
        private static IMongoClient client;
        private static IMongoDatabase database;
        private IMongoCollection<BsonDocument> collection;
        #endregion

        #region Private Constants
        const string CONNECTION_STRING = "mongodb://user:password@ds056688.mongolab.com:56688/employeesdb";
        #endregion

        #region Constructor
        public EmployeeRepository() {
            client = new MongoClient(CONNECTION_STRING);
            database = client.GetDatabase("employeesdb");
            collection = database.GetCollection<BsonDocument>("employee");
        }
        #endregion

        #region Public Mehtods
        public IList<EmployeeViewModel> GetEmployeeList() {

            var filter = new BsonDocument();

            var employeesFound = collection.Find<BsonDocument>(filter).ToListAsync().Result;

            IList<EmployeeViewModel> employees = new List<EmployeeViewModel>();

            foreach (BsonDocument item in employeesFound)
            {
                EmployeeViewModel employee = new EmployeeViewModel();
                employee.Firstname = item.GetValue("firstname").ToString();
                employee.Lastname = item.GetValue("lastname").ToString();
                employee.Email = item.GetValue("email").ToString();
                employee.id = item.GetValue("_id").ToString();
                employees.Add(employee);

            }
            return employees;
        }

        public EmployeeViewModel FindByIdAsync(string id) 
        {
            var filter = new BsonDocument("_id", ObjectId.Parse(id));
            var result = collection.Find<BsonDocument>(filter).ToListAsync().Result;
            EmployeeViewModel employee = new EmployeeViewModel();
            employee.Firstname = result[0].GetValue("firstname").ToString();
            employee.Lastname = result[0].GetValue("lastname").ToString();
            employee.Email = result[0].GetValue("email").ToString();
            employee.id = result[0].GetValue("_id").ToString();

            return employee;
        }

        public async Task<IdentityResult> CreateAsync(EmployeeViewModel employeeModel) {


            BsonDocument bsonEmployee = new BsonDocument();
            bsonEmployee.Set("firstname", employeeModel.Firstname.ToString());
            bsonEmployee.Set("lastname", employeeModel.Lastname.ToString());
            bsonEmployee.Set("email", employeeModel.Email.ToString());
            await collection.InsertOneAsync(bsonEmployee);
            return IdentityResult.Success;
        }

       public async Task<IdentityResult> UpdateAsync(EmployeeViewModel employeeModel) 
        {
            //ask Hansel how to set properties of task

            BsonDocument bsonNewData = new BsonDocument();
            BsonDocument filter = new BsonDocument("_id", ObjectId.Parse(employeeModel.id));

            bsonNewData.Set("firstname", employeeModel.Firstname.ToString());
            bsonNewData.Set("lastname", employeeModel.Lastname.ToString());
            bsonNewData.Set("email", employeeModel.Email.ToString());
            await collection.FindOneAndReplaceAsync(filter, bsonNewData);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(string employeeId) {
            var filter = new BsonDocument("_id", ObjectId.Parse(employeeId));

            var result = await collection.DeleteOneAsync(filter);

            return IdentityResult.Success;
        }

        #endregion

    }
}
