using System.Collections.Generic;

namespace VideoApp.Models
{
    public class Video
    {
        public int VideoId { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public Genre Genres { get; set; }
        public IList<Actor> Actors { get; set; }
    }
}
