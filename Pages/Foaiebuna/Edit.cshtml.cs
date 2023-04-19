using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CostControlApp.Models;

namespace CostControlApp.Pages.Foaiebuna
{
    public class EditModel : PageModel
    {
        private readonly CostControlApp.Models.ManoperaDbContext _context;

        public EditModel(CostControlApp.Models.ManoperaDbContext context)
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

            var foaie1 =  await _context.Foaie1s.FirstOrDefaultAsync(m => m.ManoperaId == id);
            if (foaie1 == null)
            {
                return NotFound();
            }
            Foaie1 = foaie1;
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

            _context.Attach(Foaie1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Foaie1Exists(Foaie1.ManoperaId))
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

        private bool Foaie1Exists(int id)
        {
          return (_context.Foaie1s?.Any(e => e.ManoperaId == id)).GetValueOrDefault();
        }
    }
}
