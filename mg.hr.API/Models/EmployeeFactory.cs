using mg.hr.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mg.hr.API.Models
{
    /// <summary>
    /// Employee factory 
    /// </summary>
    public static class EmployeeFactory
    {
        /// <summary>
        /// Determine what type of object to return
        /// </summary>
        /// <param name="contractType"></param>
        /// <returns></returns>
        public static IAnnualSalary Build(string contractType, Employee employee)
        {
            switch (contractType)
            {
                case "HourlySalaryEmployee":
                    return new HourlySalary(employee);
                case "MonthlySalaryEmployee":
                default:
                    return new MonthlySalary(employee);
            }
        }
    }
}
