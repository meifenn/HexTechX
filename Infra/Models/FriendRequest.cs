using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Models
{
    [Table("FriendRequest")]
    public class FriendRequest
    {
        [Key]
        public int ID { get; set; } 
        public int? FromUserID { get; set; }
        public string? FromUserName { get; set; }
        public int? ToUserID {  get; set; } 
        public string? ToUserName { get; set; }
        public DateTime? RequestedTime { get; set; }
        public bool? IsAccepted { get; set; } = null;
    }
}
