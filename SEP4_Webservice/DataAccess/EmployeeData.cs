using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SEP4_Webservice.Model;

namespace SEP4_Webservice.DataAccess
{
    public class EmployeeData
    {
        public List<Employee> GetEmployeeByName(string name)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                //var output = connection.Query<Employee>($"select * from Employee where Name='{ name }'").ToList();
                var output = connection.Query<Employee>("dbo.spEmployee_GetByName @Name", new { Name = name }).ToList();
                return output;
            }
        }

        public void InsertEmployee(Employee employee)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                Employee newEmployee = new Employee();
                newEmployee = employee;

                connection.Execute("dbo.spInsert_Employee @Gym_ID, @Name, @Password, @Address, @Email", newEmployee);
            }
        }
    }
}
