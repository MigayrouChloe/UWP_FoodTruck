using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Models
{
    public class ClassePanier
    {
        private ObservableCollection<ClasseProduit> _produitsDuPanier = new ObservableCollection<ClasseProduit>();
        public ObservableCollection<ClasseProduit> ProduitDuPanier
        {
            get { return _produitsDuPanier; }
            set { _produitsDuPanier = value; }
        }
        public void AddProduit(ClasseProduit produitAAjouter)
        {
            this._produitsDuPanier.Add(produitAAjouter);
        }

        public void RemoveProduit(ClasseProduit produitASupprimer)
        {
            ProduitDuPanier.Remove(produitASupprimer);
        }

        public string AffichagePanier()
        {
            string contenuPanier= "Votre panier contient :\n";
            foreach (ClasseProduit produit in _produitsDuPanier)
            {
                contenuPanier += produit.ProductNom + "\n";
            }
            return contenuPanier;
        }



    }
}
