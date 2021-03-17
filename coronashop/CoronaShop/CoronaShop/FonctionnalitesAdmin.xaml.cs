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
    /// Logique d'interaction pour FonctionnalitesAdmin.xaml
    /// </summary>
    public partial class FonctionnalitesAdmin : Window
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public FonctionnalitesAdmin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Méthode bouton Click. Permet d'instancier la classe AjoutProduitAdmin et de l'ouvrir en tant que fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AjoutProduitAdmin().ShowDialog();
        }
        /// <summary>
        /// Méthode bouton Click. Permet d'instancier la classe ModifProduit et de l'ouvrir en tant que fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new ModifProduit().ShowDialog();
        }
        /// <summary>
        /// Méthode bouton Click. Permet d'instancier la classe SupprimerProduitAdmin et de l'ouvrir en tant que fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new SupprimerProduitAdmin().ShowDialog();
        }
    }
}
