using CommunityToolkit.Mvvm.Messaging;
using PracticaArmandoGuzmanDennisHidalgo.Messages;
using PracticaArmandoGuzmanDennisHidalgo.Modelo;
using PracticaArmandoGuzmanDennisHidalgo.Repositorio;
using PracticaArmandoGuzmanDennisHidalgo.Templates;
using PracticaArmandoGuzmanDennisHidalgo.VistaModelo;
using System.Collections.ObjectModel;

namespace PracticaArmandoGuzmanDennisHidalgo.Vistas;

public partial class LoginPage : PlantillaLogIn
{
	public LoginPage()
	{
		InitializeComponent();
        WeakReferenceMessenger.Default.Register<LoginMaloMensaje>(this, async (m, e) =>
        {
            await DisplayAlert("Login", e.Message, "Ok");
        });
	}

    private async void EntryLabelTapped(object sender, EventArgs e)
    {
		if (NickMenu.ScaleY == 0)
		{
			await NickMenu.ScaleYTo(1, 50);
		}
		else 
		{
			await NickMenu.ScaleYTo(0,50);
		}
		
    }

    private async void PasswordLabelTapped(object sender, EventArgs e)
    {
        if (passwordMenu.ScaleY == 0)
        {
            await passwordMenu.ScaleYTo(1, 50);
        }
        else
        {
            await passwordMenu.ScaleYTo(0, 50);
        }

    }

    private async void RegisteredClicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        ValidarLogin viewModel = btn.BindingContext as ValidarLogin;
        ValidarRegistro registroViewModel = new ValidarRegistro();
        String respuesta = await DisplayPromptAsync("Registro", "Introduce tu nombre", "OK", "CANCEL");
        registroViewModel.Nombre = respuesta;
        if (respuesta == null) return;
        respuesta = await DisplayPromptAsync("Registro", "Introduce un nick", "OK", "CANCEL");
        registroViewModel.NombreUser = respuesta;
        if (respuesta == null) return;
        respuesta = await DisplayPromptAsync("Registro", "Introduce tu edad", "OK", "CANCEL");
        registroViewModel.Edad = respuesta;
        if (respuesta == null) return;
        respuesta = await DisplayPromptAsync("Registro", "Introduce tu contraseña", "OK", "CANCEL");
        registroViewModel.Password = respuesta;
        if (respuesta == null) return;
        respuesta = await DisplayPromptAsync("Registro", "Repite tu contraseña", "OK", "CANCEL");
        registroViewModel.RepeatPassword = respuesta;
        if (respuesta == null) return;
        registroViewModel.validar();
        if (registroViewModel.Errores.Count > 0)
        {
            foreach (String error in registroViewModel.Errores)
            {
                viewModel.Errores.Add(error);
            }
        }
        else {
            await DisplayAlert("Registro correcto", "Se ha registrado correctamente", "ok");
        }
    }
}

public class LoginMaloMensaje {
    private string message;
    public string Message
    {
        get { return message; }
        set { message = value; }
    }
    public LoginMaloMensaje(String mensaje) { this.message = mensaje; }
}

