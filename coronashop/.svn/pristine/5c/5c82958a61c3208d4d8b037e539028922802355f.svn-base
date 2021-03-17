using System;
using System.Collections.Generic;
using System.IO;
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
using Manager;
using Model;

namespace CoronaShop.usercontrols
{
    /// <summary>
    /// Logique d'interaction pour Detail.xaml
    /// </summary>
    public partial class Detail : UserControl
    {
        /// <summary>
        /// DataBaseManager de Detail pointant vers DataBaseManager de App
        /// </summary>
        DataBaseManager Manager => (App.Current as App).Manager;
        /// <summary>
        /// Constructeur
        /// </summary>
        public Detail()
        {
            InitializeComponent();
            DataContext = Manager;
        }

    }
}
