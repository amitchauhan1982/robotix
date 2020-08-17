using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace robotix.Model
{
    public class cmspages
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rank { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } 
        public cmspages()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }
}
