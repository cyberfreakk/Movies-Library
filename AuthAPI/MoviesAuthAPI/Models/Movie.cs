using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAuthAPI.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public float Rating { get; set; }
        public string Actors { get; set; }
    }
}
