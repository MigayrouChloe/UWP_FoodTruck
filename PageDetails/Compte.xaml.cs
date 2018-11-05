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
using System.Security.Cryptography;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;
using FoodTruck.Utilitaire;
using Windows.UI.Popups;
using FoodTruck.Models;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace FoodTruck.PageDetails
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Compte : Page
    {

        private ClientViewModel clientViewModelConnexion = new ClientViewModel();
        private ClientViewModel clientViewModelInscription = new ClientViewModel();

        public Compte()
        {
            this.InitializeComponent();
            this.inscription.DataContext = clientViewModelInscription;
            this.Connexion.DataContext = clientViewModelConnexion;
            //this.DataContext = clientViewModel;
        }

        private void HandleCheckCompte(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            string item = rb.Content.ToString();
            if (item == "Particulier")
                clientViewModelInscription.Client.TypeClientId = 1;
            else clientViewModelInscription.Client.TypeClientId = 2;
        }
        private void HandleCheckCivilite(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            string item = rb.Content.ToString();
            if (item == "Homme")
                clientViewModelInscription.Client.CiviliteId = 1;
            else clientViewModelInscription.Client.CiviliteId = 2;
        }

        private async void Mdp_HashInscription(object sender, RoutedEventArgs e)
        {
            GestionMdpHash gestionHash = new GestionMdpHash();
            string hashTest = gestionHash.UseHash(choix_Mdp_test.Password);
            string hashTest_Verif = gestionHash.UseHash(choix_Mdp_test_verif.Password);

            if (hashTest == hashTest_Verif)
            {
                clientViewModelInscription.Client.MotDePasse = hashTest;
                ((ClientViewModel)this.inscription.DataContext).ValiderInscription.Execute((sender as Button).CommandParameter as ClasseClient);
                await new MessageDialog(clientViewModelInscription.InformationInscription).ShowAsync();
                if ((App.Current as App).IsConnected)
                    this.Frame.Navigate(typeof(Accueil));
            }
            else { await new MessageDialog("Veuillez vérifier vos saisies de mot de passe.").ShowAsync(); }
        }

        private async void Mdp_HashConnexion(object sender, RoutedEventArgs e)
        {
            GestionMdpHash gestionHash = new GestionMdpHash();
            clientViewModelConnexion.MdpHashToTest = gestionHash.UseHash(Mdp_test.Password);

            // Execute la commande Valider connexion en lui bindant le commande parameter
            ((ClientViewModel)this.Connexion.DataContext).ValiderConnexion.Execute(((Button)sender).CommandParameter.ToString());
            await new MessageDialog(clientViewModelConnexion.EtatConnexion).ShowAsync();
            if ((App.Current as App).IsConnected)
                this.Frame.Navigate(typeof(Accueil));

        }
    }
}
