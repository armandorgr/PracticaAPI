using CommunityToolkit.Mvvm.ComponentModel;
using PracticaArmandoGuzmanDennisHidalgo.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArmandoGuzmanDennisHidalgo.VistaModelo
{
    public partial class FavoritosViewModel : ObservableObject
    {
        [ObservableProperty] private ObservableCollection<Movie> peliculasFavoritas = new ObservableCollection<Movie> (App.MovieRepository.GetMoviesByUser(Preferences.Default.Get<int>("userId", 0)));
    }
}
