using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vieru_Marina_Turism.Data;
using Vieru_Marina_Turism.Models;

namespace Vieru_Marina_Turism.Pages.Holidays
{
    public class DeleteModel : PageModel
    {
        private readonly Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext _context;

        public DeleteModel(Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Holiday Holiday { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Holiday == null)
            {
                return NotFound();
            }

            var holiday = await _context.Holiday.FirstOrDefaultAsync(m => m.ID == id);

            if (holiday == null)
            {
                return NotFound();
            }
            else 
            {
                Holiday = holiday;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Holiday == null)
            {
                return NotFound();
            }
            var holiday = await _context.Holiday.FindAsync(id);

            if (holiday != null)
            {
                Holiday = holiday;
                _context.Holiday.Remove(Holiday);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
