using System.Collections.Generic;

namespace VideoApp.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public IList<Video> Videos { get; set; }
    }
}
