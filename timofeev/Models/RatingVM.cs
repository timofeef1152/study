using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace timofeev.Models
{
    [Serializable]
    public class RatingVM
    {
        public RatingVM() { }
        public RatingVM(Rating r)
        {
            Id = r.Id;
            RatingLevel = r.RatingLevel;
            BonusPercent = r.BonusPercent;
        }

        public string Id { get; set; }
        public int RatingLevel { get; set; }
        public float BonusPercent { get; set; }
    }
}