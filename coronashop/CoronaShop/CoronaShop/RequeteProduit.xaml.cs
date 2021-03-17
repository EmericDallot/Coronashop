using Manager;
using Model;
using System;
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

namespace CoronaShop
{
    /// <summary>
    /// Logique d'interaction pour RequeteProduit.xaml
    /// </summary>
    public partial class RequeteProduit : Window
    {
        /// <summary>
        /// DataBaseManager de RequeteProduit pointant vers DataBaseManager de App
        /// </summary>
        DataBaseManager Manager => (App.Current as App).Manager;
        /// <summary>
        /// Constructeur
        /// </summary>
        public RequeteProduit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Méthode bouton Click. Permet d'ajouté une Propositions à la base de donnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PropositionBouton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if(Information.Text == "Veuillez saisir vos Informations...")
                {
                    throw new Exception("Proposition invalide");
                }
                Propositions propositions = new Propositions(Information.Text);
                Manager.Ajouter(propositions);
                new FenetrePopUp("Votre proposition va être étudiée par les administrateurs.\nL'équipe Coronashop vous remercie.", "OK!");
                Close();
            }
            catch(Exception ex)
            {
                new FenetrePopUp(ex.Message, "OK!");
            }
        }
        /// <summary>
        /// Méthode GotFocus. Information.Text = ""
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Information_GotFocus(object sender, RoutedEventArgs e)
        {
            Information.Text = "";
        }

    }
}
