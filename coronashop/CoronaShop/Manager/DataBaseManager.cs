using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Exceptionless.Models.Collections;
using Model;

namespace Manager
{
    /// <summary>
    /// Classe définissant DataBaseManager.
    /// Cette classe sert à la gestion des données et créée un lien entre la vue et les autres classes.
    /// </summary>
    public class DataBaseManager : INotifyPropertyChanged
    {
        /// <summary>
        /// ProduitsSelectionne de DataBaseManager
        /// </summary>
        public Produits ProduitsSelectionne
        {
            get => produitsSelectionne;
            set
            {
                if (produitsSelectionne != value)
                {
                    produitsSelectionne = value;
                    OnPropertyChanged(nameof(ProduitsSelectionne));
                    OnPropertyChanged(nameof(NoteMoyenne));
                    OnPropertyChanged(nameof(ListAvis));
                }

            }
        }
        /// <summary>
        /// ProduitsSelectionnev2 de DataBaseManager
        /// </summary>
        public Produits ProduitsSelectionnev2
        {
            get => produitsSelectionne;
            set
            {
                if (produitsSelectionne != value)
                {
                    produitsSelectionne = value;
                    OnPropertyChanged(nameof(ProduitsSelectionnev2));

                }

            }
        }


        /// <summary>
        /// produitsSelectionne de DataBaseManager
        /// </summary>
        private Produits produitsSelectionne;

        /// <summary>
        /// ListProduits de DataBaseManager
        /// </summary>
        public List<Produits> ListProduits
        {
            get
            {
                using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
                {
                    var prod = db.Produits.ToList();
                    return prod;
                }
            }
        }
        /// <summary>
        /// ListMasques de DataBaseManager
        /// </summary>
        public List<Masques> ListMasques
        {
            get
            {
                using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
                {
                    return db.Masques.ToList();
                }
            }
        }
        /// <summary>
        /// ListGels de DataBaseManager
        /// </summary>
        public List<Gels> ListGels
        {
            get
            {
                using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
                {
                    return db.Gels.ToList();
                }
            }
        }
        /// <summary>
        /// ListAvis de DataBaseManager
        /// </summary>
        public List<Avis> ListAvis
        {
            get
            {

                using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
                {
                    if (ProduitsSelectionne != null)
                    {
                        return db.Avis.Where(x => x.RefProduit == ProduitsSelectionne.RefProduit).ToList();
                    }
                    return null;
                }

            }
        }
        /// <summary>
        /// ListCommandes de DataBaseManager
        /// </summary>
        public List<Commandes> ListCommandes
        {
            get
            {
                using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
                {
                    return db.Commandes.Where(x => x.Pseudo == UtilisateursEnCours.Pseudo).ToList();
                }
            }
        }
        /// <summary>
        /// NoteMoyenne de DataBaseManager
        /// </summary>
        public string NoteMoyenne
        {
            get
            {
                using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
                {
                    if (ProduitsSelectionne != null)
                    {
                        try
                        {
                            return db.Avis.Where(x => x.RefProduit == ProduitsSelectionne.RefProduit).Average(x => x.Note).ToString() + "/10";
                        }
                        catch (Exception ignore) { }
                    }
                    return null;
                }
            }
            set { }
        }
        /// <summary>
        /// CountPanier de DataBaseManager
        /// </summary>
        public int CountPanier
        {
            set
            {
                OnPropertyChanged(nameof(CountPanier));
            }
            get
            {
                int j = 0;
                foreach (Parameter i in Panier.Values)
                {
                    j += i.Value;
                }
                return j;
            }
        }

