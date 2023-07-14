using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TodoApi.Models;


namespace TodoApi.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class TelemConfigController : Controller
    {
        //private readonly TelemContext _context;

        public TelemConfigController(TelemContext context)
        {
            //  _context = context;

            /*
            if (_context.TelemItems.Count() == 0)
            {
                _context.TelemItems.Add(new TelemItem { Name = "Item1" });
                _context.SaveChanges();
            }
            */
        }

        // GET: api/Todo
        [HttpGet]
        public  ActionResult<IEnumerable<string>> GetTelemConfig()
        {

                return new string[] {"String1", "String2", "String3"};
        }

    }
}