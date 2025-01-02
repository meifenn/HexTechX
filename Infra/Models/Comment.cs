using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int ID { get; set; } 
        public string? Text { get; set; }   
        public int? PostID { get; set; }   
        public int? UserID { get; set; }    
        public string? UserName { get; set; }
        public DateTime? CreatedTime { get; set; }  
    }
}
