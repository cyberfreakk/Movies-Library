using MoviesAuthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAuthAPI.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext db;
        public MovieRepository(DataContext db)
        {
            this.db = db;
        }

        public int AddMovie(Movie movie)
        {
            db.Movies.Add(movie);
            return db.SaveChanges();
        }

        public int DeleteMovie(int id)
        {
            var res = db.Movies.Where(x => x.MovieId == id).FirstOrDefault();
            db.Movies.Remove(res);
            return db.SaveChanges();
        }

        public Movie GetMovie(int id)
        {
            return db.Movies.Where(x => x.MovieId == id).FirstOrDefault();
        }

        public List<Movie> GetMovies()
        {
            return db.Movies.ToList();
        }

        public Movie GetMovies(int year)
        {
            return db.Movies.Where(x => x.Year == year).FirstOrDefault();
        }
    }
}
