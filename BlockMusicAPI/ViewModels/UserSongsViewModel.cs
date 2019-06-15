using BlockMusicAPI.FreshDbC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockMusicAPI.ViewModels
{
    public class UserSongsViewModel
    {
        public Users User { get; set; }
        public List<Purchases> Purchases { get; set; }
        public List<Songs> Songs { get; set; }
    }
}
