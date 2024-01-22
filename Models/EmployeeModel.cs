using WebApi.Enums;

 namespace WebApi.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DepartmentEnum Department { get; set; }
        public bool Active { get; set; }
        public string Shift { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DateChange { get; set; } = DateTime.Now.ToLocalTime();
    }
}
