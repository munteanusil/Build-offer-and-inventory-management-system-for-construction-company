using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CostControlApp.Models;

namespace CostControlApp.Pages.Foaiebuna
{
    public class DeleteModel : PageModel
    {
        private readonly CostControlApp.Models.ManoperaDbContext _context;

        public DeleteModel(CostControlApp.Models.ManoperaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Foaie1 Foaie1 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Foaie1s == null)
            {
                return NotFound();
            }

            var foaie1 = await _context.Foaie1s.FirstOrDefaultAsync(m => m.ManoperaId == id);

            if (foaie1 == null)
            {
                return NotFound();
            }
            else 
            {
                Foaie1 = foaie1;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Foaie1s == null)
            {
                return NotFound();
            }
            var foaie1 = await _context.Foaie1s.FindAsync(id);

            if (foaie1 != null)
            {
                Foaie1 = foaie1;
                _context.Foaie1s.Remove(Foaie1);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
