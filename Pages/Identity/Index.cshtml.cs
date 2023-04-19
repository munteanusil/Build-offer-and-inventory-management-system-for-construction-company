using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CostControlApp.Data;
using CostControlApp.Models;
using NuGet.Protocol.Core.Types;

namespace CostControlApp.Pages.Identity
{
    public class IndexModel : PageModel
    {
        private readonly CostControlApp.Data.InventoryDbContext _context;
        private object _configuration;

        public string CurrentFiltru { get; set; }
       

        public IndexModel(CostControlApp.Data.InventoryDbContext context)
        {
            _context = context;
        }

        
      

        public IList<Sheet1> Sheet1 { get;set; } = default!;
       

        public async Task OnGetAsync(string cautaString)
        {

            

            IQueryable<Sheet1> produsIQ = from s in _context.TblUnitMaster
                                          select s;

            if(!String.IsNullOrEmpty(cautaString))
             {
                produsIQ = produsIQ.Where(s => s.Denumire.Contains(cautaString));
            }

         


            if (_context.TblUnitMaster != null)
            {
                Sheet1 = await _context.TblUnitMaster.ToListAsync();


            }
            Sheet1 = await produsIQ.AsNoTracking().ToListAsync();

        }

    }
}
