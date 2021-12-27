using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAuthAPI.Exceptions;
using MoviesAuthAPI.Models;
using MoviesAuthAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService service;

        public MovieController(IMovieService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetMovies());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(service.GetMovie(id));
            }
            catch (MovieNotFoundException m)
            {
                return NotFound(m.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(service.DeleteMovie(id));
            }
            catch (MovieNotFoundException m)
            {
                return NotFound(m.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpGet("Year/{year}")]
        public IActionResult GetByYear(int year)
        {
            try
            {
                return Ok(service.GetMovies(year));
            }
            catch (MovieNotFoundException m)
            {
                return NotFound(m.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(Movie movie)
        {
            try
            {
                return Ok(service.AddMovie(movie));
            }
            catch (MovieAlreadyExistsException m)
            {
                return Conflict(m.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
