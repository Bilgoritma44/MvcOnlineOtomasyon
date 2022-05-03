using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}