using System.ComponentModel.DataAnnotations.Schema;

namespace ETrainerWEB.Models
{
    public class Friends
    {
        public int UserId { set; get; }
        public User User { set; get; }
        public int FriendId { set; get; }
        public User Friend { set; get; }
    }
}