using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// Classe définissant la classe Masque. Elle hérite de la classe Produits
    /// </summary>
    [Serializable]
    public class Masques : Produits
    {
        /// <summary>
        /// Type de ce Masques
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Produits de ce Masques
        /// </summary>
        public Produits Produits { get; set; }

        /// <summary>
        /// Constructeur pour EF Core
        /// </summary>
        public Masques()
        {

        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="refProduit">RefProduits de ce Masques</param>
        /// <param name="type">Type de ce Masques</param>
        /// <param name="delaisDeLivraison">DelaisDeLivraison de ce Masques</param>
        /// <param name="prix">Prix de ce Masques</param>
        /// <param name="nom">Nom de ce Masques</param>
        /// <param name="description">Descritpion de ce Masques</param>
        /// <param name="provenance">Provenance de ce Masques</param>
        /// <param name="image">Path image de ce Masques</param>
        public Masques(String refProduit, String type, int delaisDeLivraison, float prix, String nom, String description, String provenance, String image)
        : base(refProduit, delaisDeLivraison, prix, nom, description, provenance, image)
        {
            if (String.IsNullOrEmpty(type))
            {
                throw new ArgumentNullException("L'argument ne peut pas être null ou vide");
            }
            this.Type = type;
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="type">Type de ce Masque</param>
        /// <param name="produits">Produits de Masques</param>
        public Masques(String type, Produits produits)
        : base(produits.RefProduit, produits.DelaisDeLivraison, produits.Prix, produits.Nom, produits.Description, produits.Provenance, produits.Image)
        {
            if (String.IsNullOrEmpty(type))
            {
                throw new ArgumentNullException("L'argument ne peut pas être null ou vide");
            }
            this.Type = type;
        }

    }
}
