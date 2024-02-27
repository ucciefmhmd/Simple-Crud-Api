using DO1.Interface;
using DO1.Models.Database;
using DO1.Models.Resources;

namespace DO1.Repository
{
    public class StudentRep : IStudentRep
    {
        private readonly DO1Context db;

        public StudentRep(DO1Context db)
        {
            this.db = db;
        }
        public void Add(Student std)
        {
            db.Students.Add(std);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = db.Students.Find(id);
            db.Students.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<Student> GetAllData()
        {
            return db.Students.Select(a => a);
        }

        public Student GetById(int id)
        {
            return db.Students.Find(id);
        }

        public Student GetByName(string name)
        {
            return db.Students.FirstOrDefault(a => a.Name == name);
        }

        public void update(Student std)
        {
            db.Students.Update(std);
            db.SaveChanges();
        }
    }
}
