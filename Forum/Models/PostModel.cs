using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class PostModel
    {
        public int PostModelID { get; set; }
        public string PostTemat { get; set; }
        public string PostModelCialo { get; set; }
        public string Tworca { get; set; }
        public DateTime DataDodania { get; set; }
        public int TematID { get; set; }
        public TematModel TematModel { get; set; }
    }
        
    
}
