using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP4_Webservice.DataAccess;
using SEP4_Webservice.Model;

namespace SEP4_Webservice.Data
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeData dataAccess;

        private List<Employee> employees = new List<Employee>();

        public EmployeeService(EmployeeData dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            dataAccess.InsertEmployee(employee);
            return employee;
        }

        public async Task<IList<Employee>> GetEmployeesByName(string name)
        {
            employees = dataAccess.GetEmployeeByName(name);
            return employees;
        }
    }
}
