using CommunityToolkit.Mvvm.ComponentModel;
using PracticaArmandoGuzmanDennisHidalgo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArmandoGuzmanDennisHidalgo.VistaModelo
{
    [ObservableObject]
    [QueryProperty(nameof(SelectedMovie), "movie")]
    public partial class MovieDetailsViewModel
    {
        [ObservableProperty] private Movie selectedMovie;
    }
}
