using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Protocols;

#nullable disable

namespace Projekt.Models
{
    public partial class SystemOstrzeganiaContext : DbContext
    {
        public SystemOstrzeganiaContext()
        {
        }

        public SystemOstrzeganiaContext(DbContextOptions<SystemOstrzeganiaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DataPomiaru> DataPomiarus { get; set; }
        public virtual DbSet<DataPomiaruZstacji> DataPomiaruZstacjis { get; set; }
        public virtual DbSet<DataPowodziHi> DataPowodziHis { get; set; }
        public virtual DbSet<DataPrognozy> DataPrognozies { get; set; }
        public virtual DbSet<ImgwdaneSynoptyczne> ImgwdaneSynoptycznes { get; set; }
        public virtual DbSet<ObszarZagrozony> ObszarZagrozonies { get; set; }
        public virtual DbSet<ObszaryZalewowe> ObszaryZalewowes { get; set; }
        public virtual DbSet<OstrzeganieInstytucji> OstrzeganieInstytucjis { get; set; }
        public virtual DbSet<PodwyzszonyPoziom> PodwyzszonyPozioms { get; set; }
        public virtual DbSet<PomiarRzeki> PomiarRzekis { get; set; }
        public virtual DbSet<PomiarRzekiDlaMiejscowosci> PomiarRzekiDlaMiejscowoscis { get; set; }
        public virtual DbSet<PowiadomienieSm> PowiadomienieSms { get; set; }
        public virtual DbSet<PowodzieHistoryczne> PowodzieHistorycznes { get; set; }
        public virtual DbSet<PrognozaPogody> PrognozaPogodies { get; set; }
        public virtual DbSet<RodzajSłużbyRatunkowej> RodzajSłużbyRatunkowejs { get; set; }
        public virtual DbSet<SprawdzCzyByłaPowódz> SprawdzCzyByłaPowódzs { get; set; }
        public virtual DbSet<SprawdzCzyZalewowy> SprawdzCzyZalewowies { get; set; }
        public virtual DbSet<SprawdzPrognozeDlaMiastum> SprawdzPrognozeDlaMiasta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<DataPomiaru>(entity =>
            {
                entity.HasKey(e => e.Data)
                    .HasName("PK__DataPomi__77387D0A9DE95860");

                entity.ToTable("DataPomiaru", "dane");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Dzień)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Miesiąc)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.NazwaRzeki)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Rok)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.NazwaRzekiNavigation)
                    .WithMany(p => p.DataPomiarus)
                    .HasForeignKey(d => d.NazwaRzeki)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NazwaRzekiPomiaru");
            });

            modelBuilder.Entity<DataPomiaruZstacji>(entity =>
            {
                entity.HasKey(e => e.Data)
                    .HasName("PK__DataPomi__77387D0AD5FE7994");

                entity.ToTable("DataPomiaruZStacji", "dane");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Dzień)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.IdStacji).HasColumnName("id_stacji");

                entity.Property(e => e.Miesiąc)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Rok)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdStacjiNavigation)
                    .WithMany(p => p.DataPomiaruZstacjis)
                    .HasForeignKey(d => d.IdStacji)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_stacji");
            });

            modelBuilder.Entity<DataPowodziHi>(entity =>
            {
                entity.HasKey(e => e.DataPowodzi)
                    .HasName("PK__DataPowo__E93B82BA9832E658");

                entity.ToTable("DataPowodziHis", "dane");

                entity.Property(e => e.DataPowodzi).HasColumnType("date");

                entity.Property(e => e.Dzień)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Miejscowość)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Miesiąc)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Rok)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.MiejscowośćNavigation)
                    .WithMany(p => p.DataPowodziHis)
                    .HasForeignKey(d => d.Miejscowość)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Miejscowość");
            });

            modelBuilder.Entity<DataPrognozy>(entity =>
            {
                entity.HasKey(e => e.Data)
                    .HasName("PK__DataProg__77387D0A5BABE65A");

                entity.ToTable("DataPrognozy", "dane");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Dzień)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Miesiąc)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Rok)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.MiastoNavigation)
                    .WithMany(p => p.DataPrognozies)
                    .HasForeignKey(d => d.Miasto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Miasto");
            });

            modelBuilder.Entity<ImgwdaneSynoptyczne>(entity =>
            {
                entity.HasKey(e => e.IdStacji)
                    .HasName("PK__IMGWDane__46736E00A5A8752C");

                entity.ToTable("IMGWDaneSynoptyczne", "dane");

                entity.Property(e => e.IdStacji)
                    .ValueGeneratedNever()
                    .HasColumnName("id_stacji");

                entity.Property(e => e.Stacja)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("stacja");

                entity.Property(e => e.SumaOpadu).HasColumnName("suma_opadu");
            });

            modelBuilder.Entity<ObszarZagrozony>(entity =>
            {
                entity.HasKey(e => e.Miejscowosc)
                    .HasName("PK__ObszarZa__726D9DB7951D029F");

                entity.ToTable("ObszarZagrozony", "dane");

                entity.Property(e => e.Miejscowosc)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NazwaRzeki)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.NazwaRzekiNavigation)
                    .WithMany(p => p.ObszarZagrozonies)
                    .HasForeignKey(d => d.NazwaRzeki)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NazwaRzeki");
            });

            modelBuilder.Entity<ObszaryZalewowe>(entity =>
            {
                entity.HasKey(e => e.NazwaRzeki)
                    .HasName("PK__ObszaryZ__D7B57E02222793B7");

                entity.ToTable("ObszaryZalewowe", "dane");

                entity.Property(e => e.NazwaRzeki)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Miejscowosc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OstrzeganieInstytucji>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OstrzeganieInstytucji", "dane");

                entity.Property(e => e.MiastoOrganizacji)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MiejscowoscOrganizacji)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MiejscowoscZagrozona)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NazwaSluzby)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.StanZagrozenia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.MiejscowoscZagrozonaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MiejscowoscZagrozona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Miejscowosc");
            });

            modelBuilder.Entity<PodwyzszonyPoziom>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PodwyzszonyPoziom");

                entity.Property(e => e.Miejscowosc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PomiarRzeki>(entity =>
            {
                entity.HasKey(e => e.NazwaRzeki)
                    .HasName("PK__PomiarRz__D7B57E020A039002");

                entity.ToTable("PomiarRzeki", "dane");

                entity.Property(e => e.NazwaRzeki)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PomiarRzekiDlaMiejscowosci>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PomiarRzekiDlaMiejscowosci");

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Miejscowosc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NazwaRzeki)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PowiadomienieSm>(entity =>
            {
                entity.HasKey(e => e.NumerTelefonu)
                    .HasName("PK__Powiadom__6C70F0C2239BCF5F");

                entity.ToTable("PowiadomienieSMS", "dane");

                entity.Property(e => e.NumerTelefonu)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Miejscowosc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StanZagrozenia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.MiejscowoscNavigation)
                    .WithMany(p => p.PowiadomienieSms)
                    .HasForeignKey(d => d.Miejscowosc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Miejscowosc2");
            });

            modelBuilder.Entity<PowodzieHistoryczne>(entity =>
            {
                entity.HasKey(e => e.Miejscowosc)
                    .HasName("PK__Powodzie__A551532136C135D3");

                entity.ToTable("PowodzieHistoryczne", "dane");

                entity.Property(e => e.Miejscowosc)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrognozaPogody>(entity =>
            {
                entity.HasKey(e => e.Miasto)
                    .HasName("PK__Prognoza__5B08C15F6681C165");

                entity.ToTable("PrognozaPogody", "dane");

                entity.Property(e => e.Miasto)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RodzajSłużbyRatunkowej>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RodzajSłużbyRatunkowej", "dane");

                entity.Property(e => e.Miejscowość)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PogRatunkowe).HasColumnName("Pog_ratunkowe");

                entity.Property(e => e.StrażPożarna).HasColumnName("Straż_pożarna");

                entity.HasOne(d => d.MiejscowośćNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Miejscowość)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Miejscowosce");
            });

            modelBuilder.Entity<SprawdzCzyByłaPowódz>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SprawdzCzyByłaPowódz");

                entity.Property(e => e.DataPowodzi).HasColumnType("date");

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Miejscowosc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NazwaRzeki)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SprawdzCzyZalewowy>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SprawdzCzyZalewowy", "dane");

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Miejscowosc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NazwaRzeki)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SprawdzPrognozeDlaMiastum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SprawdzPrognozeDlaMiasta");

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Miejscowosc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
