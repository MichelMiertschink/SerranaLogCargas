using System.ComponentModel.DataAnnotations;


namespace LogCargas.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Sigla")]
        [StringLength(2, ErrorMessage = "Tamanho informado incorreto")]
        public string Acronym { get; set; }
        [Display(Name = "Estado")]
        [Required]
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; } = new List<City>();

        public State()
        {
        }

        public State (int id, string sigla, string name)
        {
            Id = id;
            Acronym = sigla;
            Name = name;
        } 
    }
}
