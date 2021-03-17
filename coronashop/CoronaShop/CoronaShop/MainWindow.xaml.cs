using CoronaShop.usercontrols;
using System.Windows;
using System;
using System.Data;


namespace CoronaShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="type">Type de UtilisateurMyControls</param>
        public MainWindow(string type)
        {
            InitializeComponent();
            UtilisateurMyControls.SetType(type);
        }
        /// <summary>
        /// Permet de fermer la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UtilisateurMyControls_Connexion(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
