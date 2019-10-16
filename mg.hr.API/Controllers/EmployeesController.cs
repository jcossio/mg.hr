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
                var specificEmployee = EmployeeFactory.Build(employee.contractTypeName, employee);
                employeesDTO.Add(new EmployeeDTO()
                {
                    id = specificEmployee.id,
                    name = specificEmployee.name,
                    roleName = specificEmployee.roleName,
                    annualSalary = specificEmployee.AnnualSalary()
                });
            }
            return employeesDTO;
        }

    }
}
