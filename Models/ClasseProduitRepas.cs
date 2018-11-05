using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Models
{
    class ClasseProduitRepas : BindableBase
    {
        private ClasseProduit _ProduitClas;

        public ClasseProduit ProduitClas
        {
            get { return _ProduitClas; }
            set { SetProperty(ref _ProduitClas, value); }
        }

        private ClasseRepas _RepasClas;
        public ClasseRepas RepasClas
        {
            get { return _RepasClas; }
            set { SetProperty(ref _RepasClas, value); }
        }
    }
}
