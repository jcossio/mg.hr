using mg.hr.Core;

namespace mg.hr.API.Models
{
    public abstract class SalaryCalculator
    {
        public abstract decimal AnnualSalaryFor(Employee employee);
    }
}
