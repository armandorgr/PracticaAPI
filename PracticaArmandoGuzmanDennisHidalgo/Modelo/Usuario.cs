using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArmandoGuzmanDennisHidalgo.Modelo
{
    [Table("Usuario")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string NombreUser { get; set; }

        public int Edad {  get; set; }

        public String Password {  get; set; }

        public Usuario() { }

        public Usuario(string nombre, string nombreUser, int edad, string password)
        { 
            this.Nombre = nombre;
            this.NombreUser = nombreUser;
            this.Edad = edad;
            this.Password = password;
        }
    }
}
