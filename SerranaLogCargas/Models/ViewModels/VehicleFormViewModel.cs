namespace SerranaLogCargas.Models.ViewModels
{
    public class VehicleFormViewModel
    {
        public Vehicle Vehicle { get; set; }
        public ICollection<Driver> Driver { get; set; }

    }
}
