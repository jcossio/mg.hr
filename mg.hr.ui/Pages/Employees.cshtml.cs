using mg.hr.Core;
using mg.hr.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace mg.hr.Pages
{
    public class EmployeesModel : PageModel
    {
        // Holds the pointer to the data source
        private readonly IEmployeeData employeeData;

        // Model exposed (output model)
        public IEnumerable<Employee> Employees { get; set; }

        // Model binding two ways (Here SearchText should receive info from the request). This property binds to the textbox on the view
        [BindProperty(SupportsGet =true)]
        public string SearchText { get; set; }

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
            Employees = employeeData.GetEmployeesById(SearchText);
        }
    }
}