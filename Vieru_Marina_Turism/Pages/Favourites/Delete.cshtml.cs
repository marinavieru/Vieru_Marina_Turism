using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vieru_Marina_Turism.Data;
using Vieru_Marina_Turism.Models;

namespace Vieru_Marina_Turism.Pages.Favourites
{
    public class DeleteModel : PageModel
    {
        private readonly Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext _context;

        public DeleteModel(Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Favourite Favourite { get; set; } = default!;
        public string FullName { get; set; } = string.Empty;
        public string HolidayDestinations { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Favourite == null)
            {
                return NotFound();
            }

            var favourite = await _context.Favourite
                .Include(f => f.Member)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (favourite == null)
            {
                return NotFound();
            }
            else 
            {
                Favourite = favourite;
                FullName = favourite.Member?.FullName ?? "N/A";
                //fetch property
                var holiday = await _context.Holiday.FirstOrDefaultAsync(h => h.ID == favourite.HolidayID);
                HolidayDestinations = holiday != null ? holiday.Destinations : "N/A";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Favourite == null)
            {
                return NotFound();
            }
            var favourite = await _context.Favourite.FindAsync(id);

            if (favourite != null)
            {
                Favourite = favourite;
                _context.Favourite.Remove(Favourite);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
