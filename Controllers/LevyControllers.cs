using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lucky_test_api.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;



namespace lucky_test_api.Controllers
{
    [Route("api/levy")]
    [ApiController]
    public class LevyControllers : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public LevyControllers(ApplicationDBContext context){
            _context = context;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var levies = await _context.Levy.ToListAsync();

            return Ok(levies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var levy = await _context.Levy.FindAsync(id);

            return Ok(levy);

        }


        // [HttpPost]
        // public async Task<IActionResult> 
     
    }
}
