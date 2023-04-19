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
    public class IndexModel : PageModel
    {
        private readonly CostControlApp.Models.ManoperaDbContext _context;

        public IndexModel(CostControlApp.Models.ManoperaDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }

        public string UmSort { get; set; }

        public string EuroM2Sort { get; set; }

        public string CantitateSort { get; set; }

        public string TotalEur { get; set; }

        public string CurentFilter { get; set; }

        public string CurentSort { get; set; }


        public IList<Foaie1> Foaie1 { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            //if (_context.Foaie1s != null)
            //{
            //    Foaie1 = await _context.Foaie1s.ToListAsync();
            //}
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            UmSort = String.IsNullOrEmpty(sortOrder) ? "name_UM" : "";
            EuroM2Sort = String.IsNullOrEmpty(sortOrder) ? "name_euroM2" : "";
            CantitateSort = String.IsNullOrEmpty(sortOrder) ? "name_Cantitate" : "";
            TotalEur = String.IsNullOrEmpty(sortOrder) ? "name_TotalEur" : "";
            CurentFilter = searchString;



            IQueryable<Foaie1> manoperaTa = from f in _context.Foaie1s
                                            select f;

            if (!String .IsNullOrEmpty(searchString)) 
            {
                manoperaTa = manoperaTa.Where(s => s.Manopera.Contains(searchString));
            }





            switch (sortOrder)
            {
                case "name_desc":
                    manoperaTa = manoperaTa.OrderBy(f => f.Manopera);
                    break;
                case "name_UM":
                    manoperaTa = manoperaTa.OrderBy(f => f.Um);
                    break;
                case "name_euroM2":
                    manoperaTa = manoperaTa.OrderBy(f => f.EuroM2);
                    break;
                case "name_Cantitate":
                    manoperaTa = manoperaTa.OrderBy(f => f.Cantitate);
                    break;
                case "name_TotalEur":
                    manoperaTa = manoperaTa.OrderBy(f => f.TotalEur);
                    break;
            }

            Foaie1 = await manoperaTa.AsNoTracking().ToListAsync();
        }
    }
}
