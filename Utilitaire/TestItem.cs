using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace FoodTruck.Utilitaire
{
    public class TestItem
    {
        public string Name { get; set; }
        public SolidColorBrush ColorBrush { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
