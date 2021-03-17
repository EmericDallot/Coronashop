using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Classe définissant Produits.
    /// </summary>
    [Serializable]
    public class Produits
    {
        /// <summary>
        /// RefProduit de ce Produits
        /// </summary>
        [Key]
        public string RefProduit { get; set; }
        /// <summary>
        ///  DelaisDeLivraison de ce Produits
        /// </summary>
        public int DelaisDeLivraison { get; set; }
        /// <summary>
        /// Prix de ce Produits
        /// </summary>
        public float Prix { get; set; }
        /// <summary>
        /// Nom de ce Produits
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Decription de ce Produits
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Provenance de ce Produits
        /// </summary>
        public string Provenance { get; set; }
        /// <summary>
        /// Image de ce Produits
        /// </summary>
        public byte[] Image { get; set; }
        /// <summary>
        /// Foreign Key Avis de ce Produits pour EF core
        /// </summary>
        public ICollection<Gels> Gels { get; set; }
        /// <summary>
        /// Foreign Key Avis de ce Produits pour EF core
        /// </summary>
        public ICollection<Masques> Masques { get; set; }
        /// <summary>
        /// Foreign Key Avis de ce Produits pour EF core
        /// </summary>
        public ICollection<Avis> Avis { get; set; }
        /// <summary>
        /// Constructeur pour EF Core
        /// </summary>
        public Produits()
        {
            Gels = new HashSet<Gels>();
            Masques = new HashSet<Masques>();
            Avis = new HashSet<Avis>();
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="refProduit">RefProduits</param>
        /// <param name="delaisDeLivraison">DelaisDeLivraison de ce Produits</param>
        /// <param name="prix">Prix de ce Produits</param>
        /// <param name="nom">Nom de ce Produits</param>
        /// <param name="description">Descritpion de ce Produits</param>
        /// <param name="provenance">Provenance de ce Produits</param>
        /// <param name="imagePath">Image path de ce Produits</param>
        public Produits(string refProduit, int delaisDeLivraison, float prix, string nom, string description, string provenance, string imagePath)
            : this(refProduit, delaisDeLivraison, prix, nom, description, provenance)
        {
            if (String.IsNullOrEmpty(imagePath))
            {
                throw new ArgumentNullException("Les arguments ne peuvent pas être null ou vide");
            }

            FileStream stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            byte[] photo = reader.ReadBytes((int)stream.Length);
            Image = photo;
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="refProduit">RefProduits</param>
        /// <param name="delaisDeLivraison">DelaisDeLivraison de ce Produits</param>
        /// <param name="prix">Prix de ce Produits</param>
        /// <param name="nom">Nom de ce Produits</param>
        /// <param name="description">Descritpion de ce Produits</param>
        /// <param name="provenance">Provenance de ce Produits</param>
        /// <param name="image">Image de ce Produits</param>
        public Produits(string refProduit, int delaisDeLivraison, float prix, string nom, string description, string provenance, byte[] image)
            : this(refProduit, delaisDeLivraison, prix, nom, description, provenance)
        {
            if (image.Length == 0 || image == null)
            {
                throw new ArgumentNullException("Les arguments ne peuvent pas être null ou vide");
            }
            this.Image = image;
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="refProduit">RefProduits</param>
        /// <param name="delaisDeLivraison">DelaisDeLivraison de ce Produits</param>
        /// <param name="prix">Prix de ce Produits</param>
        /// <param name="nom">Nom de ce Produits</param>
        /// <param name="description">Descritpion de ce Produits</param>
        /// <param name="provenance">Provenance de ce Produits</param>
        public Produits(string refProduit, int delaisDeLivraison, float prix, string nom, string description, string provenance)
        {
            if(!Regex.IsMatch(nom, @"^[A-Za-z]+(\s?[A-Za-z]+)*$"))
            {
                throw new Exception("Le nom doit être composé uniquement de lettre.");
            }
            if(!Regex.IsMatch(provenance, @"^[A-Za-z]+$"))
            {
                throw new Exception("La provenance doit être composé uniquement de lettre.");
            }
            if (prix < 0)
            {
                throw new Exception("Le prix ne peut pas être négatif.");
            }
            else if (refProduit.Length != 8)
            {
                throw new Exception("La taille de la référence produit doit etre égale a 8.");
            }
            else if (delaisDeLivraison < 0)
            {
                throw new Exception("Le delais de livraison ne peut pas être négatif.");
            }
            else if (String.IsNullOrEmpty(nom))
            {
                throw new Exception("Les arguments ne peuvent pas être null ou vide");
            }
            this.RefProduit = refProduit;
            this.DelaisDeLivraison = delaisDeLivraison;
            this.Prix = prix;
            this.Nom = nom;
            this.Description = description;
            this.Provenance = provenance;
        }
    }
}
