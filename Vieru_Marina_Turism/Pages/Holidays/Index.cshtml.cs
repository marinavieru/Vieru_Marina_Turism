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
    public class IndexModel : PageModel
    {
        private readonly Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext _context;

        public IndexModel(Vieru_Marina_Turism.Data.Vieru_Marina_TurismContext context)
        {
            _context = context;
        }

        public IList<Holiday> Holiday { get;set; }

        public string PriceSort {  get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            if (_context.Holiday != null)
            {
                PriceSort = sortOrder == "price" ? "price_desc" : "price";

                CurrentFilter = searchString;

                Holiday = await _context.Holiday
                .Include(b => b.Flight)
                .ToListAsync();

                if(!String.IsNullOrEmpty(searchString))
                {
                    Holiday = Holiday.Where(s=>s.Destinations.Contains(searchString)).ToList();
                }
            }
            switch (sortOrder)
            {
                 case "price_desc":
                    Holiday = Holiday.OrderByDescending(s => s.Price).ToList();
                    break;
                default:
                    Holiday = Holiday.OrderBy(s => s.Price).ToList();
                    break;            
            }
        }
    }
}
