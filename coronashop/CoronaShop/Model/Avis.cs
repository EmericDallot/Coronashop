using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// Classe définissant Avis.
    /// </summary>
    public class Avis
    {
        /// <summary>
        /// Note de cet Avis
        /// </summary>
        public int Note { get; set; }
        /// <summary>
        /// Commentaire de cet Avis
        /// </summary>
        public string Commentaire { get; set; }
        /// <summary>
        /// Pseudo clé étrangère de cet Avis
        /// </summary>
        public string Pseudo { get; set; }
        /// <summary>
        /// RefProduit clé étrangère de cet Avis
        /// </summary>
        public string RefProduit { get; set; }
        /// <summary>
        /// Utilisateur de cet Avis
        /// </summary>
        public Utilisateurs Utilisateurs { get; set; }
        /// <summary>
        /// Produit de cet Avis
        /// </summary>
        public Produits Produits { get; set; }
        /// <summary>
        /// Constructeur pour EF core
        /// </summary>
        public Avis()
        {

        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="utilisateurs">Utilisateur de cet Avis</param>
        /// <param name="produits">Produit de cet Avis</param>
        /// <param name="note">Note de cet Avis</param>
        /// <param name="commentaire">Commentaire de cet Avis</param>
        public Avis(Utilisateurs utilisateurs,Produits produits,int note, string commentaire)
        {
            if (note > 10 || note < 0)
            {
                throw new ArgumentOutOfRangeException("La note doit être comprise entre 0 et 10 compris.");
            }
            else if (string.IsNullOrEmpty(commentaire))
            {
                throw new ArgumentNullException("Le commentaire ne peut pas être null ou vide.");
            }
            else if (commentaire.Length < 10)
            {
                throw new ArgumentOutOfRangeException("Le commentaire doit faire au minimum 10 caractère.");
            }
            this.RefProduit = produits.RefProduit;
            this.Pseudo = utilisateurs.Pseudo;
            this.Note = note;
            this.Commentaire = commentaire;
        }
    }
}
