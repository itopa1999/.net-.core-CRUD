using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lucky_test_api.models;


namespace lucky_test_api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }
        public  DbSet<Student> Student { get; set; }

        public  DbSet<Levy> Levy { get; set; }
    }
}