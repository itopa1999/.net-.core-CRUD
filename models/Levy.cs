using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;




namespace lucky_test_api.models
{
    public class Levy
    {
        public int Id { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal SchoolFee { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal DepartmentalFee { get; set; }

        // FK info
        public int? StudentId { get; set; }

        public Student? Student { get; set; }

    }
}