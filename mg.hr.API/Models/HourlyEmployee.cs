using mg.hr.Core;

namespace mg.hr.API.Models
{
    public class HourlyEmployee : IEmployee
    {
        private readonly Employee _employee;
        public int id { get => _employee.id; }
        public string name { get => _employee.name; }
        public string roleName { get => _employee.roleName; }

        public HourlyEmployee(Employee employee)
        {
            this._employee = employee;
        }
        public decimal AnnualSalary()
        {
            return 120 * _employee.hourlySalary * 12;
        }
    }
}
