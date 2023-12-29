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
    public class IndexModel : PageModel
    {
        private readonly Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext _context;

        public IndexModel(Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext context)
        {
            _context = context;
        }

        public IList<Favourite> Favourite { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Favourite != null)
            {
                Favourite = await _context.Favourite
                .Include(f => f.Holiday)
                .Include(f => f.Member).ToListAsync();
            }
        }
    }
}
