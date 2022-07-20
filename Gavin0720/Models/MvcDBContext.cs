using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gavin0720.Models
{
    public partial class MvcDBContext : DbContext
    {
        public MvcDBContext()
        {
        }

        public MvcDBContext(DbContextOptions<MvcDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblProduct> TblProducts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-HMED35I9;Initial Catalog=MvcDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.CId);

                entity.ToTable("tblProduct");

                entity.Property(e => e.CId)
                    .HasColumnName("cID")
                    .HasComment("流水號");

                entity.Property(e => e.CCreateDt)
                    .HasColumnType("datetime")
                    .HasColumnName("cCreateDT")
                    .HasComment("建立時間");

                entity.Property(e => e.CInventory)
                    .HasColumnName("cInventory")
                    .HasComment("庫存數");

                entity.Property(e => e.CName)
                    .HasMaxLength(50)
                    .HasColumnName("cName")
                    .HasComment("產品名稱");

                entity.Property(e => e.CPrice)
                    .HasColumnName("cPrice")
                    .HasComment("產品價格");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
