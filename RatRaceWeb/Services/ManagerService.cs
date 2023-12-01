using RatRaceBLL;

namespace RatRaceWeb.Services
{
    public class ManagerService
    {
        internal Manager Manager { get; set; }
        internal RatRaceRepository RatRaceRepository { get; set; }

        public ManagerService(Manager manager, RatRaceRepository ratRaceRepository)
        {
            Manager = manager;
            RatRaceRepository = ratRaceRepository;
        }
    }
}
