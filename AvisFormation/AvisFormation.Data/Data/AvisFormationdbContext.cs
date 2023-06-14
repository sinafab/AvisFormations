using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AvisFormation.Data.Data;

public partial class AvisFormationdbContext : DbContext
{
    public AvisFormationdbContext()
    {
    }

    public AvisFormationdbContext(DbContextOptions<AvisFormationdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Avi> Avis { get; set; }

    public virtual DbSet<Formation> Formations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=AvisFormationdb;user=root;password=Bujumbura62@", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Avi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdFormation, "IdFormation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateAvis).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Nom).HasMaxLength(100);
            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.IdFormationNavigation).WithMany(p => p.Avis)
                .HasForeignKey(d => d.IdFormation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("avis_ibfk_1");
        });

        modelBuilder.Entity<Formation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Formation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Nom).HasMaxLength(100);
            entity.Property(e => e.NomSeo).HasMaxLength(100);
            entity.Property(e => e.Url).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
