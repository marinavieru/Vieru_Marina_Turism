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

namespace Vieru_Marina_Turism.Pages.Holidays
{
    public class CreateModel : PageModel
    {
        private readonly Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext _context;

        public CreateModel(Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var holidayList = _context.Holiday
                .Include(b => b.Destinations)
                .Select(x => new
                {
                    x.ID,
                    Holiday = x.Destinations + " - " + x.Flight
                });

            ViewData["FlightID"] = new SelectList(_context.Flight, "ID", "AirlineName");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Holiday Holiday { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Holiday == null || Holiday == null)
            {
                return Page();
            }
            _context.Holiday.Add(Holiday);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
