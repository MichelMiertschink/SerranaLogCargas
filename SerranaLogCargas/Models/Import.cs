using LogCargas.Data;

namespace LogCargas.Models
{
    public class Import
    {
        public SeedingService SeedingService { get;}

        public Import ()
        {
        }

        public Import (SeedingService seedingService)
        {
            SeedingService = seedingService;
        }   
    }
}
