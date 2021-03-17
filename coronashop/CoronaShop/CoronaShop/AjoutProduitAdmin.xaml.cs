using Model;
using System;
using Manager;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unite;
using Microsoft.Win32;

namespace CoronaShop
{
    /// <summary>
    /// Logique d'interaction pour AjoutProduitAdmin.xaml
    /// </summary>
    public partial class AjoutProduitAdmin : Window
    {
        /// <summary>
        /// DataBaseManager de AjoutProduitAdmin pointant vers DataBaseManager de App
        /// </summary>
        DataBaseManager Manager => (App.Current as App).Manager;
        /// <summary>
        /// Source de AjoutProduitsAdmin
        /// </summary>
        string Source;
        /// <summary>
        /// Constructeur
        /// </summary>
        public AjoutProduitAdmin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Activation pour créer un Masques
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBoxButton1_Checked(object sender, RoutedEventArgs e)
        {
            TBoxContenance.IsEnabled = false;
            TBoxButtonM2.IsEnabled = true;
            TBoxButtonM1.IsEnabled = true;
            Combovolume.IsEnabled = false;
        }
        /// <summary>
        /// Activation pour créer un Gels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBoxButton2_Checked(object sender, RoutedEventArgs e)
        {
            TBoxButtonM2.IsEnabled = false;
            TBoxButtonM1.IsEnabled = false;
            TBoxContenance.IsEnabled = true;
            Combovolume.IsEnabled = true;
        }
        /// <summary>
        /// Méthode Bouton Click. Permet d'ajouter un Produits à la base de donnée.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TBoxButton1.IsChecked == true)
                {
                    if (TBoxButtonM1.IsChecked == true)
                    {
                        Masques mas = new Masques(TBoxRef.Text, "FFP1", Convert.ToInt32(TBoxDelai.Text), Convert.ToSingle(TBoxPrix.Text), TBoxNom.Text, TBoxDescription.Text, TBoxProvenance.Text, Source);
                        Manager.Ajouter(mas);
                    }
                    else
                    {
                        Masques mas = new Masques(TBoxRef.Text, "FFP2", Convert.ToInt32(TBoxDelai.Text), Convert.ToSingle(TBoxPrix.Text), TBoxNom.Text, TBoxDescription.Text, TBoxProvenance.Text, Source);
                        Manager.Ajouter(mas);
                    }
                }
                else
                {
                    Gels gel = new Gels(TBoxRef.Text, Convert.ToSingle(TBoxContenance.Text), (Volume)Combovolume.SelectedIndex+1, Convert.ToInt32(TBoxDelai.Text), Convert.ToSingle(TBoxPrix.Text), TBoxNom.Text, TBoxDescription.Text, TBoxProvenance.Text, Source);
                    Manager.Ajouter(gel);
                }
                this.Close();
                FenetrePopUp fenetre = new FenetrePopUp("adminAjoutProduit");
            }
            catch(Exception ex)
            {
                new FenetrePopUp(ex.Message, "OK !");
            }

        }
        /// <summary>
        /// Méthode Bouton Click. Permet l'ouverture d'un  OpenFileDialog pour ajouter le Path d'un image dans Source.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Selectionner une image";
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bin) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bin";
            if (openFileDialog.ShowDialog() == true)
            {
                Source = openFileDialog.FileName;
            }
        }
    }
}

