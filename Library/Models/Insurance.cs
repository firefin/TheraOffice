using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Insurance
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        //Since using string, when setting the key, use .ToLower()
        //I know IRL, they use a standardized code, but fuck that shit lol.
        public Dictionary<string, decimal> Coverages { get; set; }
     
        public Insurance() 
        {
            Name = string.Empty;
            Coverages = new Dictionary<string, decimal>();
        }
    }
}
