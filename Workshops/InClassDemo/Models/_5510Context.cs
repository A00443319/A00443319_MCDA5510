using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InClassDemo.Models
{
    public partial class _5510Context : DbContext
    {
        public _5510Context()
        {
        }

        public _5510Context(DbContextOptions<_5510Context> options)
            : base(options)
        {
        }

        public virtual DbSet<InclassDemoCustomer> InclassDemoCustomer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:5510latua.database.windows.net,1433;Initial Catalog=5510;Persist Security Info=False;User ID=akshay;Password=mcda@5510;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InclassDemoCustomer>(entity =>
            {
                entity.ToTable("inclass_demo_customer");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasColumnName("f_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LName)
                    .HasColumnName("l_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
