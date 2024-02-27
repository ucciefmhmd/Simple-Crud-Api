using DO1.Interface;
using DO1.Models.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRep stdRep;

        public StudentController(IStudentRep stdRep)
        {
            this.stdRep = stdRep;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(stdRep.GetAllData());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudentById(int id)
        {
            if (id == 0)
                return BadRequest();
            var model = stdRep.GetById(id);
            return Ok(model);
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetStudentByName(string name)
        {
            if (name is null)
                return BadRequest();
            var model = stdRep.GetByName(name);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            if(ModelState.IsValid)
            {
                stdRep.Add(std);
                return CreatedAtAction(nameof(GetStudentById) , "");
            }
            return BadRequest();
        }
        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Student updatedStudent)
        {
            if (ModelState.IsValid)
            {

                Student oldData = stdRep.GetById(id);
                oldData.Age = updatedStudent.Age;
                oldData.Name = updatedStudent.Name;
                oldData.Address = updatedStudent.Address;
                oldData.Image = updatedStudent.Image;

                if (oldData == null)
                {
                    return NotFound(new { Message = "Student Not Found" });
                }

                stdRep.update(oldData);

                return Ok(new { Message = "Student Updated successfully" });
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            stdRep.Delete(id);
            return Ok();

        }
    }
}
