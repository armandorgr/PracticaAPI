using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArmandoGuzmanDennisHidalgo.Modelo
{
    [Table("Favorito")]
    public class Favorito
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }
        public String MovieId { get; set; }

        public Favorito() { }

        public Favorito(
            int userId, String movieId)
        {
            UserId = userId;
            MovieId = movieId;
        }
    }
}
