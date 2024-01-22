using CommunityToolkit.Mvvm.Messaging;
using PracticaArmandoGuzmanDennisHidalgo.Messages;
using PracticaArmandoGuzmanDennisHidalgo.Templates;

namespace PracticaArmandoGuzmanDennisHidalgo.Vistas;

public partial class RegisterPage : PlantillaLogIn
{
    public RegisterPage()
    {
        InitializeComponent();
        /*
		    Uso esto para registrar que hacer cuando se reciba un mensaje de tipo ReggisteredMessage, esto permite que el viewmodel 
            maneje los command y poder realizar cambios en la interfaz mediante el paso de mensajes a la clase de C# asociado a 
            la vista. Sin esto el viewmodel no es capaz de realizar cambios en la interfaz y por lo tanto tendria que 
            implementar el comportamiento en esta clase, que seria lo opuesto a lo que la arquitectura de MVVM quiere lograr. 
		*/
        WeakReferenceMessenger.Default.Register<RegisteredMessage>(this, async (m, e) =>
        {
            await DisplayAlert("Register", e.Message, "Ok");
        });
    }
}