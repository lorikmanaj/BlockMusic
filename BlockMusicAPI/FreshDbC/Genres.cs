using System;
using System.Collections.Generic;

namespace BlockMusicAPI.FreshDbC
{
    public partial class Genres
    {
        public Genres()
        {
            Songs = new HashSet<Songs>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Songs> Songs { get; set; }
    }
}
