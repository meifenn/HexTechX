using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Models
{
    [Table("Like")]
    public class Like
    {
        [Key]
        public int ID { get; set; }
        public int? UserID { get; set; }
        public int? PostID { get; set; }    
        public DateTime? CreatedTime { get; set; }

    }
}
