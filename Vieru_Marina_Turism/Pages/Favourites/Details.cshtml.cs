using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Vieru_Marina_Turism.Data;
using Vieru_Marina_Turism.Models;

namespace Vieru_Marina_Turism.Pages.Favourites
{
    public class DetailsModel : PageModel
    {
        private readonly Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext _context;

        public DetailsModel(Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext context)
        {
            _context = context;
        }

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
                .Include(f => f.Holiday)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (favourite == null)
            {
                return NotFound();
            }
            else 
            {
                Favourite = favourite;
                FullName = favourite.Member?.FullName ?? "N/A";
                HolidayDestinations = favourite.Holiday?.Destinations ?? "N/A";
                    }
            return Page();
        }
    }
}
