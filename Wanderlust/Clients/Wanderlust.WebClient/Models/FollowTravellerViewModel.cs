namespace Wanderlust.WebClient.Models
{
    public class FollowTravellerViewModel
    {
        public string LoggedUserId { get; set; }

        public TravellerViewModel TravellerToFollow { get; set; }
    }
}