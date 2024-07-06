using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lucky_test_api.Dtos.Student
{
    public class UpdateStudentRequest
    {
        public string FirstName { get; set; } =string.Empty;
        public string LastName { get; set; } =string.Empty;
        public string MatricNo { get; set; } = string.Empty;
    }
}