using Newtonsoft.Json;
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
    public class MovieRepository
    {
        private String ruta;
        private SQLiteConnection conexion;
        private String _key = "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIzNjRjNDM5ZDg3Y2YwZDdjMTFjNGMzN2U5NjkxZmQ3MSIsInN1YiI6IjY1OWU4NzVmOTFiNTMwMDA5NWUwZWI2NCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.TdWOw85h0eo2HMpZlVKoHw_ralYOgI4qM4CfsN1g5CY";
        public String Key { get { return _key; } }

        public MovieRepository(String ruta) {
            this.ruta = ruta;
            this.conexion = new SQLiteConnection(ruta);
            if (!conexion.TableMappings.Any(e => e.MappedType.Name == "Movie")) {
                conexion.CreateTable<Movie>();
            }
        }

        private async Task<String> doRequest(String host, HttpMethod method) {
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage()
            {
                Method = method,
                RequestUri = new Uri(host),
                Headers =
            {
                {"accept","application/json" },
                { "authorization", Key }
            }
            };
            using var respuesta = await client.SendAsync(request);
            respuesta.EnsureSuccessStatusCode();
            var body = await respuesta.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<ObservableCollection<Movie>> getMovies(int page) {
            var body = await doRequest($"https://api.themoviedb.org/3/discover/movie?page={page}", HttpMethod.Get);
            MovieResult movieResult = JsonConvert.DeserializeObject<MovieResult>(body);
            ObservableCollection<Movie> movies = new ObservableCollection<Movie>(movieResult.Results);
            return movies;
        }

        public void addMovie(Movie movie) {
            if (findMovie(movie.Id) == null) {
                conexion.Insert(movie);
            }
        }

        public Movie findMovie(String id)
        {
            object[] param = { id };
            List<Movie> resultado = conexion.Query<Movie>("SELECT * FROM Movie Where id = ?", param);
            return resultado.Count > 0 ? resultado[0] : null;
        }

        public void removeMovie(Movie movie)
        {
            conexion.Delete(movie);
        }

        public List<Movie> GetMoviesByUser(int userId){
            object[] param = { userId };
            return conexion.Query<Movie>("select * from Movie where id in (SELECT MovieId from Favorito where UserId=?); ", param);
        }
    }


}
