using System;
using System.Collections.Generic;

namespace VideoApp.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DayOfBirth { get; set; }
        public IList<Video> Videos { get; set; }
    }
}
