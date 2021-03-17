using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// Classe définissant Commandes.
    /// </summary>
    public class Commandes
    {
        /// <summary>
        /// Dictionary<Produits, int> de cette Commandes
        /// </summary>
        public Dictionary<Produits, int> Panier { get; set; } = new Dictionary<Produits, int>();
        /// <summary>
        /// NoCommande de cette Commandes
        /// </summary>
        [Key]
        public int NoCommande { get; set; }
        /// <summary>
        /// Pseudo clé étrangère de cette Commandes
        /// </summary>
        public string Pseudo { get; set; }
        /// <summary>
        /// Utilisateurs de cette Commandes
        /// </summary>
        public Utilisateurs Utilisateurs { get; set; }
        /// <summary>
        /// Constructeur pour EF core
        /// </summary>
        public Commandes()
        {

        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="utilisateurs">Utilisateurs de cette Commandes</param>
        /// <param name="panier">Panier de cette Commandes</param>
        public Commandes(Utilisateurs utilisateurs, Dictionary<Produits, Parameter> panier)
        {
            if(panier.Count == 0 && panier == null)
            {
                throw new Exception("Aucun produit dans le panier");
            }
            
            foreach(Produits p in panier.Keys)
            {
                Panier.Add(p,panier[p].Value);
            }
            Pseudo = utilisateurs.Pseudo;
        }
    }
}
