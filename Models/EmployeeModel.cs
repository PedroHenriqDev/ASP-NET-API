using System.ComponentModel.DataAnnotations;
using WebApi.Enums;

 namespace WebApi.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DepartmentEnum Department { get; set; }
        public bool Active { get; set; }
        public ShiftEnum Shift { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateChange { get; set; } = DateTime.Now;
    }
}