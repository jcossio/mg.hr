using mg.hr.Core;

namespace mg.hr.API.Models
{
    public class HourlySalaryCalculator: SalaryCalculator
    {
        public override decimal AnnualSalaryFor(Employee employee)
        {
            return 120 * employee.hourlySalary * 12;
        }
    }
}
