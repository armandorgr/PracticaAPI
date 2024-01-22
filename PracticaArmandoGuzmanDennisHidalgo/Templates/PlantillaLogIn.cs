using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArmandoGuzmanDennisHidalgo.Templates
{
    public class PlantillaLogIn : ContentPage
    {
        public PlantillaLogIn() {
            var plantilla = Application.Current.Resources["login"] as ControlTemplate;
            ControlTemplate = plantilla;
        }
    }
}
