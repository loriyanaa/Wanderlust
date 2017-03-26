using System.Collections.Generic;

namespace Wanderlust.WebClient.Models
{
    public class TravellersViewModel
    {
        public IEnumerable<TravellerViewModel> Travellers { get; set; }

        public string LoggedUserId { get; set; }

        public bool UserIsAuthenticated { get; set; }
    }
}