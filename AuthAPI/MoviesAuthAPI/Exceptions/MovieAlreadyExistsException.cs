using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAuthAPI.Exceptions
{
    public class MovieAlreadyExistsException : Exception
    {
        public MovieAlreadyExistsException() { }
        public MovieAlreadyExistsException(string message) : base(message) { }
    }
}
