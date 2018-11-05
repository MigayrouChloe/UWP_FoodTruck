using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;
using FoodTruck.Models;
using LightBuzz.SMTP;

namespace FoodTruck.Utilitaire
{
    public class GestionMail
    {
        private string _eMailAdmin;

        private EmailMessage _eMail;
        private EmailMessage EMail { get => _eMail; set => _eMail = value; }

        public GestionMail()
        {
            this._eMailAdmin = "FoodTruckAdmin@foodTruck.fr";
            this._eMail = new EmailMessage();
        }

        public async Task ComposeEmailDemandeInformation()
        {
            EMail.To.Add(new EmailRecipient(_eMailAdmin));
            EMail.Subject = "[FoodTruck] Demande d'informations";
            await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(EMail);
        }

        public async Task ComposeEmailValidationInscription(ClasseClient client)
        {
            
        }
    }
}
