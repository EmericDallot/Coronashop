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
    /// Logique d'interaction pour FenetrePopUp.xaml
    /// </summary>
    public partial class FenetrePopUp : Window
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public FenetrePopUp()
        {
            InitializeComponent();
            ShowDialog();
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="type">Type de PopUp</param>
        public FenetrePopUp(String type)
        {
            InitializeComponent();
            PopUp.SetType(type);
            ShowDialog();
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="description">Description de PopUp</param>
        /// <param name="content">Content de PopUp</param>
        public FenetrePopUp(String description,String content)
        {
            InitializeComponent();
            PopUp.SetTypePerso(description, content);
            ShowDialog();
        }
        /// <summary>
        /// Méthode bouton Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopUp_ButtonAction(object sender, RoutedEventArgs e)
        {
            ButtonAction();   
        }
        /// <summary>
        /// Méthode permettant de changer la vue.
        /// </summary>
        public void ButtonAction()
        {
            if (PopUp.GetTypeAttribut() == "connexion")
            {
            }
            else if (PopUp.GetTypeAttribut() == "inscription")
            {

            }
            else if (PopUp.GetTypeAttribut() == "existant")
            {

            }
            else if (PopUp.GetTypeAttribut() == "id")
            {

            }
            else if (PopUp.GetTypeAttribut() == "adminSuppressionProduit")
            {
                
            }
            else if (PopUp.GetTypeAttribut() == "adminAjoutProduit")
            {
                
            }
            else if (PopUp.GetTypeAttribut() == "adminModificationProduit")
            {
                
            }
            else if (PopUp.GetTypeAttribut() == "perso")
            {
            }
            else
            {
                throw new ArgumentException("Attribut Type non précisé dans la class PopUp");
            }
            Close();
        }
        /// <summary>
        /// Méthode permettant d'appeler la méthode ButtonAction() avec la touche entrée du clavier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonAction();
            }
        }
    }
}
