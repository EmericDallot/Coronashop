using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// Classe définissant Utilisateurs
    /// </summary>
    public class Utilisateurs
    {
        /// <summary>
        /// Pseudo de cet Utilisateurs
        /// </summary>
        [Key]
        public string Pseudo { get; set; }
        /// <summary>
        /// MotDePasse de cet Utilisateurs
        /// </summary>
        public string MotDePasse { get; set; }
        /// <summary>
        /// IsAdmin de cet Utilisateurs
        /// </summary>
        public byte IsAdmin { get; set; }
        /// <summary>
        /// Foreign Key Avis de cet Utilisateurs pour EF core
        /// </summary>
        public ICollection<Avis> Avis { get; set; }
        /// <summary>
        /// Foreign Key Commandes de cet Utilisateurs pour EF core
        /// </summary>
        public ICollection<Commandes> Commandes { get; set; }
        /// <summary>
        /// Constructeur
        /// </summary>
        public Utilisateurs()
        {
            Avis = new HashSet<Avis>();
            Commandes = new HashSet<Commandes>();
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="pseudo">Pseudo de cet Utilisateurs</param>
        /// <param name="motDePasse">MotDePasse de cet Utilisateurs</param>
        public Utilisateurs(String pseudo, String motDePasse)
        {
            bool motDePasseIsValid = Regex.IsMatch(motDePasse, @"^[a-zA-Z0-9]+$");
            bool pseudoIsValid = Regex.IsMatch(pseudo, @"^[a-zA-Z0-9]+$");

            if (String.IsNullOrEmpty(pseudo) || String.IsNullOrEmpty(motDePasse))
            {
                throw new ArgumentNullException("Le pseudo ou le mot de passe ne peut pas être null ou vide");
            }
            else if (pseudo.Length < 4 || pseudo.Length > 8)
            {
                throw new ArgumentOutOfRangeException("Le pseudo doit faire au minimum 4 caractères et au maximum 8 caractères.");
            }
            else if (motDePasse.Length < 7 || motDePasse.Length > 16)
            {
                throw new ArgumentOutOfRangeException("Le mot de passe doit faire au minimum 7 caractères et au maximum 16 caractères.");
            }
            else if (!pseudoIsValid)
            {
                throw new ArgumentException("Le pseudo ne doit contenir que des lettres et des chiffres");
            }
            else if (!motDePasseIsValid)
            {
                throw new ArgumentException("Le mot de passe ne doit contenir que des lettres et des chiffres");
            }
            this.Pseudo = pseudo;
            this.MotDePasse = motDePasse;
        }

    }
}

