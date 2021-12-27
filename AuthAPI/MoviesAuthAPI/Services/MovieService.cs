using MoviesAuthAPI.Exceptions;
using MoviesAuthAPI.Models;
using MoviesAuthAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAuthAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository repo;

        public MovieService(IMovieRepository repo)
        {
            this.repo = repo;
        }

        public int AddMovie(Movie movie)
        {
            var mov = repo.GetMovie(movie.MovieId);
            if (mov != null)
            {
                throw new MovieAlreadyExistsException($"Movie with movie id: {movie.MovieId} already exists");
            }
            return repo.AddMovie(movie);
        }

        public int DeleteMovie(int id)
        {
            var mov = repo.GetMovie(id);
            if (mov == null)
            {
                throw new MovieNotFoundException($"Movie with movie id: {id} does not exists");
            }
            return repo.DeleteMovie(id);
        }

        public Movie GetMovie(int id)
        {
            var mov = repo.GetMovie(id);
            if (mov == null)
            {
                throw new MovieNotFoundException($"Movie with movie id: {id} does not exists");
            }
            return mov;
        }

        public List<Movie> GetMovies()
        {
            return repo.GetMovies();
        }

        public Movie GetMovies(int year)
        {
            var mov = repo.GetMovies(year);
            if (mov == null)
            {
                throw new MovieNotFoundException($"Movie with movie year: {year} does not exists");
            }
            return mov;
        }


    }
}
