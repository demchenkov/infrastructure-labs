using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;


namespace Web.Controllers
{
    [Route("api/car-bodies")]
    [ApiController]
    public class CarBodiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarBodiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarBody>>> GetAll()
        {
            return await _context.CarBodies.ToListAsync();
        }

    }
}
