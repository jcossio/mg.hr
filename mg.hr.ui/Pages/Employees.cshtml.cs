using mg.hr.Core;
using mg.hr.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace mg.hr.Pages
{
    public class EmployeesModel : PageModel
    {
        // Holds the pointer to the data source
        private readonly IEmployeeData employeeData;

        // Model exposed
        public IEnumerable<Employee> Employees { get; set; }

        /// <summary>
        /// Constructor that injects the employee data
        /// </summary>
        /// <param name="employeeData">Employee data reference</param>
        public EmployeesModel(IEmployeeData employeeData)
        {
            this.employeeData = employeeData;
        }

        /// <summary>
        /// Get method for the page
        /// </summary>
        public void OnGet()
        {
            // Retrieve all the employees from the data source
            Employees = employeeData.GetAll();
        }
    }
}