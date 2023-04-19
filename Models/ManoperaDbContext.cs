using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CostControlApp.Models;

public partial class ManoperaDbContext : DbContext
{
    public ManoperaDbContext()
    {
    }

    public ManoperaDbContext(DbContextOptions<ManoperaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Foaie1> Foaie1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-CT3VKRI\\SQLEXPRESS;Initial Catalog=ManoperaDb;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Foaie1>(entity =>
        {
            entity.HasKey(e => e.ManoperaId);

            entity.ToTable("Foaie1");

            entity.Property(e => e.Cantitate).HasColumnName("CANTITATE");
            entity.Property(e => e.EuroM2)
                .HasColumnType("money")
                .HasColumnName("EURO/M2");
            entity.Property(e => e.Manopera)
                .HasMaxLength(255)
                .HasColumnName("MANOPERA ");
            entity.Property(e => e.TotalEur)
                .HasColumnType("money")
                .HasColumnName("TOTAL<EUR>");
            entity.Property(e => e.Um)
                .HasMaxLength(255)
                .HasColumnName("UM");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
