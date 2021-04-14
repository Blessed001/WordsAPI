using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WordsAPI.Data;
using WordsAPI.Models;

namespace WordsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController:ControllerBase
    {
        private readonly WordContext _context;

        public AuthorsController(WordContext context)
        {
            _context = context;
        }

        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _context.Authors.Include(a => a.Words).ToListAsync();
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var Author = await _context.Authors
                .Where(a => a.Id == id)
                .Include(a => a.Words).FirstOrDefaultAsync();

            if (Author == null)
            {
                return NotFound();
            }

            return Author;
        }

        // PUT: api/Author/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author Author)
        {
            if (id != Author.Id)
            {
                return BadRequest();
            }

            _context.Entry(Author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        // POST: api/Author
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author Author)
        {
            _context.Authors.Add(Author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = Author.Id }, Author);
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id)
        {
            var Author = await _context.Authors.FindAsync(id);
            if (Author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(Author);
            await _context.SaveChangesAsync();

            return Author;
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
