using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck
{
    public class ClasseProduit : BindableBase
    {

        private decimal _ProductID;
        public decimal ProductID
        {
            get { return _ProductID; }
            set { SetProperty(ref _ProductID, value); }
        }

        private string _ProductNom;
        public string ProductNom
        {
            get { return _ProductNom; }
            set { SetProperty(ref _ProductNom, value); }
        }

        private string _ProductDescription;
        public string ProductDescription
        {
            get { return _ProductDescription; }
            set { SetProperty(ref _ProductDescription, value); }
        }

        private double _ProductPrix;
        public double ProductPrix
        {
            get { return _ProductPrix; }
            set { SetProperty(ref _ProductPrix, value); }
        }

        private int _ProductQuantiteDisponible;
        public int ProductQuantiteDisponible
        {
            get { return _ProductQuantiteDisponible; }
            set { SetProperty(ref _ProductQuantiteDisponible, value); }
        }
        private ObservableCollection<string> _JoursDispo = new ObservableCollection<string>();
        public  ObservableCollection<string> JoursDispo
        {
            get { return _JoursDispo; }
            set { SetProperty(ref _JoursDispo, value); }


        }

        private bool _isEnable=false;
        public bool isEnable
        {
            get { return _isEnable; }
            set { SetProperty(ref _isEnable, value); }
        }
    }
}
