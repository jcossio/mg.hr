using mg.hr.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mg.hr.API.Models
{
    public class HourlySalary : IAnnualSalary
    {
        private readonly Employee employee;

        public HourlySalary(Employee employee)
        {
            this.employee = employee;
        }
        public decimal GetAnnualSalary()
        {
            return 120 * employee.hourlySalary * 12;
        }
    }
}
