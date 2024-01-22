using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using PracticaArmandoGuzmanDennisHidalgo.Messages;
using PracticaArmandoGuzmanDennisHidalgo.Modelo;
using PracticaArmandoGuzmanDennisHidalgo.Vistas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArmandoGuzmanDennisHidalgo.VistaModelo
{
    public partial class ValidarLogin : ObservableValidator
    {
        public ObservableCollection<String> Errores { get; set; } = new ObservableCollection<String>();
        private String nombreUser;
        [Required(ErrorMessage = "El nick esta vacio")]

        public String NombreUser
        {
            get => nombreUser;
            set => SetProperty(ref nombreUser, value);
        }

        private String password;
        [Required(ErrorMessage = "La contraseña esta vacia")]
        public String Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        [RelayCommand]
        public async void validarLog()
        {
            Errores.Clear();
            ValidateAllProperties();
            GetErrors(nameof(Password)).ToList().ForEach(f => Errores.Add(f.ErrorMessage));
            GetErrors(nameof(NombreUser)).ToList().ForEach(f => Errores.Add(f.ErrorMessage));

            if (Errores.Count == 0)
            {
                Object[] parametros = new object[] { nombreUser, password };
                List<Usuario> usuario = App.RepositorioUsuario.findUser("SELECT * FROM usuario WHERE nombreUser = ? and password = ? ", parametros);
                if (usuario.Count == 1)
                {
                    Preferences.Default.Set("userId", usuario[0].Id);
                    await AppShell.Current.GoToAsync(nameof(Vistas.UsersPage));
                }
                else
                {
                    WeakReferenceMessenger.Default.Send<LoginMaloMensaje>(new LoginMaloMensaje("Usuario no existe, intentelo de nuevo."));
                    Errores.Add("La combinación de nick y constraseña no existe en la base de datos.");
                }
            }
        }

        [RelayCommand]
        public async void goToRegister()
        {
            await AppShell.Current.GoToAsync(nameof(Vistas.RegisterPage));
        }

        [RelayCommand]
        public void copyNick()
        { 
            Clipboard.SetTextAsync(NombreUser);
        }


        [RelayCommand]
        public void cutNick()
        {
            copyNick();
            NombreUser = "";
        }


        [RelayCommand]
        public async void pasteNick()
        {
            NombreUser += await Clipboard.GetTextAsync();
        }


        [RelayCommand]
        public void copyPassword()
        {
            Clipboard.SetTextAsync(Password);   
        }
        [RelayCommand]
        public void cutPassword()
        {
            copyPassword();
            Password = "";
        }
        [RelayCommand]
        public async void pastePassword()
        {
            Password += await Clipboard.GetTextAsync();
        }
    }


}
