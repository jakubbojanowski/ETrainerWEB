using System.ComponentModel.DataAnnotations.Schema;

namespace ETrainerWEB.Models
{
    public class Friends
    {
        public string UserId { set; get; }
        public User User { set; get; }
        public string FriendId { set; get; }
        public User Friend { set; get; }
    }
}