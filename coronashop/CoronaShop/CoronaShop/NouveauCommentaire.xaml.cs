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
    /// Logique d'interaction pour NouveauCommentaire.xaml
    /// </summary>
    public partial class NouveauCommentaire : Window
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public NouveauCommentaire()
        {
            InitializeComponent();
            if(Manager.ProduitsSelectionne==null)
            {
                throw new Exception("Aucun produit selectionné");
            }
        }
        /// <summary>
        /// DataBaseManager de NouveauCommentaire pointant vers DataBaseManager de App
        /// </summary>
        private DataBaseManager Manager => (App.Current as App).Manager;

        /// <summary>
        /// Méthode slider. Permettant de mettre Slider.value dans PositionSlider.Text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            var slider = sender as Slider;
            double value = slider.Value;
            PositionSlider.Text = string.Format("{0:0}", value);
        }
        /// <summary>
        /// Méthode bouton Click. Permet d'ajouter un commentaire à la base donnée.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Avis avis = new Avis(Manager.UtilisateursEnCours,Manager.ProduitsSelectionne, Convert.ToInt32(Slider.Value), TextBoxComment.Text) ;
                Manager.Ajouter(avis);
                new FenetrePopUp("Le commentaire à bien été ajouté", "OK!");
                Close();
            }
            catch(Exception ex)
            {
                new FenetrePopUp(ex.Message, "OK!");
            }
        }
    }
}
