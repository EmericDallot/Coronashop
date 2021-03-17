using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Design;
using Model;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using IDATA;
using System.IO;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// Classe définissant azertyiop_coronashopContext. Cette classe créer un context entre le code et la base de donnée.
    /// </summary>
    public partial class azertyiop_coronashopContext : DbContext
    {
        /// <summary>
        /// Table Avis de ce DbContext
        /// </summary>
        public virtual DbSet<Avis> Avis { get; set; }
        /// <summary>
        /// Table Commandes de ce DbContext
        /// </summary>
        public virtual DbSet<Commandes> Commandes { get; set; }
        /// <summary>
        ///  Table Gels de ce DbContext
        /// </summary>
        public virtual DbSet<Gels> Gels { get; set; }
        /// <summary>
        /// Table Masques de ce DbContext
        /// </summary>
        public virtual DbSet<Masques> Masques { get; set; }
        /// <summary>
        /// Table Produits de ce DbContext
        /// </summary>
        public virtual DbSet<Produits> Produits { get; set; }
        /// <summary>
        /// Table Propositions de ce DbContext
        /// </summary>
        public virtual DbSet<Propositions> Propositions { get; set; }
        /// <summary>
        /// Table Utilisateurs de ce DbContext
        /// </summary>
        public virtual DbSet<Utilisateurs> Utilisateurs { get; set; }
        /// <summary>
        /// Constructeur de ce DbContext
        /// </summary>
        public azertyiop_coronashopContext()
        {
        }
        /// <summary>
        /// Constructeur avec option de ce DbContext
        /// </summary>
        /// <param name="options">Option de ce DbContext</param>
        public azertyiop_coronashopContext(DbContextOptions<azertyiop_coronashopContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// Méthode reliant le context à un serveur MySql
        /// </summary>
        /// <param name="optionsBuilder">optionBuilder</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=mysql-azertyiop.alwaysdata.net;uid=azertyiop;password=a1z2e3r4;database=azertyiop_coronashop;");
            }
        }
        /// <summary>
        /// Logique d'interaction avec la base de donnée
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Avis>(entity =>
            {
                entity.Property(a => a.RefProduit)
                .HasMaxLength(8);

                entity.Property(a => a.Pseudo)
                .HasMaxLength(8);

                entity.HasKey(p => new { p.Pseudo, p.RefProduit });

                entity.HasOne(a => a.Produits)
                .WithMany(p => p.Avis)
                .HasForeignKey(a => a.RefProduit);

                entity.HasOne(a => a.Utilisateurs)
                .WithMany(u => u.Avis)
                .HasForeignKey(a => a.Pseudo);
            });
            
            modelBuilder.Entity<Commandes>(entity =>
            {
                entity.HasOne(c => c.Utilisateurs)
                .WithMany(u => u.Commandes)
                .HasForeignKey(c => c.Pseudo);

                entity.Property(c => c.NoCommande)
                .ValueGeneratedOnAdd();

                entity.Property(c => c.Panier)
                .HasConversion<byte[]>(
                    d => ToBin.Serializer(d),
                    s => ToBin.Deserializer(s) as Dictionary<Produits, int>
                ).HasMaxLength(100000).IsRequired();
        });

            modelBuilder.Entity<Gels>(entity =>
            {
                entity.HasOne<Produits>(g => g.produits)
                .WithMany(p => p.Gels).HasForeignKey(g => g.RefProduit)
                .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Masques>(entity =>
            {
                entity.HasOne<Produits>(m => m.Produits)
                .WithMany(p => p.Masques).HasForeignKey(m => m.RefProduit)
                .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Produits>(entity =>
            {
                entity.HasKey(n => n.RefProduit);
            });

            modelBuilder.Entity<Propositions>(entity =>
            {   
                entity.Property(b => b.NoProposition)
                .ValueGeneratedOnAdd();

                entity.HasKey(n => n.NoProposition);

            });

            modelBuilder.Entity<Utilisateurs>(entity =>
            {
                entity.HasKey(n => n.Pseudo);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
