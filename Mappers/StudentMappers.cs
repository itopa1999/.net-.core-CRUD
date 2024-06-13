using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lucky_test_api.Dtos.Student;
using lucky_test_api.models;

namespace lucky_test_api.Mappers
{
    public static class StudentMappers
    {
        public static StudentDto ToStudentDto(this Student studentModel){
            return new StudentDto{
                LastName=studentModel.LastName,
                Id = studentModel.Id,
                MatricNo = studentModel.MatricNo,
                FirstName = studentModel.FirstName,
            };
        }

        public static Student ToStudentFromCreateDTO(this CreateStudentRequest studentDto){
            return new Student{
                LastName=studentDto.LastName,
                MatricNo = studentDto.MatricNo,
                FirstName = studentDto.FirstName,
            };
        }
    }
}