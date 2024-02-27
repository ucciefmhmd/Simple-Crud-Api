using DO1.Filters;
using DO1.Interface;
using DO1.Models.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRep deptRep;

        public DepartmentController(IDepartmentRep deptRep)
        {
            this.deptRep = deptRep;
        }

        [HttpGet]
        public IActionResult ShowAllData()
        {
            var model = deptRep.GetAllData();
            return Ok(model);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByID(int id)
        {
            var Departmentbyid = deptRep.GetById(id);
            return Ok(Departmentbyid);
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            var Department = deptRep.GetByName(name);

            if (Department == null)
            {
                return NotFound(new { Message = "Department Not Found" });
            }

            return Ok(Department);
        }

        [HttpPost]
        [LocationFilter]
        public IActionResult Create(Department Dept)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            deptRep.Add(Dept);

            return Ok(new { Message = "Department added successfully" });
        }

        [HttpPut("{id}")]
        [LocationFilter]
        public IActionResult Eidt([FromRoute] int id, [FromBody] Department updatedDept)
        {
            if (ModelState.IsValid)
            {

                Department oldData = deptRep.GetById(id);
                oldData.Location = updatedDept.Location;
                oldData.Name = updatedDept.Name;
                oldData.Manager = updatedDept.Manager;

                if (oldData == null)
                {
                    return NotFound(new { Message = "Department Not Found" });
                }

                deptRep.update(oldData);

                return Ok(new { Message = "Department Updated successfully" });
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            deptRep.Delete(id);
            return Ok();

        }
    }
}
