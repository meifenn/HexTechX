using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int ID { get; set; } 
        public string? UserName { get; set; }   
        public string? Password { get; set; }   
        //public string? ProfilePhoto { get; set; }   
        public DateTime? CreatedTime { get; set; } 
        public DateTime? ModifiedTime { get; set; }
        //[NotMapped]
        //public string? ProfilePhotoUrl { get; set; }
    }
}
