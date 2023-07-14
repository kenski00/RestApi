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
using System.Diagnostics;


namespace TodoApi.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class TelemController : ControllerBase
    {
        private readonly TelemContext _context;

        public TelemController(TelemContext context)
        {
            _context = context;

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
        public async Task<ActionResult<TelemItem>> GetTelemItem()
        {
           var TelemItem = await _context.TelemItems.OrderByDescending(i => i.Id).FirstAsync();

            if (TelemItem == null)
            {
                return NotFound();
            }

            return TelemItem;
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TelemItem>> GetTelemItem(long id)
        {
            var TelemItem = await _context.TelemItems.OrderByDescending(i => i.Id).FirstAsync();

            if (TelemItem == null)
            {
                return NotFound();
            }

            return TelemItem;
        }

        // PUT: api/Todo/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelemItem(long id, TelemItem TelemItem)
        {
            if (id != TelemItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(TelemItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TelemItems.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Todo
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TelemItem>> PostTelemItem(TelemItem TelemItem)
        {
            Debug.WriteLine("Test");
            _context.TelemItems.Add(TelemItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelemItem", new { id = TelemItem.Id }, TelemItem);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TelemItem>> DeleteTelemItem(long id)
        {
            var TelemItem = await _context.TelemItems.FindAsync(id);
            if (TelemItem == null)
            {
                return NotFound();
            }

            _context.TelemItems.Remove(TelemItem);
            await _context.SaveChangesAsync();

            return TelemItem;
        }

    /*
        private bool TelemItemExists(long id)
        {
            return _context.TelemItems.Any(e => e.Id == id);
        }
    */
    }
}
