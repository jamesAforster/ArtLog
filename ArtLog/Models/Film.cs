using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArtLog.Models
{
    public class Film
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }

    public class Root
    {
        public List<Film> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }

}
