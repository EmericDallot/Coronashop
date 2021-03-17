using Manager;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace CoronaShop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// DataBaseManager de cette classe. Il est commun à toute l'application est utilisé par la vue.
        /// </summary>
        public DataBaseManager Manager { get; set; } = new DataBaseManager();
        /// <summary>
        /// Définit la langue de l'application.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(
                    CultureInfo.CurrentCulture.IetfLanguageTag)));
            base.OnStartup(e);
        }

    }
}
