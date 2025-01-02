using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class UserProfile
    {
        public User? User { get; set; }
        public int? TotalPosts { get; set; }
        public int? TotalLikesReceived { get; set; }
        public int? TotalCommentsReceived { get; set; }
        public string? FriendshipStatus { get; set; }
        public int? FriendRequestId { get; set; }   //only for friend request sent/received
        public string? AdditionalMessage { get; set; }
    }
}
