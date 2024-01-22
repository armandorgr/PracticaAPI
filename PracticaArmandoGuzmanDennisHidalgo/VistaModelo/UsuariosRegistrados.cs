using CommunityToolkit.Mvvm.ComponentModel;
using PracticaArmandoGuzmanDennisHidalgo.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArmandoGuzmanDennisHidalgo.VistaModelo
{
    public partial class UsuariosRegistrados : ObservableObject
    {
        public ObservableCollection<Usuario> Usuarios { get; set; } = App.RepositorioUsuario.getusuarios();
    }
}
