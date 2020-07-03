using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ThumbUp.Models;

namespace ThumbUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class LocalizationsController : ControllerBase
    {
        private readonly Context _context;

        public LocalizationsController(Context context)
        {
            _context = context;
        }

        // GET: api/Localizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localization>>> GetLocalizations()
        {
            return await _context.Localizations.Include(l => l.LocRatings).ToListAsync();
        }

        // GET: api/Localizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Localization>> GetLocalization(long id)
        {
            var localization = await _context.Localizations.FindAsync(id);

            if (localization == null)
            {
                return NotFound();
            }

            return localization;
        }

        // PUT: api/Localizations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalization(long id, Localization localization)
        {
            if (id != localization.LocID)
            {
                return BadRequest();
            }

            _context.Entry(localization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalizationExists(id))
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

        // POST: api/Localizations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Localization>> PostLocalization(Localization localization)
        {
            _context.Localizations.Add(localization);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetLocalization", new { id = localization.LocID }, localization);
            return CreatedAtAction(nameof(GetLocalization), new { id = localization.LocID }, localization);
        }

        // DELETE: api/Localizations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Localization>> DeleteLocalization(long id)
        {
            var localization = await _context.Localizations.FindAsync(id);
            if (localization == null)
            {
                return NotFound();
            }

            _context.Localizations.Remove(localization);
            await _context.SaveChangesAsync();

            return localization;
        }

        private bool LocalizationExists(long id)
        {
            return _context.Localizations.Any(e => e.LocID == id);
        }
    }
}
