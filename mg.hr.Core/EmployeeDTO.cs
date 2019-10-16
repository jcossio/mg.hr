using System;
using System.Collections.Generic;
using System.Text;

namespace mg.hr.Core
{
    /// <summary>
    /// DTO to pass to the UI
    /// </summary>
    public class EmployeeDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string roleName { get; set; }
        public decimal annualSalary { get; set; }
    }
}
