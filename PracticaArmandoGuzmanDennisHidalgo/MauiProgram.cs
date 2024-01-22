using PracticaArmandoGuzmanDennisHidalgo.Repositorio;

namespace PracticaArmandoGuzmanDennisHidalgo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		String ruta = GetRuta.obtenerRuta("Usuarios.db");
		System.Diagnostics.Debug.WriteLine("Base de datos creada en : " + ruta);
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddSingleton<FavoritoRepository>(s => ActivatorUtilities.CreateInstance<FavoritoRepository>(s, ruta));
        builder.Services.AddSingleton<RepositorioUsuario>(s => ActivatorUtilities.CreateInstance<RepositorioUsuario>(s, ruta));
        builder.Services.AddSingleton<MovieRepository>(s => ActivatorUtilities.CreateInstance<MovieRepository>(s, ruta));


        return builder.Build();
	}
}
