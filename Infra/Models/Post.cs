using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public int ID { get; set; }
        public string? Title { get; set; }  
        public string? Description { get; set; }    
        public string? PhotoDatas { get; set; } 
        public string? Tags { get; set; }   
        public int? LikeCount { get; set; } 
        public int? CommentCount { get; set; }  
        public DateTime? CreatedTime { get; set; }  
        public DateTime? ModifiedTime { get; set; }
        public int? UploadedById { get; set; }  
        public string? UploadedUserName { get; set; }
        public string? UploadedUserPhoto { get; set; }
      
    }
}
