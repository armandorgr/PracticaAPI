using PracticaArmandoGuzmanDennisHidalgo.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArmandoGuzmanDennisHidalgo.Repositorio
{
    public class RepositorioUsuario
    {
        private String ruta;
        private SQLiteConnection conexion;

        public RepositorioUsuario(String ruta)
        {
            
            this.ruta = ruta;
            this.conexion = new SQLiteConnection(ruta);
            if (!conexion.TableMappings.Any(e => e.MappedType.Name == "Usuario"))
            {
                conexion.CreateTable<Usuario>();
            }
        }

        public void addUsuario(Usuario usuario)
        {
            conexion.Insert(usuario);
        }

        public ObservableCollection<Usuario> getusuarios()
        {
            return new ObservableCollection<Usuario>(conexion.Table<Usuario>().ToList());
        }

        /*
            Usamos el metodo query que recibe como parametro la query a ejecutar y un
            array de objetos que se corresponde con los valores que vamos a editar.
            Funcion usada para verificar que el usuario no este registrado, y para que en caso de estarlo, valide que se corresponda la contraseña
        */
        public List<Usuario> findUser(String query, Object[] param)
        {
            return conexion.Query<Usuario>(query, param);
        }
        
    }

}
