using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CostControlApp.Contracts;
using CostControlApp.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CostControlApp.Models;

//[Keyless]
[Table("Sheet1")]
[PrimaryKey("ItemId")]
public partial class Sheet1 
{

    
    [Column("ItemId")]
    
    public int ItemId { get; set; } 

    
    [Column("Nr# crt#")]
    public double? NrCrt { get; set; }

    
    [Column("Cod produs")]
    [StringLength(255)]
    public string? CodProdus { get; set; }

    [Column("Dimensiuni_(mm)")]
    [StringLength(255)]
    public string? DimensiuniMm { get; set; }

    [ForeignKey("Produs")]
    [StringLength(255)]
    public string? Denumire { get; set; }

    [StringLength(255)]
    public string? Greutate { get; set; }

    [Column("€ /buc")]
    [StringLength(255)]
    public string? Buc { get; set; }

    [Column("€ /mp")]
    public double? Mp { get; set; }

    [Column("€ /ml")]
    public double? Ml { get; set; }

    [Column("€ /mp_sistem*")]
    [StringLength(255)]
    public string? MpSistem { get; set; }

    [StringLength(255)]
    public string? Culoare { get; set; }

    [Column("Nr buc pe_pachet")]
    [StringLength(255)]
    public string? NrBucPePachet { get; set; }

    [StringLength(255)]
    public string? Finisaj { get; set; }

  
}
