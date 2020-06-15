using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace finalPro.Models
{
    public partial class finalProDBContext : DbContext
    {
        public finalProDBContext()
        {
        }

        public finalProDBContext(DbContextOptions<finalProDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Citizen> Citizen { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Requist> Requist { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MAHMOUDHASSAN\\TRESQL;Database=finalProDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NationalId)
                    .IsRequired()
                    .HasColumnName("nationalID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NReq).HasColumnName("nReq");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NationalId)
                    .IsRequired()
                    .HasColumnName("nationalID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.DateTime });

                entity.ToTable("logs");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.DateTime)
                    .HasColumnName("dateTime")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_logs_User");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Long)
                    .HasColumnName("long")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Requist>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CitId).HasColumnName("citID");

                entity.Property(e => e.DateTime)
                    .IsRequired()
                    .HasColumnName("dateTime")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Long)
                    .HasColumnName("long")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId).HasColumnName("orgID");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("image");

                entity.Property(e => e.Response).HasColumnName("response");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Cit)
                    .WithMany(p => p.Requist)
                    .HasForeignKey(d => d.CitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requist_Citizen");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.Requist)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requist_Organization");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Requist)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Requist_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NReq).HasColumnName("nReq");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NationalId)
                    .IsRequired()
                    .HasColumnName("nationalID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId).HasColumnName("orgID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
