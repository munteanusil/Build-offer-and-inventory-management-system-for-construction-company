using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CostControlApp.Models;

public partial class CreateOfferDbContext : DbContext
{
    public CreateOfferDbContext()
    {
    }

    public CreateOfferDbContext(DbContextOptions<CreateOfferDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Offertum> Offerta { get; set; }
    public IEnumerable<object> Foaie1 { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-CT3VKRI\\SQLEXPRESS;Initial Catalog=CreateOffer;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Offertum>(entity =>
        {
            entity.HasKey(e => e.OfferId);

            entity.Property(e => e.OfferId).ValueGeneratedNever();
            entity.Property(e => e.AdresaDestinatar)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.DataExpirare).HasColumnType("datetime");
            entity.Property(e => e.DataOferta).HasColumnType("datetime");
            entity.Property(e => e.Destinatar)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.DetaliiProiect)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Manopera)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Material)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.NumarOferta)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PhoneClient)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Proiect)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UnitateMasura)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
