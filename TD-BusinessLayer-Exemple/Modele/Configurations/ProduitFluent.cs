﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Entities;

namespace Modele.Configurations
{
    /// <summary>
    /// Configuration Fluent d'une Categorie
    /// </summary>
    public class ProduitFluent : EntityTypeConfiguration<Produit>
    {
        /// <summary>
        /// Constructeur et définition du maping
        /// </summary>
        public ProduitFluent()
        {
            ToTable("APP_PRODUIT");
            HasKey(p => p.ID);

            Property(p => p.ID).HasColumnName("PRD_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Nom).HasColumnName("PRD_NOM").IsRequired().HasMaxLength(100);

            HasRequired(p => p.Categorie).WithMany(c => c.Produits).HasForeignKey(p => p.CategorieID);
        }
    }
}
