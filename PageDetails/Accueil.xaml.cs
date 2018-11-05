using Marduk.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FoodTruck.Utilitaire;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace FoodTruck.PageDetails
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Accueil : Page
    {

        public Accueil()
        {
            this.InitializeComponent();
            DataContext = new ProduitViewModel((App.Current as App).ConnectionString);
            this.PhraseAccueil.Text = $"Bienvenue {(App.Current as App).ClientConnecte.Prenom} dans votre food truck";
            List<TestItem> testItems = new List<TestItem>()
            {
                new TestItem() {Name="Pizza", Image = "ms-appx:///Assets/pizza.jpg"},
                new TestItem() {Name="Sandwich bolognaise", Image = "ms-appx:///Assets/sandwich_bolognaise.jpg"},
                new TestItem() {Name="Sandwich poulet",  Image = "ms-appx:///Assets/sandwich_poulet.jpg"},
                new TestItem() {Name="Assortiment de viennoiserie", Image = "ms-appx:///Assets/viennoiserie.jpg"},
                new TestItem() {Name="Café", Image = "ms-appx:///Assets/cafe.jpg"},
                new TestItem() {Name="Wok",  Image = "ms-appx:///Assets/wok.jpg"},
            };

            EasyCarousel.ItemsSource = testItems;

            var directions = new List<EasyCarousel.CarouselShiftingDirection>()
            {
                EasyCarousel.CarouselShiftingDirection.Forward,
                EasyCarousel.CarouselShiftingDirection.Backward
            };




        }
        //Boutton gauche et droite carousel
        private void button_Click(object sender, RoutedEventArgs e)
        {
            EasyCarousel.MoveBackward();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EasyCarousel.MoveForward();
        }
        private async void nc_ItemTapped(object sender, FrameworkElement e)
        {
            await new MessageDialog((e?.DataContext as TestItem)?.Name).ShowAsync();
        }


        private async void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClasseProduit produitFavorisSelectionne = (e.ClickedItem as ClasseProduit);
            string affichage = $"{produitFavorisSelectionne.ProductNom} : {produitFavorisSelectionne.ProductDescription}.\n" +
                $"Son prix est de  {produitFavorisSelectionne.ProductPrix} €";
            await new MessageDialog(affichage).ShowAsync();
        }

    }


}

