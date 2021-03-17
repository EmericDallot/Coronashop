using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Manager;
using Model;


namespace CoronaShop
{
    /// <summary>
    /// Logique d'interaction pour Pageprincipale.xaml
    /// </summary>
    public partial class Pageprincipale : Window
    {
        /// <summary>
        /// DataBaseManager de Pageprincipale pointant vers DataBaseManager de App
        /// </summary>
        DataBaseManager Manager => (App.Current as App).Manager;
        /// <summary>
        /// Constructeur
        /// </summary>
        public Pageprincipale()
        {
            InitializeComponent();
            DataContext = Manager;
            if (Manager.IsAdmin(Manager.UtilisateursEnCours))
            {
                ButtonRequetePanelAdmin.Content = "Administration";
            }

        }
        /// <summary>
        /// Méthode bouton Click. 
        /// Permet 
        /// si Manager.UtilisateursEnCours est admin
        /// d'instancier la classe FonctionnalitesAdmin et de l'ouvrir en tant que fenêtre 
        /// sinon 
        ///  d'instancier la classe RequeteProduit et de l'ouvrir en tant que fenêtre 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.IsAdmin(Manager.UtilisateursEnCours))
            {
                new FonctionnalitesAdmin().ShowDialog();
            }
            else
            {
                new RequeteProduit().ShowDialog();
            }
            Manager.ActualiserList();
        }
        /// <summary>
        /// Méthode bouton Click. Permet d'instancier la classe Panier et de l'ouvrir en tant que fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Panier fenetre2 = new Panier();
                fenetre2.ShowDialog();
            }
            catch(Exception ex)
            {
                new FenetrePopUp(ex.Message, "OK!");
            }
        }
        /// <summary>
        /// Méthode bouton Click. Permet d'instancier la classe SuiviCommande et de l'ouvrir en tant que fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                SuiviCommande fenetre3 = new SuiviCommande();
                fenetre3.ShowDialog();
            }
            catch (Exception ex)
            {
                new FenetrePopUp(ex.Message, "OK!");
            }
        }

        /// <summary>
        /// Permet de faire un recherche a partir de textBoxSearch.Text dans listBoxData.ItemsSource avec Linq
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((bool)radioMasques.IsChecked)
            {
                listBoxData.ItemsSource = Manager.ListMasques.Where(m => m.Nom.Contains(textBoxSearch.Text));
            }
            else if ((bool)radioGels.IsChecked)
            {
                listBoxData.ItemsSource = Manager.ListGels.Where(m => m.Nom.Contains(textBoxSearch.Text));
            }
            else
            {
                listBoxData.ItemsSource = Manager.ListProduits.Where(m => m.Nom.Contains(textBoxSearch.Text));
            }
        }
        /// <summary>
        /// Permet d'afficher ListMasques de Manager dans ListboxData 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioMasques_Checked(object sender, RoutedEventArgs e)
        {

            if (listBoxData != null)
            {
                try
                {
                    listBoxData.ItemsSource = Manager.ListMasques;
                }
                catch { }
            }
        }
        /// <summary>
        /// Permet d'afficher ListProduits de Manager dans ListBoxData
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioTous_Checked(object sender, RoutedEventArgs e)
        {
            if (listBoxData != null)
            {
                try
                {
                    listBoxData.ItemsSource = Manager.ListProduits;
                }
                catch { }
            }

        }
        /// <summary>
        /// Permet d'afficher ListGels de Manager dans ListBoxData
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioGels_Checked(object sender, RoutedEventArgs e)
        {

            if (listBoxData != null)
            {
                try
                {
                    listBoxData.ItemsSource = Manager.ListGels;
                }
                catch { }
            }
        }
        /// <summary>
        /// Méthode bouton Click. Permet d'instancier la classe NouveauCommentaire et de l'ouvrir en tant que fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new NouveauCommentaire().ShowDialog();
            }
            catch (Exception ex)
            {
                new FenetrePopUp(ex.Message, "OK!");
            }
        }
        /// <summary>
        /// Méthode bouton Click. Permet d'instancier la classe AjouterAuPanier et de l'ouvrir en tant que fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AjouterAuPanier panier = new AjouterAuPanier();
                panier.ShowDialog();
            }
            catch (Exception ex)
            {
                new FenetrePopUp(ex.Message, "OK!");
            }

        }
        /// <summary>
        /// Méthode bouton Click. Instancie un nouveau Manager.
        /// Permet d'instancier la classe MainWindows et de l'ouvrir en tant que fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeconnexionButton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).Manager = new DataBaseManager();
            new MainWindow().Show();
            Close();
        }
    }
}
