using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAuthAPI.Exceptions
{
    public class MovieNotFoundException : Exception
    {
        public MovieNotFoundException() { }
        public MovieNotFoundException(string message) : base(message) { }
    }
}
