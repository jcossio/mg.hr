using mg.hr.Core;

namespace mg.hr.API.Models
{
    public class MonthlySalaryCalculator: SalaryCalculator
    {
        public override decimal AnnualSalaryFor(Employee employee)
        {
            return employee.monthlySalary * 12;
        }
    }
}
