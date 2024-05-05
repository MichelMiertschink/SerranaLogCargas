namespace LogCargas.Models.ViewModels
{
    public class LoadSchedulingFormViewModel
    {
        public LoadScheduling LoadScheduling { get; set; }
        public ICollection<Customer> Customer { get; set; }
        public ICollection<City> City { get; set; }

    }
}
