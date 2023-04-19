using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CostControlApp.Data;
using CostControlApp.Models;

namespace CostControlApp.Pages.Identity
{
    public class CreateModel : PageModel
    {
        private readonly CostControlApp.Data.InventoryDbContext _context;

        public CreateModel(CostControlApp.Data.InventoryDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sheet1 Sheet1 { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TblUnitMaster == null || Sheet1 == null)
            {
                return Page();
            }

            _context.TblUnitMaster.Add(Sheet1);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
