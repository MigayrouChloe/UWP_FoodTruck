using FoodTruck.DataLayer;
using FoodTruck.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.ViewModel
{
    public class RepasViewModel : BindableBase
    {

        private string _typeDeRepasChoisi;
        public string TypeDeRepasChoisi
        {
            get { return _typeDeRepasChoisi; }
            set { SetProperty(ref _typeDeRepasChoisi, value); }
        }

        private ObservableCollection<ClasseRepas> _listeRepas;
        public ObservableCollection<ClasseRepas> listeRepas
        {
            get { return _listeRepas; }
            set { SetProperty(ref _listeRepas, value); }
        }


        private ObservableCollection<ClassDiponibilitéJour> _listeJour;
        public ObservableCollection<ClassDiponibilitéJour> listeJour
        {
            get { return _listeJour; }
            set { SetProperty(ref _listeJour, value); }
        }

        private ObservableCollection<ClasseProduit> _NosProduit;
        public ObservableCollection<ClasseProduit> NosProduit
        {
            get { return _NosProduit; }
            set { SetProperty(ref _NosProduit, value); }
        }


        private ObservableCollection<ClasseProduit> _NosProduitDis;
        public ObservableCollection<ClasseProduit> NosProduitDis
        {
            get { return _NosProduitDis; }
            set { SetProperty(ref _NosProduitDis, value); }
        }

        private ClasseProduit _prdtobtenu;
        public ClasseProduit prdtobtenu
        {
            get { return _prdtobtenu; }
            set { SetProperty(ref _prdtobtenu, value); }
        }

        private ClasseRepas _RepasC;
        public ClasseRepas RepasC
        {
            get { return _RepasC; }
            set { SetProperty(ref _RepasC, value); }
        }

        private int _indexJour = 0;
        public int indexJour
        {
            get { return _indexJour; }
            set { SetProperty(ref _indexJour, value); }
        }


        private DelegateCommand<string> _ajoutPanier;
        public DelegateCommand<string> AjoutPanier
        {
            get { return _ajoutPanier; }
        }

        public RepasViewModel(string connectionString)
        {
            _RepasC = new ClasseRepas();
            _ajoutPanier = new DelegateCommand<string>(DoAction);
            var DallRepas = new RepasDataLayer();

            _listeRepas = new ObservableCollection<ClasseRepas>();
            _listeRepas = DallRepas.GetRepas(connectionString);

            var DallJour = new DisponibilitéDataLayer();        
            _listeJour = DallJour.GetJour(connectionString);


            _NosProduit = new ObservableCollection<ClasseProduit>();

            _prdtobtenu = new ClasseProduit();

            _NosProduitDis = new ObservableCollection<ClasseProduit>();

            _typeDeRepasChoisi = "";



        }
        private void DoAction(string nomProduitAAjouter)
        {
            int index = NosProduit.IndexOf(NosProduit.Where(p => p.ProductNom == nomProduitAAjouter).FirstOrDefault());
            (App.Current as App).PanierSession.AddProduit(NosProduit[index]);
        }

    }

}


