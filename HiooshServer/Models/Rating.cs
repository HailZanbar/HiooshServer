
using System.ComponentModel.DataAnnotations;

namespace HiooshServer.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [Display(Name = "Numerical rating")]
        [Range(1,5)]
        public int NumberRating { get; set; }

        [Display(Name= "Verbal feedback")]
        public string StringRating { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Date")]
        public string Date { get; set; }
    }
}
