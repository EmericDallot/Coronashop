using System;
using System.Collections.Generic;
using Unite;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// Classe définissant Gels. Elle hérite de la classe Produits.
    /// </summary>
    [Serializable]
    public class Gels : Produits
    {
        /// <summary>
        /// Contenance de ce Gels
        /// </summary>
        public float Contenance { get; set; }
        /// <summary>
        /// Unite de ce Gels
        /// </summary>
        public Volume Unite { get; set; }
        /// <summary>
        /// Produits de ce Gels
        /// </summary>
        public Produits produits { get; set; }


        /// <summary>
        /// Constructeur pour EF core
        /// </summary>
        public Gels()
        {
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="refProduit">RefProduits de ce Gels</param>
        /// <param name="contenance">Contenance de ce Gels</param>
        /// <param name="unite">Unite de ce Gels</param>
        /// <param name="delaisDeLivraison">DelaisDeLivraison de ce Gels</param>
        /// <param name="prix">Prix de ce Gels</param>
        /// <param name="nom">Nomde ce Gels</param>
        /// <param name="description">Descritpionde ce Gels</param>
        /// <param name="provenance">Provenance de ce Gels</param>
        /// <param name="image">Path image de ce Gels</param>
        public Gels(string refProduit, float contenance, Volume unite, int delaisDeLivraison, float prix, string nom, string description, string provenance, string image)
        : base(refProduit, delaisDeLivraison, prix, nom, description, provenance, image)
        {
            if (contenance <= 0)
            {
                throw new ArgumentOutOfRangeException("La contenance ne peut pas être égale ou inférieure à zéro.");
            }
            this.Contenance = contenance;
            this.Unite = unite;
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contenance">Contenance de ce Gels</param>
        /// <param name="unite">Unite de ce Gels</param>
        /// <param name="produits">Produits de ce Gels</param>
        public Gels(float contenance, Volume unite, Produits produits)
        : base(produits.RefProduit, produits.DelaisDeLivraison, produits.Prix, produits.Nom, produits.Description, produits.Provenance, produits.Image)
        {
            if (contenance <= 0)
            {
                throw new ArgumentOutOfRangeException("La contenance ne peut pas être égale ou inférieure à zéro.");
            }
            this.Contenance = contenance;
            this.Unite = unite;
        }
    }
}
