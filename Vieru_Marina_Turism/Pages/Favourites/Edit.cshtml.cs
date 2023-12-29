using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vieru_Marina_Turism.Data;
using Vieru_Marina_Turism.Models;

namespace Vieru_Marina_Turism.Pages.Favourites
{
    public class EditModel : PageModel
    {
        private readonly Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext _context;

        public EditModel(Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Favourite Favourite { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Favourite == null)
            {
                return NotFound();
            }

            //var favourite =  await _context.Favourite.FirstOrDefaultAsync(m => m.ID == id);
            Favourite = await _context.Favourite
                 .Include(f => f.Holiday)
                 .ThenInclude(b => b.Destinations)
                 .Include(f => f.Member)
                 .FirstOrDefaultAsync(m => m.ID == id);
            if (Favourite == null)
            {
                return NotFound();
            }
            //Favourite = favourite;
            //ViewData["HolidayID"] = new SelectList(_context.Holiday, "ID", "ID");
            //ViewData["MemberID"] = new SelectList(_context.Member, "ID", "ID");
            var holidayList = _context.Holiday
                .Include(b => b.Destinations)
                .Select(x => new
                {
                    x.ID,
                    HolidayFullName = x.Destinations 
                    
                });
            ViewData["HolidayID"] = new SelectList(holidayList, "ID", "HolidayFullName");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Favourite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavouriteExists(Favourite.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FavouriteExists(int id)
        {
          return (_context.Favourite?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
