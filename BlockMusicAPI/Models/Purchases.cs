using System;
using System.Collections.Generic;

namespace BlockMusicAPI.Models
{
    public partial class Purchases
    {
        public int PurchaseId { get; set; }
        public int UserId { get; set; }
        public int SongId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseValue { get; set; }

        public virtual Songs Song { get; set; }
        public virtual Users User { get; set; }
    }
}
