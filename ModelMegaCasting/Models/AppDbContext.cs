using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiMegaCasting
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Civilite> Civilites { get; set; }
        public virtual DbSet<Contrat> Contrats { get; set; }
        public virtual DbSet<DomaineMetier> DomaineMetiers { get; set; }
        public virtual DbSet<Employe> Employes { get; set; }
        public virtual DbSet<GroupeEmploye> GroupeEmployes { get; set; }
        public virtual DbSet<Internaute> Internautes { get; set; }
        public virtual DbSet<Metier> Metiers { get; set; }
        public virtual DbSet<Offre> Offres { get; set; }
        public virtual DbSet<OffresInternaute> OffresInternautes { get; set; }
        public virtual DbSet<Partenaire> Partenaires { get; set; }
        public virtual DbSet<Studio> Studios { get; set; }
        public virtual DbSet<TypeContrat> TypeContrats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server =DESKTOP-9I8NR9H\\SQLEXPRESS; Database = MegaCasting; Integrated Security = True; Trusted_Connection = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<Civilite>(entity =>
            {
                entity.ToTable("Civilite");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contrat>(entity =>
            {
                entity.ToTable("Contrat");

                entity.Property(e => e.CodeContrat)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DebutContrat).HasColumnType("date");

                entity.Property(e => e.FichierContrat).IsRequired();

                entity.HasOne(d => d.IdOffreNavigation)
                    .WithMany(p => p.Contrats)
                    .HasForeignKey(d => d.IdOffre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contrat_Offres");

                entity.HasOne(d => d.IdTypeContratNavigation)
                    .WithMany(p => p.Contrats)
                    .HasForeignKey(d => d.IdTypeContrat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contrat_TypeContrat");
            });

            modelBuilder.Entity<DomaineMetier>(entity =>
            {
                entity.ToTable("DomaineMetier");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employe>(entity =>
            {
                entity.ToTable("Employe");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCiviliteNavigation)
                    .WithMany(p => p.Employes)
                    .HasForeignKey(d => d.IdCivilite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employes_Civilite");

                entity.HasOne(d => d.IdGroupeEmployesNavigation)
                    .WithMany(p => p.Employes)
                    .HasForeignKey(d => d.IdGroupeEmployes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employes_GroupeEmployes");
            });

            modelBuilder.Entity<GroupeEmploye>(entity =>
            {
                entity.ToTable("GroupeEmploye");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Internaute>(entity =>
            {
                entity.ToTable("Internaute");

                entity.Property(e => e.Cv).IsUnicode(false);

                entity.Property(e => e.DateInscription)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateNaissance).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.LienGoogle)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCiviliteNavigation)
                    .WithMany(p => p.Internautes)
                    .HasForeignKey(d => d.IdCivilite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Internautes_Civilite");
            });

            modelBuilder.Entity<Metier>(entity =>
            {
                entity.ToTable("Metier");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDomaineMetierNavigation)
                    .WithMany(p => p.Metiers)
                    .HasForeignKey(d => d.IdDomaineMetier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Metier_DomaineMetier");
            });

            modelBuilder.Entity<Offre>(entity =>
            {
                entity.ToTable("Offre");

                entity.Property(e => e.CodeOffre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DatePublication).HasColumnType("date");

                entity.Property(e => e.DescriptionPoste)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionProfile)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Intitule)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Localisation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmployeNavigation)
                    .WithMany(p => p.Offres)
                    .HasForeignKey(d => d.IdEmploye)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offres_Employes");

                entity.HasOne(d => d.IdMetierNavigation)
                    .WithMany(p => p.Offres)
                    .HasForeignKey(d => d.IdMetier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offres_Metier");

                entity.HasOne(d => d.IdStudioNavigation)
                    .WithMany(p => p.Offres)
                    .HasForeignKey(d => d.IdStudio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offres_Studios");
            });

            modelBuilder.Entity<OffresInternaute>(entity =>
            {
                entity.HasKey(e => new { e.IdInternaute, e.IdOffre })
                    .HasName("PK_OffresInternautes");

                entity.ToTable("OffresInternaute");

                entity.Property(e => e.IdInternaute).ValueGeneratedOnAdd();

                entity.Property(e => e.DatePostulation).HasColumnType("date");

                entity.HasOne(d => d.IdInternauteNavigation)
                    .WithMany(p => p.OffresInternautes)
                    .HasForeignKey(d => d.IdInternaute)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OffresInternautes_Internautes");

                entity.HasOne(d => d.IdOffreNavigation)
                    .WithMany(p => p.OffresInternautes)
                    .HasForeignKey(d => d.IdOffre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OffresInternautes_Offres");
            });

            modelBuilder.Entity<Partenaire>(entity =>
            {
                entity.ToTable("Partenaire");

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Siret)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Studio>(entity =>
            {
                entity.ToTable("Studio");

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Siret)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeContrat>(entity =>
            {
                entity.ToTable("TypeContrat");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
