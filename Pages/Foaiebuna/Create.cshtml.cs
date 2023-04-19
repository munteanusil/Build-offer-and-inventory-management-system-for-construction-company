using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CostControlApp.Models;

namespace CostControlApp.Pages.Foaiebuna
{
    public class CreateModel : PageModel
    {
        private readonly CostControlApp.Models.ManoperaDbContext _context;

        public CreateModel(CostControlApp.Models.ManoperaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Foaie1 Foaie1 { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Foaie1s == null || Foaie1 == null)
            {
                return Page();
            }

            _context.Foaie1s.Add(Foaie1);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
