using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO1.Models.Resources
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Dept_Id { get; set; }
        [Unique]
        public string Name { get; set; }
        public string Location { get; set; }
        [Required]
        public string Manager { get; set; }
        public virtual ICollection<Student> Student { get; } = new HashSet<Student>();
    }
}
