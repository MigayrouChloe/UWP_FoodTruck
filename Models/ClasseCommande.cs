using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Models
{
    public class ClasseCommande : BindableBase
    {

        private ClassePanier _panierDeLaCommande;
        public ClassePanier PanierDeLaCommande { get { return _panierDeLaCommande; } set { SetProperty(ref _panierDeLaCommande, value); } }

        private DateTime _dateDeCommande;
        public DateTime DateDeCommande
        {
            get{ return _dateDeCommande; }
            set { SetProperty(ref _dateDeCommande, value); }
        }

        private DateTime _dateDeLivraison;
        public DateTime DateDeLivraison
        {
            get { return _dateDeLivraison; }
            set { SetProperty(ref _dateDeLivraison, value); }
        }

        private decimal _typdeDeLivraisonId;
        public decimal TypdeDeLivraisonId
        {
            get { return _typdeDeLivraisonId; }
            set { SetProperty(ref _typdeDeLivraisonId, value); }
        }

        private decimal _clientId;
        public decimal ClientId
        {
            get { return _clientId; }
            set { SetProperty(ref _clientId, value); }
        }

        private int _numero;
        public int Numero
        {
            get { return _numero; }
            set { SetProperty(ref _numero, value); }
        }

        private string _voie;
        public string Voie
        {
            get { return _voie; }
            set { SetProperty(ref _voie, value); }
        }

        private int _codePostal;
        public int CodePostal
        {
            get { return _codePostal; }
            set { SetProperty(ref _codePostal, value); }
        }

        private string _ville;
        public string Ville
        {
            get { return _ville; }
            set { SetProperty(ref _ville, value); }
        }

        public ClasseCommande()
        {
            this._dateDeCommande = DateTime.Now;
            this._clientId = (App.Current as App).ClientConnecte.ClientID;
            this._numero = (App.Current as App).ClientConnecte.Numero;
            this._voie = (App.Current as App).ClientConnecte.Voie;
            this._codePostal = (App.Current as App).ClientConnecte.CodePostal;
            this._ville = (App.Current as App).ClientConnecte.Ville;
            this.TypdeDeLivraisonId = 0;
            _panierDeLaCommande = (App.Current as App).PanierSession;
        }

    }
}
