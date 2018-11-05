using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTruck.Models;
using Prism.Commands;
using Prism.Mvvm;
using FoodTruck.DataLayer;

namespace FoodTruck.ViewModel
{
    public class PanierViewModel : BindableBase
    {
        private ClassePanier _panierEnCours;
        public ClassePanier PanierEnCours { get => _panierEnCours; }

        private ClasseClient _clientConnecte;
        public ClasseClient ClientConnecte
        {
            get { return _clientConnecte; }
            set { SetProperty(ref _clientConnecte, value); }
        }

        private ClasseCommande _commandeEnCours;
        public ClasseCommande CommandeEnCours
        {
            get { return _commandeEnCours; }
            set { SetProperty(ref _commandeEnCours, value); }
        }

        private string _adresseComplete;
        public string AdresseComplete
        {
            get { return _adresseComplete; }
        }

        private DelegateCommand<string> _supprimerPanier;
        public DelegateCommand<string> SupprimerPanier
        {
            get { return _supprimerPanier; }
        }
        private void doSuppression(string NomProduitASupprimer)
        {
            ObservableCollection<ClasseProduit> lesProduitsDuPanier = PanierEnCours.ProduitDuPanier;

            int index = lesProduitsDuPanier.IndexOf(lesProduitsDuPanier.Where(p => p.ProductNom == NomProduitASupprimer).FirstOrDefault());
            (App.Current as App).PanierSession.RemoveProduit(lesProduitsDuPanier[index]);
        }


        private DelegateCommand<ClasseCommande> _validerLaCommande;
        public DelegateCommand<ClasseCommande> ValiderLaCommande
        {
            get { return _validerLaCommande; }
        }
        private void doCommande(ClasseCommande commanderAValider)
        {
            CommandeDataLayer accesBase = new CommandeDataLayer();
            accesBase.AddCommande(commanderAValider, (App.Current as App).ConnectionString);
        }

        public PanierViewModel()
        {
            this._panierEnCours = (App.Current as App).PanierSession;
            this._clientConnecte = (App.Current as App).ClientConnecte;
            this._adresseComplete = _clientConnecte.Numero + " " + _clientConnecte.Voie + Environment.NewLine + _clientConnecte.CodePostal + " " + ClientConnecte.Ville;
            this._supprimerPanier = new DelegateCommand<string>(doSuppression);
            this._validerLaCommande = new DelegateCommand<ClasseCommande>(doCommande);
            this._commandeEnCours = new ClasseCommande();
        }
    }
}
