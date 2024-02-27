using DO1.DTO;
using DO1.Models.Resources;

namespace DO1.Interface
{
    public interface IDepartmentRep
    {
        IEnumerable<StdWithDept> GetAllData();
        Department GetById(int id);
        Department GetByName(string name);
        void Add(Department dept);
        void update(Department dept);
        void Delete(int id);
    }
}
