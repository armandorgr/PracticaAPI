namespace PracticaArmandoGuzmanDennisHidalgo;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Vistas.LoginPage), typeof(Vistas.LoginPage));
		Routing.RegisterRoute(nameof(Vistas.UsersPage), typeof(Vistas.UsersPage));
		Routing.RegisterRoute(nameof(Vistas.RegisterPage), typeof(Vistas.RegisterPage));
		Routing.RegisterRoute(nameof(Vistas.MoviePage), typeof(Vistas.MoviePage));
		Routing.RegisterRoute(nameof(Vistas.MovieDetailsPage), typeof(Vistas.MovieDetailsPage));
        Routing.RegisterRoute(nameof(Vistas.FavoritosPage), typeof(Vistas.FavoritosPage));
    }
}
