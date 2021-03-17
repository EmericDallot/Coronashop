using Manager;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CoronaShop
{
    /// <summary>
    /// Logique d'interaction pour Panier.xaml
    /// </summary>
    public partial class Panier : Window
    {
        /// <summary>
        /// DataBaseManager de Panier pointant vers DataBaseManager de App
        /// </summary>
        DataBaseManager Manager => (App.Current as App).Manager;
        /// <summary>
        /// Constructeur
        /// </summary>
        public Panier()
        {
            InitializeComponent();
            DataContext = Manager;
            if(Manager.Panier.Count == 0)
            {
                throw new Exception("Votre panier est vide!");
            }
            
        }

        /// <summary>
        /// Méthode bouton Click. Permet d'Ajouter une Commandes à la base de donnée.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Commandes commandes = new Commandes(Manager.UtilisateursEnCours, Manager.Panier);
                Manager.Ajouter(commandes);
                Manager.Panier.Clear();
                Manager.ActualiserCountPanier();
                new FenetrePopUp("Votre commande a été acceptée", "OK!");
                Close();
            }
            catch(Exception ex)
            {
                new FenetrePopUp(ex.Message, "OK!");
            }
        }
        /// <summary>
        /// Méthode bouton Click. Permet de réduire de 1 le Parameter.Value ou si Parameter.Value supprime le Produits du Panier de Manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var KeyPair = (sender as Button).DataContext;

            if (KeyPair != null)
            {
                KeyValuePair<Produits, Parameter> KeyPair2 = (KeyValuePair<Produits, Parameter>)KeyPair;
                if (KeyPair2.Value.Value == 1)
                {
                    Manager.Panier.Remove(KeyPair2.Key);
                    new FenetrePopUp("\"" + KeyPair2.Key.Nom + "\" supprimé de votre panier", "OK!");
                    if (Manager.Panier.Count == 0)
                    {
                        new FenetrePopUp("Votre panier est maintenant vide", "OK!");
                        Close();
                    }
                    DataContext = null;
                    DataContext = Manager;
                }
                else
                {
                    Manager.Panier[KeyPair2.Key].Value -= 1;
                }
            }
            Manager.ActualiserCountPanier();

        }
        /// <summary>
        /// Méthode bouton Click. Permet d'ajouter 1 à Parameter.Value de Panier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var KeyPair = (sender as Button).DataContext;

            if (KeyPair != null)
            {
                KeyValuePair<Produits, Parameter> KeyPair2 = (KeyValuePair<Produits, Parameter>)KeyPair;
                Manager.Panier[KeyPair2.Key].Value += 1;
            }
            Manager.ActualiserCountPanier();
        }
    }
}
