using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CostControlApp.Data;
using CostControlApp.Models;

namespace CostControlApp.Pages.Identity
{
    public class EditModel : PageModel
    {
        private readonly CostControlApp.Data.InventoryDbContext _context;

        public EditModel(CostControlApp.Data.InventoryDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sheet1 Sheet1 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TblUnitMaster == null)
            {
                return NotFound();
            }

            var sheet1 =  await _context.TblUnitMaster.FirstOrDefaultAsync(m => m.ItemId == id);
            if (sheet1 == null)
            {
                return NotFound();
            }
            Sheet1 = sheet1;
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

            _context.Attach(Sheet1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sheet1Exists(Sheet1.ItemId))
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

        private bool Sheet1Exists(int id)
        {
          return (_context.TblUnitMaster?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}
