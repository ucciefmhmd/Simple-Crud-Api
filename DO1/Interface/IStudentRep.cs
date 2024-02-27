using DO1.Models.Resources;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DO1.Interface
{
    public interface IStudentRep
    {
        IEnumerable<Student> GetAllData();
        Student GetById(int id);
        Student GetByName(string name);
        void Add(Student std);
        void update(Student std);
        void Delete(int id);
    }
}
