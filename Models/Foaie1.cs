using MessagePack;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostControlApp.Models;


public partial class Foaie1
{
    [Key("Manoperaid")]
    public int ManoperaId { get; set; }
    [ForeignKey("Manopera")]
    public string? Manopera { get; set; }

    public string? Um { get; set; }

    public decimal? EuroM2 { get; set; }

    public double? Cantitate { get; set; }

    public decimal? TotalEur { get; set; }
 
}
