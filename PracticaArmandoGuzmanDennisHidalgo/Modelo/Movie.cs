using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArmandoGuzmanDennisHidalgo.Modelo
{
    [Table("Movie")]
    public partial class Movie : ObservableObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Overview { get; set; }
        public string Poster_Path { get; set; }
        public string Title { get; set; }
        public float Vote_Average { get; set; }
        public int Vote_Count { get; set; }
        public string Release_Date { get; set; }
        [ObservableProperty] private bool isFavorite = false;
    }

    public class MovieResult {
        public List<Movie> Results { get; set; }
    }
}
