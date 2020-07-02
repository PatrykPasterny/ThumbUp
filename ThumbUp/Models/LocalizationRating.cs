using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThumbUp.Models
{
    public class LocalizationRating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LRaID { get; set; }
        public short LRaRating { get; set; }
        public string LRaOpinion { get; set; }
        public long LRaLocID { get; set; }
        [ForeignKey("LRaLocID")]
        [JsonIgnore]
        public Localization Localization { get; set; }
    }
}
