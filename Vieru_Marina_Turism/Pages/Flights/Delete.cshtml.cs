using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vieru_Marina_Turism.Data;
using Vieru_Marina_Turism.Models;

namespace Vieru_Marina_Turism.Pages.Flights
{
    public class DeleteModel : PageModel
    {
        private readonly Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext _context;

        public DeleteModel(Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Flight Flight { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Flight == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight.FirstOrDefaultAsync(m => m.ID == id);

            if (flight == null)
            {
                return NotFound();
            }
            else 
            {
                Flight = flight;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Flight == null)
            {
                return NotFound();
            }
            var flight = await _context.Flight.FindAsync(id);

            if (flight != null)
            {
                Flight = flight;
                _context.Flight.Remove(Flight);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
