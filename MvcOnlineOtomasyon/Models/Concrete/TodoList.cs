using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Concrete
{
    public class TodoList
    {
        [Key]
        public int TodoListId { get; set; }
        public string Topic { get; set; }
        public bool Status { get; set; }
    }
}