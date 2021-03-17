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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoronaShop.usercontrols
{
    /// <summary>
    /// Logique d'interaction pour PopUp.xaml
    /// </summary>
    public partial class PopUp : UserControl
    {
        /// <summary>
        /// Type de PopUp
        /// </summary>
        private string type;
        /// <summary>
        /// ButtonActionEvent de PopUp
        /// </summary>
        public static readonly RoutedEvent ButtonActionEvent = EventManager.RegisterRoutedEvent("ButtonAction", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(PopUp));
        /// <summary>
        /// Constructeur
        /// </summary>
        public PopUp()
        {
            InitializeComponent();
            SetType("connexion");
        }
        /// <summary>
        /// Méthode permettant de s'abonner à l'event ButtonActionEvent
        /// </summary>
        public event RoutedEventHandler ButtonAction
        {
            add { AddHandler(ButtonActionEvent, value); }
            remove { RemoveHandler(ButtonActionEvent, value); }
        }
        /// <summary>
        /// Méthode permettant d'élever l'event ButtonActionEvent
        /// </summary>
        void RaiseButtonActionEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ButtonActionEvent);
            RaiseEvent(newEventArgs);
        }
        /// <summary>
        /// Permet d'appeler la Méthode RaiseButtonActionEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseButtonActionEvent();
        }
        /// <summary>
        /// Permet de changer la vue
        /// </summary>
        /// <param name="type">Type de PopUp</param>
        public void SetType(string type)
        {
            if (type == "connexion")
            {
                this.type = type;
                DescriptionTextBlock.Text = "Connexion réussie";
                ValidButton.Content = "Bienvenue";
            }
            else if (type == "inscription")
            {
                this.type = type;
                DescriptionTextBlock.Text = "Inscription réussie :D";
                ValidButton.Content = "Se connecter";
            }
            else if (type == "existant")
            {
                this.type = type;
                DescriptionTextBlock.Text = "Nom d'utilisateur déjà existant. Veuillez réessayer.";
                ValidButton.Content = "S'inscrire";
            }
            else if (type == "id")
            {
                this.type = type;
                DescriptionTextBlock.Text = "Problème identifiant / mot de passe";
                ValidButton.Content = "Retour";
            }
            else if (type == "adminSuppressionProduit")
            {
                this.type = type;
                DescriptionTextBlock.Text = "Suppression reussie! :D";
                ValidButton.Content = "OK!";
            }
            else if (type == "adminAjoutProduit")
            {
                this.type = type;
                DescriptionTextBlock.Text = "Produit bien ajouté ^^";
                ValidButton.Content = "OK!";

            }
            else if (type == "adminModificationProduit")
            {
                this.type = type;
                DescriptionTextBlock.Text = " Modification réussie xD";
                ValidButton.Content = "OK!";
            }
            else
            {
                throw new ArgumentException("Attribut Type non précisé dans la class PopUp");
            }
        }
        /// <summary>
        /// Permet de Changer la vue
        /// </summary>
        /// <param name="description">Text DescriptionTextBlock</param>
        /// <param name="content">Content de ValidButton</param>
        public void SetTypePerso(string description, string content)
        {
            this.type = "perso";
            DescriptionTextBlock.Text = description;
            ValidButton.Content = content;
        }
        /// <summary>
        /// return Type
        /// </summary>
        /// <returns>Type de PopUp</returns>
        public String GetTypeAttribut()
        {
            return type;
        }

    }
}
