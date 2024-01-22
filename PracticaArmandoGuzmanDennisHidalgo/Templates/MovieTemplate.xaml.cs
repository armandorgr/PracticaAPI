using PracticaArmandoGuzmanDennisHidalgo.Modelo;
using PracticaArmandoGuzmanDennisHidalgo.Vistas;

namespace PracticaArmandoGuzmanDennisHidalgo.Templates;

public partial class MovieTemplate : ContentView
{
	public MovieTemplate()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		Button btn = (Button)sender;
		Movie movie = btn.BindingContext as Movie;
        var navigationParameter = new Dictionary<String, object> { { "movie",  movie} };
        await Shell.Current.GoToAsync(nameof(MovieDetailsPage), navigationParameter);
    }

    private void FavClicked(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        Movie binding = btn.BindingContext as Movie;    
        binding.IsFavorite = !binding.IsFavorite;
        if (binding.IsFavorite)
        {
            App.MovieRepository.addMovie(binding);
            App.favoritoRepository.addFavorito(new Favorito(Preferences.Default.Get<int>("userId", 0), binding.Id));
        }
        else {
            Favorito favorito = App.favoritoRepository.findFavorito
                (
                Preferences.Default.Get<int>("userId", 0),
                binding.Id
                );
            App.MovieRepository.removeMovie(binding);
            if (favorito != null) {
                App.favoritoRepository.RemoveFavorito(favorito);
            }
        }
        
    }
}