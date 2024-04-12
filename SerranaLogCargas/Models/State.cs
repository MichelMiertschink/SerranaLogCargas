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
        public ICollection<City> City { get; set; }

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
            City.Add(city);
        }

        public void RemoveCity (City city)
        {
            City.Remove(city);
        }
    }
}
