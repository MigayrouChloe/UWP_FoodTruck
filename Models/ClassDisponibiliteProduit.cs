using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Models
{
    public class ClassDisponibiliteProduit:BindableBase
    {
        private ClasseProduit _ProduitD;

        public ClasseProduit ProduitD
        {
            get { return _ProduitD; }
            set { SetProperty(ref _ProduitD, value); }
        }

        private ClassDisponibiliteProduit _ProduitDis;
        public ClassDisponibiliteProduit ProduitDis
        {
            get { return _ProduitDis; }
            set { SetProperty(ref _ProduitDis, value); }
        }
    }
}

