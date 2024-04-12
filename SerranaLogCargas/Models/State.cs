using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerranaLogCargas.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Sigla")]
        [Required]
        public string Sigla { get; set; }
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
            Sigla = sigla;
            Name = name;
        } 

        public void AddCity (City city)
        {
            Cities.Add(city);
        }

        public void RemoveCity (City city)
        {
            Cities.Remove(city);
        }
    }
}
