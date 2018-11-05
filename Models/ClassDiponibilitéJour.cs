using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Models
{
    public class ClassDiponibilitéJour: BindableBase
    {
        private decimal _DisponibiliteID;
        public decimal DisponibiliteID
        {
            get { return _DisponibiliteID; }
            set { SetProperty(ref _DisponibiliteID, value); }
        }

        private string _DisponibiliteJour;
        public string DisponibiliteJour
        {
            get { return _DisponibiliteJour; }
            set { SetProperty(ref _DisponibiliteJour, value); }
        }
    }
}
