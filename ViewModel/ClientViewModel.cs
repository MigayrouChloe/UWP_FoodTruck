using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTruck.DataLayer;
using FoodTruck.Models;
using Prism.Mvvm;
using Prism.Commands;
using FoodTruck.Business;
using FoodTruck.Utilitaire;
using System.Security.Cryptography;

namespace FoodTruck.ViewModel
{
    public class ClientViewModel : BindableBase
    {
        private string _MdpHashToTest;
        public string MdpHashToTest
        {
            get { return _MdpHashToTest; }
            set { SetProperty(ref _MdpHashToTest, value); }
        }
        private ClasseClient _Client;
        public ClasseClient Client
        {
            get { return _Client; }
            set { SetProperty(ref _Client, value); }
        }

        private string _EtatConnexion;
        public string EtatConnexion
        {
            get { return _EtatConnexion; }
            set
            {
                SetProperty(ref _EtatConnexion, value);
            }
        }

        private string _InformationInscription;
        public string InformationInscription
        {
            get { return _InformationInscription; }
            set { SetProperty(ref _InformationInscription, value); }
        }

        private DelegateCommand<ClasseClient> _ValiderInscription;
        public DelegateCommand<ClasseClient> ValiderInscription
        {
            get { return _ValiderInscription; }
        }
        private void _doInscription(ClasseClient client)
        {
            ClientBusiness clientBusiness = new ClientBusiness();
            string erreurSaisie;
            if (clientBusiness.VerificationSaisies(client, out erreurSaisie))
            {
                ClientDataLayer AccesBaseClient = new ClientDataLayer();
                AccesBaseClient.AddClient(client, (App.Current as App).ConnectionString);
                InformationInscription = $"Merci {client.Prenom} de votre inscription, vous êtes désormais connecté{(client.CiviliteId == 1 ? "" : "e")}. \n Un mail de confirmation vous sera envoyé.";
                clientBusiness.CreationSession(client);
                GestionMail gestionMail = new GestionMail();
                //await gestionMail.ComposeEmailValidationInscription(client);
                Client = new ClasseClient();
            }
            else { InformationInscription = erreurSaisie; }
        }

        private DelegateCommand<string> _ValiderConnexion;
        public DelegateCommand<string> ValiderConnexion
        {
            get { return _ValiderConnexion; }
        }
        private void _doConnexion(string loginToTest)
        {

            ClientDataLayer accessToBase = new ClientDataLayer();
            ClasseClient clientFromBase = accessToBase.GetByLogin(loginToTest, (App.Current as App).ConnectionString);

            if (loginToTest == clientFromBase.Login && MdpHashToTest == clientFromBase.MotDePasse)
            {
                EtatConnexion = "Connexion réussie";
                ClientBusiness clientBusiness = new ClientBusiness();
                clientBusiness.CreationSession(clientFromBase);
            }
            else { EtatConnexion = "Merci de vérifier vos informations"; }

        }

        public ClientViewModel()
        {
            _Client = new ClasseClient();
            _ValiderInscription = new DelegateCommand<ClasseClient>(_doInscription);
            _ValiderConnexion = new DelegateCommand<string>(_doConnexion);
        }


    }
}
