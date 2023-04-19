using System;
using System.Collections.Generic;

namespace CostControlApp.Models;

public partial class Offertum
{
    public int OfferId { get; set; }

    public string? NumarOferta { get; set; }

    public string? Proiect { get; set; }

    public DateTime? DataOferta { get; set; }

    public DateTime? DataExpirare { get; set; }

    public string? Email { get; set; }

    public string? PhoneClient { get; set; }

    public string? Destinatar { get; set; }

    public string? AdresaDestinatar { get; set; }

    public string? DetaliiProiect { get; set; }

    public string? Manopera { get; set; }

    public string? Material { get; set; }

    public string? UnitateMasura { get; set; }

    public int? EuroM2 { get; set; }

    public int? Cantitatea { get; set; }

    public int? Total { get; set; }

    public string? numemanopera {get;set;}

}
