using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace FoodTruck.Models
{
    public class ClasseClient : BindableBase
    {
        private decimal _ClientID;
        public decimal ClientID
        {
            get { return _ClientID; }
            set { SetProperty(ref _ClientID, value); }
        }

        private string _Nom;
        public string Nom
        {
            get { return _Nom; }
            set { SetProperty(ref _Nom, value); }
        }


        private string _Prenom;
        public string Prenom
        {
            get { return _Prenom; }
            set { SetProperty(ref _Prenom, value); }
        }

        private DateTimeOffset _DateDeNaissance;
        public DateTimeOffset DateDeNaissance
        {
            get { return _DateDeNaissance; }
            set { SetProperty(ref _DateDeNaissance, value); }
        }

        private int _Numero;
        public int Numero
        {
            get { return _Numero; }
            set { SetProperty(ref _Numero, value); }
        }

        private string _Voie;
        public string Voie
        {
            get { return _Voie; }
            set { SetProperty(ref _Voie, value); }
        }

        private int _CodePostal;
        public int CodePostal
        {
            get { return _CodePostal; }
            set { SetProperty(ref _CodePostal, value); }
        }

        private string _Ville;
        public string Ville
        {
            get { return _Ville; }
            set { SetProperty(ref _Ville, value); }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
        }

        private string _Login;
        public string Login
        {
            get { return _Login; }
            set { SetProperty(ref _Login, value); }
        }

        private string _MotDePasse;
        public string MotDePasse
        {
            get { return _MotDePasse; }
            set { SetProperty(ref _MotDePasse, value); }
        }

        private int _TypeClientId;
        public int TypeClientId
        {
            get { return _TypeClientId; }
            set { SetProperty(ref _TypeClientId, value); }
        }

        private int _CiviliteId;
        public int CiviliteId
        {
            get { return _CiviliteId; }
            set { SetProperty(ref _CiviliteId, value); }
        }



    }
}
