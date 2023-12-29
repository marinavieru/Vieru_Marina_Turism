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
    public class CreateModel : PageModel
    {
        private readonly Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext _context;

        public CreateModel(Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var memberList = _context.Member
                .Select(x => new
                {
                    x.ID,
                    MemberFullName = x.FullName
                });
            var holidayList = _context.Holiday
                .Select(x => new
                {
                    x.ID,
                    HolidayFullName = x.Destinations
                });
        ViewData["HolidayID"] = new SelectList(holidayList, "ID", "HolidayFullName");
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Favourite Favourite { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Favourite == null || Favourite == null)
            {
                return Page();
            }

            Favourite.Holiday = await _context.Holiday.FindAsync(Favourite.HolidayID);
            Favourite.Member = await _context.Member.FindAsync(Favourite.MemberID);
            
            _context.Favourite.Add(Favourite);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
