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
    /// Logique d'interaction pour SupprimerProduitAdmin.xaml
    /// </summary>
    public partial class SupprimerProduitAdmin : Window
    {
        /// <summary>
        /// DataBaseManager de SupprimerProduitAdmin pointant vers DataBaseManager de App
        /// </summary>
        DataBaseManager Manager => (App.Current as App).Manager;
        /// <summary>
        /// Constructeur
        /// </summary>
        public SupprimerProduitAdmin()
        {
            InitializeComponent();
            DataContext = Manager;
        }
        /// <summary>
        /// Méthode Bouton Click. Permet de Supprimer un Produits de la base de donnée.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ProduitsListBox.SelectedItem != null)
            {
                Manager.SupprimerProduit(ProduitsListBox.SelectedItem as Produits);
                FenetrePopUp fenetre = new FenetrePopUp("adminSuppressionProduit");
            }

        }
    }
}
