using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// Classe définissant Propositions.
    /// </summary>
    public class Propositions
    {
        /// <summary>
        /// NoProposition de cette Propositions
        /// </summary>
        [Key]
        public int NoProposition { get; set; }
        /// <summary>
        /// Commentaire de cette Propositions
        /// </summary>
        public string Commentaire { get; set; }

        /// <summary>
        /// Constructeur pour EF core
        /// </summary>
        public Propositions()
        {

        }
        /// <summary>
        /// Constructeur de cette Propositions
        /// </summary>
        /// <param name="commentaire">Commantaire de cette Propositions</param>
        public Propositions(string commentaire)
        {
            if(String.IsNullOrEmpty(commentaire))
            {
                throw new Exception("La proposition ne peut pas être vide");
            }
            this.Commentaire = commentaire;
        }
    }
}
