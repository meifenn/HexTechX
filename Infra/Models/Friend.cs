using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Models
{
    [Table("Friend")]
    public class Friend
    {
        [Key]
        public int ID { get; set; }
        public int? UserID { get; set; } 
        public string? UserName {  get; set; }  
        public int? FriendID { get;set; }
        public string? FriendName { get; set; }
        public DateTime? AcceptedTime { get; set; }
        public DateTime? RequestedTime { get;set; }
    }
}
