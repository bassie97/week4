using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Energieweb.Models
{
    public partial class EnergiewebContext : DbContext
    {
        public virtual DbSet<Apparaat> Apparaat { get; set; }
        public virtual DbSet<ApparaatHuishouden> ApparaatHuishouden { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Huishouden> Huishouden { get; set; }
        public virtual DbSet<Meting> Meting { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Postcode> Postcode { get; set; }
        public virtual DbSet<Type> Type { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-QVSI6H9\ENERGIEWEB;Initial Catalog=Energieweb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apparaat>(entity =>
            {
                entity.ToTable("apparaat", "energieweb");

                entity.HasIndex(e => e.TypeFk)
                    .HasName("type_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Max).HasColumnName("max");

                entity.Property(e => e.Merk)
                    .HasColumnName("merk")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Naam)
                    .HasColumnName("naam")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.TypeFk).HasColumnName("type_fk");

                entity.HasOne(d => d.TypeFkNavigation)
                    .WithMany(p => p.Apparaat)
                    .HasForeignKey(d => d.TypeFk)
                    .HasConstraintName("apparaat$apparaat_type_ibfk_1");
            });

            modelBuilder.Entity<ApparaatHuishouden>(entity =>
            {
                entity.ToTable("apparaat_huishouden", "energieweb");

                entity.HasIndex(e => e.ApparaatFk)
                    .HasName("app_idx");

                entity.HasIndex(e => e.HuishoudenFk)
                    .HasName("hh_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApparaatFk).HasColumnName("apparaat_fk");

                entity.Property(e => e.HuishoudenFk).HasColumnName("huishouden_fk");

                entity.HasOne(d => d.ApparaatFkNavigation)
                    .WithMany(p => p.ApparaatHuishouden)
                    .HasForeignKey(d => d.ApparaatFk)
                    .HasConstraintName("apparaat_huishouden$apparaat_huishouden_ibfk_2");

                entity.HasOne(d => d.HuishoudenFkNavigation)
                    .WithMany(p => p.ApparaatHuishouden)
                    .HasForeignKey(d => d.HuishoudenFk)
                    .HasConstraintName("apparaat_huishouden$apparaat_huishouden_ibfk_1");
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Huishouden>(entity =>
            {
                entity.ToTable("huishouden", "energieweb");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Grootte).HasColumnName("grootte");

                entity.Property(e => e.Huisnummer).HasColumnName("huisnummer");

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasColumnType("char(6)");
            });

            modelBuilder.Entity<Meting>(entity =>
            {
                entity.ToTable("meting", "energieweb");

                entity.HasIndex(e => e.AppHh)
                    .HasName("app_hh");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppHh).HasColumnName("app_hh");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("date");

                entity.Property(e => e.Tijd).HasColumnName("tijd");

                entity.Property(e => e.Waarde).HasColumnName("waarde");

                entity.HasOne(d => d.AppHhNavigation)
                    .WithMany(p => p.Meting)
                    .HasForeignKey(d => d.AppHh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("meting$meting_ibfk_1");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Postcode>(entity =>
            {
                entity.ToTable("postcode", "energieweb");

                entity.HasIndex(e => new { e.PostcodeId, e.Minnumber, e.Maxnumber })
                    .HasName("postcode_number");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ChangedDate)
                    .HasColumnName("changed_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("decimal(15, 13)");

                entity.Property(e => e.LocationDetail)
                    .IsRequired()
                    .HasColumnName("location_detail")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'postcode')");

                entity.Property(e => e.Lon)
                    .HasColumnName("lon")
                    .HasColumnType("decimal(15, 13)");

                entity.Property(e => e.Maxnumber).HasColumnName("maxnumber");

                entity.Property(e => e.Minnumber).HasColumnName("minnumber");

                entity.Property(e => e.Municipality)
                    .HasColumnName("municipality")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MunicipalityId).HasColumnName("municipality_id");

                entity.Property(e => e.Numbertype)
                    .IsRequired()
                    .HasColumnName("numbertype")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Pchar)
                    .IsRequired()
                    .HasColumnName("pchar")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Pnum).HasColumnName("pnum");

                entity.Property(e => e.Postcode1)
                    .IsRequired()
                    .HasColumnName("postcode")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.PostcodeId).HasColumnName("postcode_id");

                entity.Property(e => e.Province)
                    .HasColumnName("province")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceCode)
                    .HasColumnName("province_code")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RdX)
                    .HasColumnName("rd_x")
                    .HasColumnType("decimal(31, 20)");

                entity.Property(e => e.RdY)
                    .HasColumnName("rd_y")
                    .HasColumnType("decimal(31, 20)");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("type", "energieweb");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TypeNaam)
                    .HasColumnName("type_naam")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });
        }
    }
}
