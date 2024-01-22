using PracticaArmandoGuzmanDennisHidalgo.Repositorio;

namespace PracticaArmandoGuzmanDennisHidalgo;

public partial class App : Application
{

	public static RepositorioUsuario RepositorioUsuario { get; set; }
	public static MovieRepository MovieRepository { get; set; }
	public static FavoritoRepository favoritoRepository{ get; set; }
	public App(RepositorioUsuario repos, MovieRepository movieRepository, FavoritoRepository favoritoRepo)
	{
		RepositorioUsuario = repos;
		MovieRepository = movieRepository;
        favoritoRepository = favoritoRepo;

		InitializeComponent();

		MainPage = new AppShell();
	}

    private async void LogOutClicked(object sender, EventArgs e)
    {
		await AppShell.Current.GoToAsync(nameof(Vistas.LoginPage));
    }

    private async void ApiClicked(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(Vistas.MoviePage));
    }

    private void LinkedInClicked(object sender, EventArgs e)
    {
        OpenPage("https://www.linkedin.com/in/armando-rafael-guzmán-reyes-desarrollo-java-web/");
    }
    private void PortFolioClicked(object sender, EventArgs e)
    {
        OpenPage("https://www.alumnos.betechcamp.com/agr23/portfolio/index.html");
    }

    private async void OpenPage(String url)
    {
        try
        {
            await Launcher.OpenAsync(new Uri(url));
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }
    }

    private async void FavoritesClicked(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(Vistas.FavoritosPage));
    }
}
