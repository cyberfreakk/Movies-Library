using MoviesAuthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAuthAPI.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetMovies();
        Movie GetMovies(int year);
        Movie GetMovie(int id);
        int DeleteMovie(int id);
        int AddMovie(Movie movie);
    }
}
