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
    /// Logique d'interaction pour ModifProduitAdminDeux.xaml
    /// </summary>
    public partial class ModifProduit2 : Window
    {
        /// <summary>
        /// DataBaseManager de ModifProduit2 pointant vers DataBaseManager de App
        /// </summary>
        DataBaseManager Manager => (App.Current as App).Manager;
        /// <summary>
        /// Constructeur
        /// </summary>
        public ModifProduit2()
        {
            InitializeComponent();
            DataContext = Manager;
        }

        /// <summary>
        /// PErmet de verifier la modification d'attribut d'un Produits
        /// </summary>
        /// <returns></returns>
        private bool ValideEntree()
        {
            string message = "Saisie Incorrecte \n Veuillez Rentrez des Champs correct ";

            string Prix = TBoxPrix.Text;
            string Provenance = TBoxProvenance.Text;
            string Delai = TBoxProvenance.Text;
            string Ladescription = TBoxDescription.Text;

            bool PrixIsValid = Regex.IsMatch(Prix, @"^[0-9]{1,}[,]{0,1}[0-9]{0,2}$");
            bool ProvenanceIsValid = Regex.IsMatch(Provenance, @"^[A-Za-z]+$");
            bool DelaiIsValid = Regex.IsMatch(Delai, @"^[1-9]{1}[0-9]*$");

            if (Ladescription.Length > 300)
            {
                message = "La description est trop grande veuillez réduire la taille de la description";
                new FenetrePopUp(message, "ok !");
                return false;

            }

            else if (!PrixIsValid && !String.IsNullOrEmpty(Prix))
            {
                message = "Le prix est invalide veuillez n'entrer que des chiffres";
                new FenetrePopUp(message, "ok !");
                return false;
            }
            else if (!ProvenanceIsValid && !String.IsNullOrEmpty(Provenance))
            {
                message = "La provenance est invalide veuillez n'entrer que des lettres";
                new FenetrePopUp(message, "ok !");
                return false;
            }
            else if (!DelaiIsValid && !String.IsNullOrEmpty(Delai))
            {
                message = "Le délai est invalide veuillez n'entrer que des chiffres";
                new FenetrePopUp(message, "ok !");
                return false;
            }

            else return true;

        }


        /// <summary>
        /// Méthode bouton Click. Permet aussi de Modifier un Produits dans la base de donnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string Prix = TBoxPrix.Text;
            string Provenance = TBoxProvenance.Text;
            string Delai = TBoxDelai.Text;
            string Ladescription = TBoxDescription.Text;
            bool verif = ValideEntree();
            if (verif == false)
            {
                this.Close();
            }

            if (!String.IsNullOrEmpty(Prix))
            {

                Manager.ProduitsSelectionnev2.Prix = Convert.ToSingle(TBoxPrix.Text);

            }
            if (!String.IsNullOrEmpty(Provenance))
            {
                Manager.ProduitsSelectionnev2.Provenance = TBoxProvenance.Text;


            }
            if (!String.IsNullOrEmpty(Delai))
            {

                Manager.ProduitsSelectionnev2.DelaisDeLivraison = Convert.ToInt32(TBoxDelai.Text);

            }
            if (!String.IsNullOrEmpty(Ladescription))
            {
                Manager.ProduitsSelectionnev2.Description = TBoxDescription.Text;

            }

            Manager.ModifierProduit(Manager.ProduitsSelectionnev2);

            new FenetrePopUp("adminModificationProduit");
            Close();
        }
    }
}