        /// <summary>
        /// _panier de DataBaseManager
        /// </summary>
        public Dictionary<Produits, Parameter> _panier 
        { 
            get 
            { 
                return Panier.ToDictionary(x => x.Key, y => y.Value); 
            } 
        }
        /// <summary>
        /// Panier de DataBaseManager
        /// </summary>
        public Dictionary<Produits, Parameter> Panier{get;set;} = new Dictionary<Produits, Parameter>();
        /// <summary>
        /// UtilisateursEnCours de DataBaseManager
        /// </summary>
        public Utilisateurs UtilisateursEnCours { get; set; }
        /// <summary>
        /// PropertyChanged de DataBaseManager
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// OnPropertyChanged
        /// </summary>
        /// <param name="name">Nom de l'attribut</param>
        protected void OnPropertyChanged(string name)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        /// <summary>
        /// Cette methode permet de savoir si un Utilisateurs existe dans la Base de donnée
        /// </summary>
        /// <param name="utilisateurs">Utilisateurs en question</param>
        /// <returns>true si utilisateurs existe / false si inexistant</returns>
        public bool Exist(Utilisateurs utilisateurs)
        {
            using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
            {
                if (db.Utilisateurs.Any(o => o.Pseudo == utilisateurs.Pseudo && o.MotDePasse == utilisateurs.MotDePasse))
                {
                    return true;
                }
                return false;
            }

        }
        /// <summary>
        /// Cette methode permet de savoir si un Utilisateurs est admin dans la Base de donnée
        /// </summary>
        /// <param name="utilisateurs">Utilisateurs en question</param>
        /// <returns>true si admin / false si non admin</returns>
        public bool IsAdmin(Utilisateurs utilisateurs)
        {
            using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
            {
                if (db.Utilisateurs.Any(o => o.Pseudo == utilisateurs.Pseudo && o.IsAdmin == 1 && o.MotDePasse == utilisateurs.MotDePasse))
                {
                    return true;
                }
                return false;
            }

        }
        /// <summary>
        /// Cette méthode permet d'ajouter un Utilisateurs à la base de donnée
        /// </summary>
        /// <param name="utilisateurs">Utilisateurs en question</param>
        public void Ajouter(Utilisateurs utilisateurs)
        {
            using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
            {
                if (!Exist(utilisateurs))
                {
                    db.Utilisateurs.Add(utilisateurs);
                    db.SaveChanges();
                }

            }

        }
        /// <summary>
        /// Cette méthode permet d'ajouter une Propositions à la base de donnée
        /// </summary>
        /// <param name="propositions">Propositions en question</param>
        public void Ajouter(Propositions propositions)
        {
            using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
            {
                db.Propositions.Add(propositions);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Cette méthode permet d'ajouter une Commandes à la base de donnée
        /// </summary>
        /// <param name="commandes">Commandes en question</param>
        public void Ajouter(Commandes commandes)
        {
            using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
            {
                db.Commandes.Add(commandes);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Cette méthode permet d'ajouter un Avis à la base de donnée
        /// </summary>
        /// <param name="avis">Avis en question</param>
        public void Ajouter(Avis avis)
        {
            using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
            {
                if (avis.Commentaire == "")
                {
                    throw new Exception("Le commentaire ne peut pas être vide");
                }
                db.Avis.Add(avis);
                db.SaveChanges();
                OnPropertyChanged(nameof(ListAvis));

            }
        }
        /// <summary>
        /// Cette méthode permet d'ajouter un Produits à la base de donnée
        /// </summary>
        /// <param name="produit">Produits en question</param>
        public void Ajouter(Produits produit)
        {
            using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
            {

                db.Produits.Add(produit);
                db.SaveChanges();
                ActualiserList();
            }
        }
        /// <summary>
        /// Cette méthode permet d'ajouter un Gels à la base de donnée
        /// </summary>
        /// <param name="gel">Gels en question</param>
        public void Ajouter(Gels gel)
        {
            using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
            {
                db.Gels.Add(gel);
                db.SaveChanges();
                ActualiserList();
            }
        }
        /// <summary>
        /// Cette méthode permet d'ajouter un Masques à la base de donnée
        /// </summary>
        /// <param name="masque">Masques en question</param>
        public void Ajouter(Masques masque)
        {
            using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
            {
                db.Masques.Add(masque);
                db.SaveChanges();
                ActualiserList();
            }
        }
        /// <summary>
        /// Cette méthode permet d'ajouter une Commandes à la base de donnée
        /// </summary>
        /// <param name="commandes">Commandes en question</param>
        public void SupprimerCommande(Commandes commandes)
        {
            using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
            {
                db.Commandes.Remove(commandes);
                db.SaveChanges();
                OnPropertyChanged(nameof(ListCommandes));
            }
        }
        /// <summary>
        /// Cette méthode permet d'ajouter dans Panier un Produits et un Parameter
        /// </summary>
        /// <param name="qte">Value du Parameter</param>
        public void AjouterAuPanier(int qte)
        {
            if (Panier.ContainsKey(ProduitsSelectionne))
            {
                Panier[ProduitsSelectionne] = new Parameter(qte+Panier[ProduitsSelectionne].Value);
            }
            else
            {
                Panier.Add(ProduitsSelectionne, new Parameter(qte));
            }
            ActualiserCountPanier();
        }

        /// <summary>
        /// Cette méthode permet de Supprimer un Produits de la Base de donnée
        /// </summary>
        /// <param name="produit">Produits en question</param>
        public void SupprimerProduit(Produits produit)
        {
            using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
            {

                db.Produits.Remove(produit);
                db.SaveChanges();
                ActualiserList();
            }
        }
        /// <summary>
        /// Cette méthode permet de Modifier un Produits de la Base de donnée
        /// </summary>
        /// <param name="produit">Produits en question</param>
        public void ModifierProduit(Produits produit)
        {
            using (azertyiop_coronashopContext db = new azertyiop_coronashopContext())
            {
                db.Produits.Update(produit);
                db.SaveChanges();
                ActualiserList();
            }
        }

        /// <summary>
        /// Cette méthode permet d'actuliser la vue pour ListProduits ListGels ListMasques ListAvis
        /// </summary>
        public void ActualiserList()
        {
            OnPropertyChanged(nameof(ListProduits));
            OnPropertyChanged(nameof(ListGels));
            OnPropertyChanged(nameof(ListMasques));
            OnPropertyChanged(nameof(ListAvis));
        }

        /// <summary>
        /// Cette methode permet d'actualiser la vue pour l'addition de tous les Parameter.Value de Panier
        /// </summary>
        public void ActualiserCountPanier()
        {
            OnPropertyChanged(nameof(CountPanier));
        }
    }
}
