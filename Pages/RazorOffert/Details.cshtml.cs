using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CostControlApp.Models;

namespace CostControlApp.Pages.RazorOffer
{
    public class DetailsModel : PageModel
    {
        private readonly CostControlApp.Models.CreateOfferDbContext _context;

        public DetailsModel(CostControlApp.Models.CreateOfferDbContext context)
        {
            _context = context;
        }

      public Offertum Offertum { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Offerta == null)
            {
                return NotFound();
            }

            var offertum = await _context.Offerta.FirstOrDefaultAsync(m => m.OfferId == id);
            if (offertum == null)
            {
                return NotFound();
            }
            else 
            {
                Offertum = offertum;
            }
            return Page();
        }
    }
}
