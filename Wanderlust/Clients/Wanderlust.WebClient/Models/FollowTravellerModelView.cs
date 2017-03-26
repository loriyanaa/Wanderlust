namespace Wanderlust.WebClient.Models
{
    public class FollowTravellerModelView
    {
        public string LoggedUserId { get; set; }

        public TravellerViewModel TravellerToFollow { get; set; }
    }
}