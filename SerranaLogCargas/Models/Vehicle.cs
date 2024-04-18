using System.ComponentModel.DataAnnotations;

namespace SerranaLogCargas.Models
{
    public class Vehicle
    {
        [Key] 
        public int Id { get; set; }
       
        [Required]
        [Display(Name ="Placa")]
        [StringLength(7)]
        public string Plate{ get; set; }

        [Required]
        [Display(Name ="Descrição")]
        public string Description { get; set; }

        public Driver Driver { get; set; }
        
        [Display(Name = "Motorista")]
        public int DriverID { get; set; }


        public Vehicle ()
        {
        }

        public Vehicle (int id, string plate, string description, Driver driver)
        {
            Id = id;
            Plate = plate;
            Description = description;
            Driver = driver;
        } 
    }
}
