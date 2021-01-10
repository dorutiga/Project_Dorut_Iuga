using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project_Dorut_Iuga.Models
{
    public class Game
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Game Title")]
        public string Title { get; set; }
       

        public string GameType{ get; set; }
        
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public int DeveloperID { get; set; }
        public Developer Developer { get; set; }
        public ICollection<GameCategory> GameCategories { get; set; }
    }
}
