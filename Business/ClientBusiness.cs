using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTruck.Models;
using FoodTruck.DataLayer;
using System.Reflection;

namespace FoodTruck.Business
{
    public class ClientBusiness
    {

        private static bool _verificationEmail(string emailToCheck)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(emailToCheck);
                return addr.Address == emailToCheck;
            }
            catch
            {
                return false;
            }
        }
        private static bool _verficiationDateDeNaissance(DateTimeOffset dateToCheck)
        {
            if (dateToCheck.Year < DateTime.Now.Year && dateToCheck.Year > (DateTime.Now.Year - 100))
                return true;
            else return false;
        }
        private static bool _verfificationLogin(string loginToCheck)
        {
            ClientDataLayer accessToData = new ClientDataLayer();
            if (accessToData.LoginExistant(loginToCheck, (App.Current as App).ConnectionString))
                return true;
            else return false;
        }
        private static bool _verifciationCodePostale(int codePostalToCheck)
        {
            if (codePostalToCheck < 1000 || codePostalToCheck > 99999)
                return false;
            else return true;
        }
        private static bool _verificationAutresParametres(ClasseClient client)
        {
            if (client.Nom != "" && client.Prenom != "" && client.MotDePasse != "" && client.Login != "" &&
                client.Numero != 0 && client.Voie != "" && client.Ville != "" &&
                client.TypeClientId != 0 && client.CiviliteId != 0)
                return true;
            else return false;
        }

        public bool VerificationSaisies(ClasseClient client, out string InformationSaisies)
        {
            InformationSaisies = "";
            string[] mesErreurs = new string[5];
            mesErreurs[0] = " Un paramètre n'est pas renseigné.";
            mesErreurs[1] = " Votre date de naissance est invalide.";
            mesErreurs[2] = " Votre e-mail n'est pas au bon format.";
            mesErreurs[3] = " Votre login est déja utilisé.";
            mesErreurs[4] = " Votre code postal est incorrect.";


            bool[] array = new bool[5];
            array[0] = _verificationAutresParametres(client);
            array[1] = _verficiationDateDeNaissance(client.DateDeNaissance);
            array[2] = _verificationEmail(client.Email);
            array[3] = _verfificationLogin(client.Login);
            array[4] = _verifciationCodePostale(client.CodePostal);

            for (int i = 0; i < array.Length; i++)
            {
                if (!array[i])
                {
                    InformationSaisies += InformationSaisies + mesErreurs[i];
                    return false;
                }
            }
            return true;

        }

        public void CreationSession(ClasseClient clientConnecte)
        {
            (App.Current as App).IsConnected = true;
            (App.Current as App).ClientConnecte = clientConnecte;
        }
    }
}

