using System;
using System.Collections.Generic;

namespace BlockMusicAPI.FreshDbC
{
    public partial class Songs
    {
        public Songs()
        {
            Purchases = new HashSet<Purchases>();
        }

        public int SongId { get; set; }
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public decimal Duration { get; set; }
        public int UploaderId { get; set; }
        public DateTime DateUploaded { get; set; }
        public int? AlbumId { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string PathToFile { get; set; }

        public virtual Genres Genre { get; set; }
        public virtual Users Uploader { get; set; }
        public virtual ICollection<Purchases> Purchases { get; set; }
    }
}
