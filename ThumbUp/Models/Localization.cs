using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThumbUp.Models
{
    public class Localization
    {
        public Localization()
        {
            LocRatings = new HashSet<LocalizationRating>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LocID { get; set; }
        public string LocName { get; set; }
        public string LocDescription { get; set; }
        public decimal LocRatingsAvg => (decimal)LocRatings.Sum(lra => lra.LRaRating) / (LocRatings.Any() ? LocRatings.Count : 1.0m);
        public ICollection<LocalizationRating> LocRatings { get; set; }
    }
}
