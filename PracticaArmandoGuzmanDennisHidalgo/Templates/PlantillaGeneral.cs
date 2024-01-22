namespace PracticaArmandoGuzmanDennisHidalgo.Templates;

public class PlantillaGeneral : ContentPage
{
	public PlantillaGeneral()
	{
		var plantilla = Application.Current.Resources["general"] as ControlTemplate;
		ControlTemplate = plantilla;
	}
}