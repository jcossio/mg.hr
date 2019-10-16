namespace mg.hr.da
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ContractType ContractType { get; set; }
        public int RoleId { get; set; }
        public decimal HourlySalary { get; set; }
        public decimal MonthlySalary { get; set; }
    }
}
