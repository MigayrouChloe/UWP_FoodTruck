using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Models
{
    public class ClasseRepas : BindableBase
    {


        private decimal _RepasID;
        public decimal RepasID
        {
            get { return _RepasID; }
            set { SetProperty(ref _RepasID, value); }
        }

        private string _RepasType;
        public string RepasType
        {
            get { return _RepasType; }
            set { SetProperty(ref _RepasType, value); }
        }


    }
}

