using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class TematModel
    {   [Key]
        public int TematID { get; set; }
        public string Temat { get; set; }
        public string TematImg { get; set; }
        public string Tworca { get; set; }
        public DateTime DataDodania { get; set; }
        public ICollection<PostModel> posts { get; set; }
    }
}
