using DO1.Models.Resources;

namespace DO1.DTO
{
    public class StdWithDept
    {
        public int DeptId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Manager { get; set; }
        public IEnumerable<string> Students { get; set; }
    }
}
