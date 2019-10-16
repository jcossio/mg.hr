namespace mg.hr.Core
{
    /// <summary>
    /// Employee class that maps to the API data source
    /// </summary>
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string contractTypeName { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
        public decimal hourlySalary { get; set; }
        public decimal monthlySalary { get; set; }
    }
}
