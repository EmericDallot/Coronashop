using System;
using System.Windows;
using System.Windows.Controls;
using Manager;


namespace CoronaShop
{
    /// <summary>
    /// Logique d'interaction pour AjouterAuPanier.xaml
    /// </summary>
    public partial class AjouterAuPanier : Window
    {
        /// <summary>
        /// DataBaseManager de AjouterAuPanier pointant vers DataBaseManager de App
        /// </summary>
        DataBaseManager Manager => (App.Current as App).Manager;
        /// <summary>
        /// Qte de AjouterAuPanier
        /// </summary>
        public int Qte { get; private set; }
        /// <summary>
        /// Constructeur
        /// </summary>
        public AjouterAuPanier()
        {
            Qte = 0;
            DataContext = Manager;
            InitializeComponent();
            if(Manager.ProduitsSelectionne == null)
            {
                throw new Exception("Aucun produit selectionné");
            }
        }
        /// <summary>
        /// Méthode bouton permettant d'ajouter un produits à la base de donnée.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Qte = Convert.ToInt32(SliderQte.Value);
            if (Qte != 0)
            {
                Manager.AjouterAuPanier(Qte);
                new FenetrePopUp("Le produit a bien été ajouté au panier", "OK!");
                this.Close();
            }

        }
        /// <summary>
        /// Méthode slider permettant d'afficher Slider.Value dans PositionSlider.Text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        { 
            var slider = sender as Slider;
            double value = slider.Value;
            PositionSlider.Text = string.Format("{0:0}", value);
        }
    }
}
