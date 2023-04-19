using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CostControlApp.Data;
using CostControlApp.Models;

namespace CostControlApp.Pages.Identity
{
    public class DeleteModel : PageModel
    {
        private readonly CostControlApp.Data.InventoryDbContext _context;

        public DeleteModel(CostControlApp.Data.InventoryDbContext context)
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

            var sheet1 = await _context.TblUnitMaster.FirstOrDefaultAsync(m => m.ItemId == id);

            if (sheet1 == null)
            {
                return NotFound();
            }
            else 
            {
                Sheet1 = sheet1;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TblUnitMaster == null)
            {
                return NotFound();
            }
            var sheet1 = await _context.TblUnitMaster.FindAsync(id);

            if (sheet1 != null)
            {
                Sheet1 = sheet1;
                _context.TblUnitMaster.Remove(Sheet1);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
