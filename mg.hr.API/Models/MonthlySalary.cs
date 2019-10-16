using mg.hr.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mg.hr.API.Models
{
    public class MonthlySalary : IAnnualSalary
    {
        private readonly Employee employee;

        public MonthlySalary(Employee employee)
        {
            this.employee = employee;
        }
        public decimal GetAnnualSalary()
        {
            return employee.monthlySalary * 12;
        }
    }
}
