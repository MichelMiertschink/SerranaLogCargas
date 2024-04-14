namespace SerranaLogCargas.Models.ViewModels
{
    public class CityFormViewModel
    {
        public City City{ get; set; }
        public ICollection<State> States { get; set; }
    }
}
