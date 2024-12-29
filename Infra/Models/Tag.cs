using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Models
{
    [Table("Tag")]
    public class Tag
    {
        [Key]
        public int ID { get; set; } 
        public string? Text { get; set; }
        public DateTime? CreatedAt { get; set; }    
        public int? PostCount { get; set; } // count of total posts that is included in that tag
    }
}
