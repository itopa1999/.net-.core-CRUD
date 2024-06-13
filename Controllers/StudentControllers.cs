using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lucky_test_api.Data;
using lucky_test_api.Mappers;
using Microsoft.AspNetCore.Mvc;
using lucky_test_api.Dtos.Student;



namespace lucky_test_api.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentControllers : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StudentControllers(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll(){
            var students = _context.Student.ToList()
            .Select(s => s.ToStudentDto());

            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            var student = _context.Student.Find(id);

            if (student == null){
                return NotFound();
            }
            return Ok(student.ToStudentDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStudentRequest StudentDto){
            var studentModel = StudentDto.ToStudentFromCreateDTO();
            _context.Student.Add(studentModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = studentModel.Id}, studentModel.ToStudentDto());
        }
    }
}