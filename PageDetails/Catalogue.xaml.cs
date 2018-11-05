using FoodTruck.DataLayer;
using FoodTruck.Models;
using FoodTruck.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace FoodTruck.PageDetails
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Catalogue : Page
    {
        public Catalogue()
        {
            this.InitializeComponent();
            DataContext = new RepasViewModel((App.Current as App).ConnectionString);

        }

        private void ListView_TypeRepasClick(object sender, ItemClickEventArgs e)
        {
            monComboxJour.Visibility = Visibility.Visible;
            comboxAJour.SelectedItem = "";
            ((RepasViewModel)DataContext).NosProduit = new ObservableCollection<ClasseProduit>();



            ((RepasViewModel)DataContext).TypeDeRepasChoisi = (e.ClickedItem as ClasseRepas).RepasType;

            ProduitRepasDataLayer DataLayer = new ProduitRepasDataLayer();
            //DataLayer.GetProduitRepas(((App.Current as App).ConnectionString), TypeDeRepasChoisi);
            ((RepasViewModel)DataContext).NosProduit = DataLayer.GetProduitRepas(((App.Current as App).ConnectionString), ((RepasViewModel)DataContext).TypeDeRepasChoisi);
            
        }
        private async void comboxAJour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProduitRepasDataLayer DataLayer = new ProduitRepasDataLayer();
            //DataLayer.GetProduitRepas(((App.Current as App).ConnectionString), TypeDeRepasChoisi);
            ((RepasViewModel)DataContext).NosProduit = DataLayer.GetProduitRepas(((App.Current as App).ConnectionString), ((RepasViewModel)DataContext).TypeDeRepasChoisi);



            ((RepasViewModel)DataContext).indexJour = this.comboxAJour.SelectedIndex;
            if ((App.Current as App).IsConnected && (App.Current as App).PanierSession.ProduitDuPanier.LongCount() != 0)
            {
                await new MessageDialog("Votre panier est réinitialisé, car vous ne pouvez pas commander à des dates différents").ShowAsync();
                (App.Current as App).PanierSession = new ClassePanier();
            }
            string lecteur =(this.comboxAJour.SelectedItem as ClassDiponibilitéJour).DisponibiliteJour;

            foreach (var item in ((RepasViewModel)DataContext).NosProduit)
            {
                if (item.JoursDispo.Contains(lecteur))
                    item.isEnable = true;
                else { item.isEnable = false; }
            }

            AffichageProduitSelonTypeChoisi.Visibility = Visibility.Visible;

            


        }


       

        #region Essai
        //private void ListView_ProduitClick(object sender, ItemClickEventArgs e)
        //{
        //    ClasseProduit produitChoisi = (e.ClickedItem as ClasseProduit);


        //    string TypeProduitChoisi = (e.ClickedItem as ClasseProduit).ProductNom;
        //    ProduitRepasDataLayer DataLayerProduit = new ProduitRepasDataLayer();
        //    DataLayerProduit.GetProduitCarte(((App.Current as App).ConnectionString), TypeProduitChoisi);

        //    ((RepasViewModel)DataContext).prdtobtenu = DataLayerProduit.GetProduitCarte(((App.Current as App).ConnectionString), TypeProduitChoisi);

        //}
        #endregion
        private async void ListView_ProduitClick(object sender, RoutedEventArgs e)
        {
            if (!(App.Current as App).IsConnected)
                await new MessageDialog("Veuillez vous connecter pour commander.").ShowAsync();
            else
            {
                ((RepasViewModel)this.DataContext).AjoutPanier.Execute(((Button)sender).CommandParameter.ToString());
                string contenuPanier = (App.Current as App).PanierSession.AffichagePanier();
                await new MessageDialog(contenuPanier).ShowAsync();
            }

        }

       
    }
}
