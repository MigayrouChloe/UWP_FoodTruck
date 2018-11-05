using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck
{
    public class ProduitViewModel : BindableBase
    {
        private ObservableCollection<ClasseProduit> _listeProduit;

        public ObservableCollection<ClasseProduit> listeProduit
        {
            get { return _listeProduit; }
            set { SetProperty(ref _listeProduit, value); }
        }

        private ClasseProduit _Produit;
        public ClasseProduit Produit
        {
            get { return _Produit; }
            set { SetProperty(ref _Produit, value); }
        }

        public ProduitViewModel(string connectionString)
        {
            _Produit = new ClasseProduit();
            var DallProduit = new ProduitDataLayer();
            ObservableCollection<ClasseProduit> _listeProduitTemporaire = new ObservableCollection<ClasseProduit>();
            _listeProduitTemporaire = DallProduit.GetProducts(connectionString);

            _listeProduit = new ObservableCollection<ClasseProduit>()
           {
               _listeProduitTemporaire[3],
               _listeProduitTemporaire[5],
               _listeProduitTemporaire[0]
           };
        }
    }
}