using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bimcod.Api.Models
{
    public partial class BimcodContext : DbContext
    {
        public BimcodContext()
        {
        }

        public BimcodContext(DbContextOptions<BimcodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarOption> CarOption { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<OptionPart> OptionPart { get; set; }
        public virtual DbSet<Part> Part { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<BuiltInCar> BuiltInCar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Bimcod;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Model).HasMaxLength(10);

                entity.Property(e => e.Type).HasMaxLength(10);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Car__UserId__38996AB5");
            });

            modelBuilder.Entity<CarOption>(entity =>
            {
                entity.HasKey(e => new { e.CarId, e.OptionId });

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.CarOption)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarOption__CarId__2E1BDC42");

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.CarOption)
                    .HasForeignKey(d => d.OptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarOption__Optio__2F10007B");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.ModuleName);

                entity.Property(e => e.ModuleName)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.For).HasMaxLength(10);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.ModuleName).HasMaxLength(10);

                entity.HasOne(d => d.ModuleNameNavigation)
                    .WithMany(p => p.Option)
                    .HasForeignKey(d => d.ModuleName)
                    .HasConstraintName("FK__Option__ModuleNa__2B3F6F97");
            });

            modelBuilder.Entity<OptionPart>(entity =>
            {
                entity.HasKey(e => new { e.OptionId, e.PartId });

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.OptionPart)
                    .HasForeignKey(d => d.OptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionPar__Optio__33D4B598");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.OptionPart)
                    .HasForeignKey(d => d.PartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionPar__PartI__34C8D9D1");
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<BuiltInCar>(entity =>
            {
                entity.Property(e => e.Model).HasMaxLength(10);

                entity.Property(e => e.Type).HasMaxLength(10);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__tmp_ms_x__A9D105343AFB0BC0")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Token)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username).HasMaxLength(100);
            });
        }
    }
}
