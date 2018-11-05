using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FoodTruck.ViewModel;
using Windows.UI.Popups;
using FoodTruck.Models;
// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace FoodTruck.PageDetails
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Panier : Page
    {
        private PanierViewModel panierViewModel = new PanierViewModel();

        public Panier()
        {
            if ((App.Current as App).IsConnected && (App.Current as App).PanierSession.ProduitDuPanier.LongCount() != 0)
            {
                this.InitializeComponent();
                this.DataContext = panierViewModel;
            }
        }

        private void CheckLivraison(object sender, RoutedEventArgs e)
        {
            VerificationAdresseLivraison.Visibility = Visibility.Visible;

        }
        private void UncheckedLivraison(object sender, RoutedEventArgs e)
        {
            VerificationAdresseLivraison.Visibility = Visibility.Collapsed;
        }

        private void LivraisonAutreAdresseCheck(object sender, RoutedEventArgs e)
        {
            AdresseComplementaire.Visibility = Visibility.Visible;
        }
        private void LivraisonAutreAdresseUnChecked(object sender, RoutedEventArgs e)
        {
            AdresseComplementaire.Visibility = Visibility.Collapsed;
        }

        private void SupprimerDuPanier(object sender, RoutedEventArgs e)
        {
            ((PanierViewModel)this.DataContext).SupprimerPanier.Execute(((Button)sender).CommandParameter.ToString());
        }

        private async void ValiderCommande(object sender, RoutedEventArgs e)
        {
            /// Faire verification si tous les champs sont renseignés correctement 



            if ((bool)CommandeLivraison.IsChecked)
            {
                panierViewModel.CommandeEnCours.TypdeDeLivraisonId = 2;

                if (!(bool)ChangementAdresse.IsChecked)
                {

                    this.panierViewModel.CommandeEnCours.Numero = (App.Current as App).ClientConnecte.Numero;
                    this.panierViewModel.CommandeEnCours.Voie = (App.Current as App).ClientConnecte.Voie;
                    this.panierViewModel.CommandeEnCours.CodePostal = (App.Current as App).ClientConnecte.CodePostal;
                    this.panierViewModel.CommandeEnCours.Ville = (App.Current as App).ClientConnecte.Ville;
                }
                else if ((bool)ChangementAdresse.IsChecked)
                {
                    panierViewModel.CommandeEnCours.TypdeDeLivraisonId = 2;
                    this.panierViewModel.CommandeEnCours.Numero = int.Parse(this.choix_numero.Text.ToString());
                    this.panierViewModel.CommandeEnCours.Voie = this.choix_voie.Text.ToString();
                    this.panierViewModel.CommandeEnCours.CodePostal = int.Parse(this.choix_codePostale.Text.ToString());
                    this.panierViewModel.CommandeEnCours.Ville = this.choix_ville.Text.ToString();
                }
            }
            else if ((bool)CommandeSurPlace.IsChecked)
            {
                panierViewModel.CommandeEnCours.TypdeDeLivraisonId = 1;
                panierViewModel.CommandeEnCours.TypdeDeLivraisonId = 2;
                this.panierViewModel.CommandeEnCours.Numero = 0;
                this.panierViewModel.CommandeEnCours.Voie = null;
                this.panierViewModel.CommandeEnCours.CodePostal = 0;
                this.panierViewModel.CommandeEnCours.Ville = null;
            }

            ((PanierViewModel)this.DataContext).ValiderLaCommande.Execute(((PanierViewModel)this.DataContext).CommandeEnCours);

            await new MessageDialog("Merci de votre commande.\n A bientôt!").ShowAsync();
            (App.Current as App).PanierSession = new ClassePanier();
            this.Frame.Navigate(typeof(Accueil));
        }
    }
}
