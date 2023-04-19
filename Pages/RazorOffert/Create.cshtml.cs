using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CostControlApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CostControlApp.Pages.RazorOffer
{
    public class CreateModel : PageModel
    {
        private readonly CostControlApp.Models.CreateOfferDbContext _context;

        // new
        private readonly ManoperaDbContext _mn;

     // ce am introdus in constructor este un experiment manoperadbcontext si mn ultima varianta
        public CreateModel(CostControlApp.Models.CreateOfferDbContext context, ManoperaDbContext mn)
        {
            _context = context;
            _mn = mn;
         
        }

        //public IActionResult OnGet()
        //{
        //    return Page();
        //}

        [BindProperty]
        public Offertum Offertum { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Offerta == null || Offertum == null)
            {
                return Page();
            }

            _context.Offerta.Add(Offertum);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


        //new



        [BindProperty] //rand nou
        public IEnumerable<Foaie1> numemanopere { get; set; }

        public void OnGet()
        {
            if (_mn != null)
            {
                numemanopere = _mn.Foaie1s.ToList();
            }
        }  
    }
}
