using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PracticaArmandoGuzmanDennisHidalgo.Modelo;
using PracticaArmandoGuzmanDennisHidalgo.Repositorio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArmandoGuzmanDennisHidalgo.VistaModelo
{
    public partial class MoviesViewModel : ObservableObject
    {
        private const String TITLE = "Tittle";
        private const String RELEASE_DATE = "Release Date";
        private const String VOTE_AVERAGE= "Vote Average";

        [ObservableProperty] private ObservableCollection<Movie> movies = new ObservableCollection<Movie> ();
        [ObservableProperty] private ObservableCollection<Movie> resultMovies = new ObservableCollection<Movie> ();
        [ObservableProperty] private int currentPage = 1;
        

        private ObservableCollection<String> parametros = new ObservableCollection<String>() 
        {
            TITLE, RELEASE_DATE, VOTE_AVERAGE
        };
        public ObservableCollection<String> Parametros { get { return parametros; } }
        [ObservableProperty] private String busqueda = "";
        [ObservableProperty] private String parametroSeleccionado = "";

        public MoviesViewModel() { 
            loadMovies();
        }

        private async void loadMovies()
        {
            List<Movie> favotitesMovies = App.MovieRepository.GetMoviesByUser(Preferences.Default.Get<int>("userId", 0));
            ResultMovies.Clear ();
            Movies = await App.MovieRepository.getMovies(CurrentPage);
            foreach (Movie movie in Movies)
            {
                if (favotitesMovies.Any(fav => fav.Id == movie.Id)) {
                    movie.IsFavorite = true;
                }
                ResultMovies.Add(movie);
            }
            buscar();
        }

        [RelayCommand]
        public void Reset() {
            foreach (Movie movie in Movies)
            {
                if (!ResultMovies.Contains(movie))
                {
                    ResultMovies.Add(movie);
                }
            }
        }

        [RelayCommand]
        public void movePage(String direction) {
            if (Boolean.Parse(direction))
            {
                if (CurrentPage < 10) {
                    CurrentPage++;       
                }
            }
            else {
                if (CurrentPage > 0) {
                    CurrentPage--;       
                }
            }
            loadMovies();
        }

        [RelayCommand]
        public void buscar() 
        {
            switch (ParametroSeleccionado) 
            {
                case TITLE: {
                        foreach (var item in Movies)
                        {
                            if (!item.Title.Contains(Busqueda))
                            {
                                ResultMovies.Remove(item);
                            }
                        };
                        break;
                    }
                case RELEASE_DATE:
                    {
                        foreach (var item in Movies)
                        {
                            if (!item.Release_Date.Contains(Busqueda))
                            {
                                ResultMovies.Remove(item);
                            }
                        };
                        break;
                    }
                case VOTE_AVERAGE:
                    {
                        if (float.TryParse(Busqueda, out float valor)) 
                        {
                            foreach (var item in Movies)
                            {
                                if (!(item.Vote_Average >= valor))
                                {
                                    ResultMovies.Remove(item);
                                }
                            };
                        }
                        break;
                    }
                default:
                    foreach (Movie movie in Movies) {
                        if (!ResultMovies.Contains(movie)) {
                            ResultMovies.Add(movie);
                        }
                    }
                    break;
            }
        }
    }
}
