namespace mg.hr.API.Models
{
    public interface IEmployee
    {
        int id { get; }
        string name { get; }
        string roleName { get; }
        decimal AnnualSalary();
    }
}
