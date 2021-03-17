using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using Model;
using Manager;

namespace CoronaShop.usercontrols
{
    /// <summary>
    /// Logique d'interaction pour UtilisateurConnexionInscription.xaml
    /// </summary>
    public partial class UtilisateurConnexionInscription : UserControl
    {
        /// <summary>
        /// DataBaseManager de UtilisateurConnexionInscription pointant vers DataBaseManager de App
        /// </summary>
        DataBaseManager Manager => (App.Current as App).Manager;
        /// <summary>
        /// Type de UtilisateurConnexionInscription
        /// </summary>
        private string type;
        /// <summary>
        /// ConnexionEvent de UtilisateurConnexionInscription
        /// </summary>
        public static readonly RoutedEvent ConnexionEvent = EventManager.RegisterRoutedEvent("Connexion", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(UtilisateurConnexionInscription));
        /// <summary>
        /// Username de UtilisateurConnexionInscription
        /// </summary>
        private string Username
        {
            get
            {
                return UsernameTextBox.Text;
            }
        }
        /// <summary>
        /// Password de UtilisateurConnexionInscription
        /// </summary>
        private string Password
        {
            get
            {
                return PasswordPasswordBox.Password.ToString();
            }
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        public UtilisateurConnexionInscription()
        {
            InitializeComponent();
            SetType("connexion");
        }
        /// <summary>
        /// Méthode permettant de s'abonner à l'event ConnexionEvent
        /// </summary>
        public event RoutedEventHandler Connexion
        {
            add { AddHandler(ConnexionEvent, value); }
            remove { RemoveHandler(ConnexionEvent, value); }
        }
        /// <summary>
        /// Méthode permettant d'élever l'event ButtonActionEvent ConnexionEvent
        /// </summary>
        void RaiseConnexionEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ConnexionEvent);
            RaiseEvent(newEventArgs);
        }
        /// <summary>
        /// Permet de changer la vue
        /// </summary>
        /// <param name="type"></param>
        public void SetType(String type)
        {
            if (type == "connexion")
            {
                this.type = type;
                TitleTextblock.Text = "Se connecter";
                LogInButton.Content = "Se connecter";
                IsNewTextBlock.Text = "Vous êtes nouveau?";
            }
            else if (type == "inscription")
            {
                this.type = type;
                TitleTextblock.Text = "S'inscrire";
                LogInButton.Content = "S'inscrire";
                IsNewTextBlock.Text = "Vous avez déjà un compte?";
            }
            else
            {
                throw new ArgumentException("Attribut Type non précisé dans la class UtilisateurConnexionInscription");
            }
        }
        /// <summary>
        /// Permet d'appeler la méthode SetType
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterButtonTextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (type == "connexion")
                {
                    SetType("inscription");
                }
                else
                {
                    SetType("connexion");
                }
            }
            catch(Exception e1)
            {
                new FenetrePopUp(""+e1, "OK!");
            }

        }
        /// <summary>
        /// Permet de se connecter ou d'ajouter un Utilisateur a la Base de donnée
        /// </summary>
        public void ActionConnexionInscription()
        {
            try
            {
                Utilisateurs utilisateur = new Utilisateurs(Username, Password);
                if (type == "connexion")
                {
                    if (Manager.Exist(utilisateur))
                    {
                        new FenetrePopUp("connexion");
                        Manager.UtilisateursEnCours = utilisateur;
                        new Pageprincipale().Show();
                        RaiseConnexionEvent(); //Fermeture de la form
                    }
                    else
                    {
                        new FenetrePopUp("id");
                    }
                }
                else if (type == "inscription")
                {

                    if (Manager.Exist(utilisateur))
                    {
                        new FenetrePopUp("existant");
                    }
                    else
                    {
                        Manager.Ajouter(utilisateur);
                        new FenetrePopUp("inscription");
                        SetType("connexion");
                    }

                }
            }
            catch (Exception ex)
            {
                new FenetrePopUp(ex.Message, "OK !");
            }
        }
        /// <summary>
        /// Appelle la Méthode ActionConnexionInscription
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            ActionConnexionInscription();
        }
        /// <summary>
        /// Appelle ActionConnexionInscription avec la touche entree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordPasswordBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ActionConnexionInscription();
            }
        }
        /// <summary>
        /// Appelle ActionConnexionInscription avec la touche entree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsernameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ActionConnexionInscription();
            }
        }
    }
}
