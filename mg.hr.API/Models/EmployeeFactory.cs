using mg.hr.Core;

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
        /// <param name="contractType">Contract Type</param>
        /// <param name="employee">Employee details</param>
        /// <returns>Specific instance</returns>
        public static IEmployee Build(string contractType, Employee employee)
        {
            switch (contractType)
            {
                case "HourlySalaryEmployee":
                    return new HourlyEmployee(employee);
                case "MonthlySalaryEmployee":
                default:
                    return new MonthlyEmployee(employee);
            }
        }
    }
}
