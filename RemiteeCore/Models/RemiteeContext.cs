using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RemiteeCore.Models
{
    public partial class RemiteeContext : DbContext
    {
        public RemiteeContext()
        {
        }

        public RemiteeContext(DbContextOptions<RemiteeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Payer> Payer { get; set; }
        public virtual DbSet<PayerBranch> PayerBranch { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-G66RASR;Initial Catalog=RemiteeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payer>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PayerBranch>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FormattedAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Payer)
                    .WithMany(p => p.PayerBranch)
                    .HasForeignKey(d => d.PayerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PayerBranch_Payer");
            });
        }
    }
}
