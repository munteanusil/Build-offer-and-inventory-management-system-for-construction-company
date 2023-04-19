using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CostControlApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json.Linq;

namespace CostControlApp.Pages.RazorOffer
{
    public class IndexModel : PageModel
    {
        private readonly CostControlApp.Models.CreateOfferDbContext _context;

        public IndexModel(CostControlApp.Models.CreateOfferDbContext context, IEnumerable<Foaie1> numemanopere)
        {
            _context = context;
            _numemanopere = numemanopere;
        }

        public  IEnumerable<Foaie1> _numemanopere;
        public IList<Offertum> Offertum { get; set; } = default!;

        public int TotalSum { get; set; }
       

        public async Task OnGetAsync()
        {
            if (_context.Offerta != null)
            {
                Offertum = await _context.Offerta.ToListAsync();
            }

            foreach (var Offertum in Offertum)
            {
                Offertum.Total = Offertum.Cantitatea * Offertum.EuroM2;
            }


            TotalSum = (int)Offertum.Sum(Offertum => Offertum.Total);


            // as mai putea folosi 
            //for (int i = 0; i < Offertum.Count; i++)
            //{
            //    Offertum[i].Total = Offertum[i].Cantitatea * Offertum[i].EuroM2;
            //}
        }

        public void OnPost()
        {
            _numemanopere = Request.Form[""];
        }


    }
}
