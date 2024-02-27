using DO1.DTO;
using DO1.Interface;
using DO1.Models.Database;
using DO1.Models.Resources;
using Microsoft.EntityFrameworkCore;

namespace DO1.Repository
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly DO1Context db;

        public DepartmentRep(DO1Context db)
        {
            this.db = db;
        }
        public void Add(Department dept)
        {
            db.Departments.Add(dept);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = db.Departments.Find(id);
            db.Departments.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<StdWithDept> GetAllData()
        {
            var dept = db.Departments.Include(a => a.Student).Select(a => a);
            var deptWithStuds = new List<StdWithDept>();

            foreach (var d in dept)
            {
                deptWithStuds.Add(new StdWithDept
                {
                    DeptId = d.Dept_Id,
                    Name = d.Name,
                    Location = d.Location,
                    Manager = d.Manager,
                    Students = d.Student.Select(a => a.Name)
                });
            }

            return deptWithStuds;
        }


        public Department GetById(int id)
        {
            return db.Departments.FirstOrDefault(a => a.Dept_Id == id);
        }

        public Department GetByName(string name)
        {
            return db.Departments.FirstOrDefault(a => a.Name == name);
        }

        public void update(Department dept)
        {
            db.Update(dept);
            db.SaveChanges();
        }
    }
}
