using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mg.hr.API.Models
{
    public class SalaryCalculatorFactory
    {
        public static SalaryCalculator CreateSalaryCalculator(string contractType)
        {
            SalaryCalculator salaryCalculator;

            if (contractType == "HourlySalaryEmployee")
            {
                salaryCalculator = new HourlySalaryCalculator();
            }
            else if (contractType == "MonthlySalaryEmployee")
            {
                salaryCalculator = new MonthlySalaryCalculator();
            }
            else
            {
                throw new NotSupportedException("No salary calculator found for contract type");
            }

            return salaryCalculator;
        }
    }
}
