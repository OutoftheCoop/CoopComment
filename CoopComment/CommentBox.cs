using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoopComment
{
    public class CommentBox
    {
        public int ContentId { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
