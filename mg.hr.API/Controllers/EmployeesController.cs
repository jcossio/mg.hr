using mg.hr.API.Models;
using mg.hr.Core;
using mg.hr.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace mg.hr.API.Controllers
{
    /// <summary>
    /// Web API controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeData _employeeData;
        /// <summary>
        /// Constructor used here to receive the data reference
        /// </summary>
        /// <param name="employeeData"></param>
        public EmployeesController(IEmployeeData employeeData)
        {
            this._employeeData = employeeData;
        }

        // GET: api/Employees/2
        [HttpGet("{id?}", Name = "Get")]
        public IEnumerable<EmployeeDTO> Get(string id = null)
        {
            // Retrieve the employees from data service
            var employees = _employeeData.GetEmployeesById(id);
            var employeesDTO = new List<EmployeeDTO>();

            // Process the information to use the Factory Pattern and return DTO
            foreach (var employee in employees)
            {
                var salaryCalculator = SalaryCalculatorFactory.CreateSalaryCalculator(employee.contractTypeName);
                employeesDTO.Add(new EmployeeDTO()
                {
                    id = employee.id,
                    name = employee.name,
                    roleName = employee.roleName,
                    annualSalary = salaryCalculator.AnnualSalaryFor(employee)
                });
            }
            return employeesDTO;
        }

    }
}
