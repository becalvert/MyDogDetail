using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDogDetail.Models;

namespace MyDogDetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyDogDetailsController : ControllerBase
    {
        private readonly MyDogDetailContext _context;

        public MyDogDetailsController(MyDogDetailContext context)
        {
            _context = context;
        }

        // GET: api/MyDogDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogData>>> GetMyDogDetails()
        {
          if (_context.DogsData == null)
          {
              return NotFound();
          }
            return await _context.DogsData.ToListAsync();
        }

        // GET: api/MyDogDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DogData>> GetMyDogDetail(int id)
        {
          if (_context.DogsData == null)
          {
              return NotFound();
          }
            var myDogDetail = await _context.DogsData.FindAsync(id);

            if (myDogDetail == null)
            {
                return NotFound();
            }

            return myDogDetail;
        }

        // PUT: api/MyDogDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyDogDetail(int id, DogData myDogDetail)
        {
            if (id != myDogDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(myDogDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyDogDetailExists(id))
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

        // POST: api/MyDogDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DogData>> PostMyDogDetail(DogData myDogDetail)
        {
          if (_context.DogsData == null)
          {
              return Problem("Entity set 'MyDogDetailContext.myDogDetails'  is null.");
          }
            _context.DogsData.Add(myDogDetail);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetMyDogDetail", new { id = myDogDetail.Id }, myDogDetail);
            return CreatedAtAction(nameof(GetMyDogDetail), new { id = myDogDetail.Id }, myDogDetail);
        }

        // DELETE: api/MyDogDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyDogDetail(int id)
        {
            if (_context.DogsData == null)
            {
                return NotFound();
            }
            var myDogDetail = await _context.DogsData.FindAsync(id);
            if (myDogDetail == null)
            {
                return NotFound();
            }

            _context.DogsData.Remove(myDogDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyDogDetailExists(int id)
        {
            return (_context.DogsData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
