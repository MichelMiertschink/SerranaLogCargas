using System.ComponentModel.DataAnnotations;

namespace SerranaLogCargas.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Cidade")]
        [Required]
        public string Name { get; set; }
        public State State { get; set; }
        
        public City()
        {
        }

        public City(int id, string name, State state)
        {
            Id = id;
            Name = name;
            State = state;
        }

    }
}
