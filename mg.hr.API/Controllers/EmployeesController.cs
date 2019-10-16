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
        private readonly IEmployeeData employeeData;

        public EmployeesController(IEmployeeData employeeData)
        {
            this.employeeData = employeeData;
        }

        // GET: api/Employees/2
        [HttpGet("{id}", Name = "Get")]
        public IEnumerable<EmployeeDTO> Get(string id)
        {
            var employees = employeeData.GetEmployeesById(id);
            var employeesDTO = new List<EmployeeDTO>();

            // Process the information to use the Factory Pattern and return DTO
            foreach (var employee in employees)
            {
                employeesDTO.Add(new EmployeeDTO()
                {
                    id = employee.id,
                    name = employee.name,
                    roleName = employee.roleName,
                    annualSalary = EmployeeFactory.Build(employee.contractTypeName, employee).GetAnnualSalary()
                });
            }
            return employeesDTO;
        }

    }
}
