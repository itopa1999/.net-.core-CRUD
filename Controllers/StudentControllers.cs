using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lucky_test_api.Data;
using lucky_test_api.Mappers;
using Microsoft.AspNetCore.Mvc;
using lucky_test_api.Dtos.Student;
using Microsoft.EntityFrameworkCore;



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
        public async Task<IActionResult> GetAll(){
            var students = await _context.Student.ToListAsync();
            var studentDto = students.Select(s => s.ToStudentDto());

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var student =await _context.Student.FindAsync(id);

            if (student == null){
                return NotFound();
            }
            return Ok(student.ToStudentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentRequest StudentDto){
            var studentModel = StudentDto.ToStudentFromCreateDTO();
            await _context.Student.AddAsync(studentModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = studentModel.Id}, studentModel.ToStudentDto());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStudentRequest updateDto){

            var studentModel =await _context.Student.FirstOrDefaultAsync(x => x.Id == id);
            if (studentModel == null){
                return NotFound();
            }

            studentModel.FirstName = updateDto.FirstName;
            studentModel.LastName = updateDto.LastName;
            studentModel.MatricNo = updateDto.MatricNo;

            await _context.SaveChangesAsync();

            return Ok(studentModel.ToStudentDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var studentModel =await _context.Student.FirstOrDefaultAsync(x => x.Id == id);

            if (studentModel == null)
            {
                return NotFound();
            }
            _context.Student.Remove(studentModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("first")]
        public async Task<IActionResult> GetFirstStudent()
        {
            var student = await _context.Student.FirstOrDefaultAsync();
            return Ok(student);
        }
    }


}


