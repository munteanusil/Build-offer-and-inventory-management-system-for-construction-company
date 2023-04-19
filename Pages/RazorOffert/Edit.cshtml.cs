using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CostControlApp.Models;

namespace CostControlApp.Pages.RazorOffer
{
    public class EditModel : PageModel
    {
        private readonly CostControlApp.Models.CreateOfferDbContext _context;

        public EditModel(CostControlApp.Models.CreateOfferDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Offertum Offertum { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Offerta == null)
            {
                return NotFound();
            }

            var offertum =  await _context.Offerta.FirstOrDefaultAsync(m => m.OfferId == id);
            if (offertum == null)
            {
                return NotFound();
            }
            Offertum = offertum;
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

            _context.Attach(Offertum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OffertumExists(Offertum.OfferId))
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

        private bool OffertumExists(int id)
        {
          return (_context.Offerta?.Any(e => e.OfferId == id)).GetValueOrDefault();
        }
    }
}
