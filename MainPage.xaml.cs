using FoodTruck.ViewModel;
using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using FoodTruck.PageDetails;
using Windows.System;
using Windows.UI.Xaml.Navigation;
using System.Linq;
using System.Collections.Generic;
using FoodTruck.Utilitaire;
using Windows.UI.Xaml.Media.Imaging;
using System.Drawing;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FoodTruck
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ApplicationView currentView;
        public MainPage()
        {
            this.InitializeComponent();

            // Set up reference to this window so secondary windows can find it
            (App.Current as App).MainPageInstance = this;

            // This is needed to ensure secondary windows are all closed when this one is
            currentView = ApplicationView.GetForCurrentView();
            currentView.Consolidated += CurrentView_Consolidated;

            Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            currentView.TitleBar.ButtonBackgroundColor = Colors.Transparent;
            currentView.TitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }

        private void CurrentView_Consolidated(ApplicationView sender, ApplicationViewConsolidatedEventArgs args)
        {
            // Clean up code to shut down secondary windows as this one closes
            Application.Current.Exit();
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            //Image myImage = new Image();
            //myImage.Source = new BitmapImage(new Uri(this.BaseUri, "telechargement.png"));
            //myImage.Width = 500;
            //myImage.Height = 500;

           // NavView.MenuItems.Add(myImage);
            NavView.MenuItems.Add(new NavigationViewItem()
            { Content = "Accueil", Icon = new SymbolIcon(Symbol.Home), Tag = "accueil", AccessKey = "P" });
            NavView.MenuItems.Add(new NavigationViewItem()
            { Content = "Catalogue", Icon = new SymbolIcon(Symbol.Shop), Tag = "catalogue", AccessKey = "N" });
            NavView.MenuItems.Add(new NavigationViewItem()
            { Content = "Compte", Icon = new SymbolIcon(Symbol.Contact), Tag = "compte", AccessKey = "O" });

            NavView.MenuItems.Add(new NavigationViewItem()
            { Content = "Panier", Icon = new SymbolIcon(Symbol.Shop), Tag = "panier", AccessKey = "D" });

            NavView_ItemInvoked(NavView, null);
        }

        private async void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            object item = "Accueil";
            if (args != null)
            {
                item = args.InvokedItem;
            }
            switch (item)
            {
                case "Catalogue":
                    NavView.Header = "   Catalogue des produits";
                    ContentFrame.Navigate(typeof(Catalogue));
                    break;

                case "Compte":
                    NavView.Header = "   Compte";
                    ContentFrame.Navigate(typeof(Compte));
                    break;

                case "Accueil":
                    NavView.Header = $"   ";
                    ContentFrame.Navigate(typeof(Accueil));
                    break;

                case "Panier":
                    NavView.Header = "   Ensemble de vos produits ajoutés au paniers";
                    ContentFrame.Navigate(typeof(Panier));
                    break;
            }
        }

        #region Mail
        private async void Contact_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GestionMail gestionMail = new GestionMail();
            await gestionMail.ComposeEmailDemandeInformation();
        }
        #endregion
    }
}

