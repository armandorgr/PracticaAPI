using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using PracticaArmandoGuzmanDennisHidalgo.Messages;
using PracticaArmandoGuzmanDennisHidalgo.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArmandoGuzmanDennisHidalgo.VistaModelo
{
    public partial class ValidarRegistro : ObservableValidator
    {
        public ObservableCollection<String> Errores { get; set; } = new ObservableCollection<String>();
        private String nombre;
        [Required(ErrorMessage = "El nombre esta vacio")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage ="El nombre no cumple con las reglas")]

        public String Nombre
        {
            get => nombre;
            set => SetProperty(ref nombre, value);
        }
    
        private String nombreUser;
        [Required(ErrorMessage = "El nick esta vacio")]
        public String NombreUser
        {
            get => nombreUser;
            set => SetProperty(ref nombreUser, value);
        }

        private String edad;
        [Required(ErrorMessage = "La edad esta vacia")]
        [RegularExpression(@"^\d+$", ErrorMessage ="Campo edad mal debe ser un numero")]
        public String Edad
        {
            get => edad;
            set => SetProperty(ref edad, value);
        }

        private String password;
        [Required(ErrorMessage = "La contraseña esta vacia")]
        [MinLength(5, ErrorMessage ="La contraseña debe contener minimo 5 caracteres")]
        public String Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private String repeatPassword;
        public String RepeatPassword
        {
            get => repeatPassword;
            set => SetProperty(ref repeatPassword, value);
        }

        private void validarPass()
        {
            if(!(repeatPassword == password))   
            {
                Errores.Add("Las contraseñas no coinciden");
            }
        }

        private void validarUser()
        {
           Object[] parametros = new object[] {NombreUser };
            if(App.RepositorioUsuario.findUser("SELECT * FROM usuario WHERE nombreUser = ?", parametros).Count > 0)
            {
                Errores.Add("El nombre de usuario no esta disponible");
            }
        }

        private void validarRangoEdad(String edad) 
        {
                if (int.TryParse(edad, result:out int edadNum))
                {
                    if (edadNum <= 0 || edadNum >= 100) Errores.Add("La edad debe ser mayor que 0 y menor que 100");
                }
        }

        [RelayCommand]
        public async void validar()
        {
            Errores.Clear();
            ValidateAllProperties();
            validarPass();
            validarUser();
            validarRangoEdad(Edad);
            GetErrors(nameof(Nombre)).ToList().ForEach(f=>Errores.Add(f.ErrorMessage));
            GetErrors(nameof(NombreUser)).ToList().ForEach(f => Errores.Add(f.ErrorMessage));
            GetErrors(nameof(Edad)).ToList().ForEach(f => Errores.Add(f.ErrorMessage));
            GetErrors(nameof(Password)).ToList().ForEach(f => Errores.Add(f.ErrorMessage));

            if(Errores.Count == 0)
            {
                App.RepositorioUsuario.addUsuario(new Usuario {
                Nombre = Nombre,
                NombreUser = NombreUser,
                Edad = int.Parse(Edad),
                Password = password});
                /*
                    Con esto paso el mensaje para el cual esta registrado la clase C# y asi poder realizar cambios 
                    en la interfaz, como en este caso muestro un mensaje emergente.
                */
                WeakReferenceMessenger.Default.Send(new RegisteredMessage($"Registro correcto con nick {NombreUser}."));
            }
        }

    }
}
