using PracticaArmandoGuzmanDennisHidalgo.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArmandoGuzmanDennisHidalgo.Repositorio
{
    public class FavoritoRepository
    {
        private String ruta;
        private SQLiteConnection conexion;

        public FavoritoRepository(String ruta) {
            this.ruta = ruta;
            this.conexion = new SQLiteConnection(ruta);
            if(!conexion.TableMappings.Any(e => e.MappedType.Name == "Favorito"))
            {
                System.Diagnostics.Debug.WriteLine("Se ejecuta");
                conexion.CreateTable<Favorito>();
            }
        }

        public void addFavorito(Favorito favorito) {
            conexion.Insert(favorito);
        }

        public void RemoveFavorito(Favorito favorito) { 
            conexion.Delete(favorito); 
        }

        public Favorito findFavorito(int userId, String movieId) {
            object[] param = { userId, movieId };
            List<Favorito> resultado =  conexion.Query<Favorito>("SELECT * FROM Favorito where userId = ? AND movieId = ?", param);
            return resultado.Count > 0 ? resultado[0] : null;
        }



     }
    }

