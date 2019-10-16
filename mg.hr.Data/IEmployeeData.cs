using mg.hr.Core;
using System.Collections.Generic;

namespace mg.hr.Data
{
    /// <summary>
    /// Interface to be implemented by any data provider
    /// </summary>
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetEmployeesById(string id);
    }
}
