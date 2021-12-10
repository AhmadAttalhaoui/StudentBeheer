using System.ComponentModel.DataAnnotations;

namespace StudentBeheer.Models
{
    public class Module
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Titel")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Beschrijving")]
        public string Desc { get; set; }

        [Required]
        [Display(Name = "Begin Data")]
        [DataType(DataType.Date)]
        public DateTime Begin { get; set; }

        [Required]
        [Display(Name = "Eind Data")]
        [DataType(DataType.Date)]
        public DateTime Eind { get; set; }
        public IList<Inschrijvingen> Inschrijvingen { get; set; }
    }
}
