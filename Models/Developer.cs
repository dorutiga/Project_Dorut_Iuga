using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Dorut_Iuga.Models
{
    public class Developer
    {
        public int ID { get; set; }
        public string DeveloperName { get; set; }
        public ICollection<Game> Books { get; set; }
    }
}
