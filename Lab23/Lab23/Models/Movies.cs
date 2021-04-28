using System.ComponentModel.DataAnnotations;

namespace Lab23.Models
{
    public class Movies
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(20)]
        public string Genre { get; set; }

        public double Runtime { get; set; }
    }
}
