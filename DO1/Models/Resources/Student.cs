using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DO1.Models.Resources
{
    [Table("Student")]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    }
}
