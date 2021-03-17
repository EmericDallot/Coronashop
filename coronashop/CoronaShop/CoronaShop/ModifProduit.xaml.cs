using Model;
using Manager;
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
using MaterialDesignThemes.Wpf;

namespace CoronaShop
{
    /// <summary>
    /// Logique d'interaction pour ModifProduit.xaml
    /// </summary>
    public partial class ModifProduit : Window
    {
        /// <summary>
        /// DataBaseManager de ModifProduit pointant vers DataBaseManager de App
        /// </summary>
        DataBaseManager Manager => (App.Current as App).Manager;
        /// <summary>
        /// Constructeur
        /// </summary>
        public ModifProduit()
        {
            InitializeComponent();
            DataContext = Manager;
        }
        /// <summary>
        /// Méthode bouton Click. Permet d'instancier la classe ModifProduit2 et de l'ouvrir en tant que fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new ModifProduit2().ShowDialog();
        }
    }
}
