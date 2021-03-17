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
    /// Logique d'interaction pour SuiviCommande.xaml
    /// </summary>
    public partial class SuiviCommande : Window
    {
        /// <summary>
        /// DataBaseManager de SuiviCommande pointant vers DataBaseManager de App
        /// </summary>
        DataBaseManager Manager => (App.Current as App).Manager;
        /// <summary>
        /// Constructeur
        /// </summary>
        public SuiviCommande()
        {
            InitializeComponent();
            DataContext = Manager;
            if (Manager.ListCommandes.Count == 0)
            {
                throw new Exception("Vous n'avez aucune commande commande");
            }
        }
        /// <summary>
        /// Méthode bouton Click. Permet de supprimer une Commandes de la Base de donnée.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.SupprimerCommande(SuiviListBox.SelectedItem as Commandes);
            if(Manager.ListCommandes.Count == 0)
            {
                new FenetrePopUp("Vous n'avez plus de commande", "OK!");
                this.Close();
            }
        }
    }
}
