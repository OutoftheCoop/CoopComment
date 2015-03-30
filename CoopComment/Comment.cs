using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopComment
{
    public class Comment
    {
        public Int32 Id { get; set; }
        public Int32 PostId { get; set; }
        public Boolean IsApproved { get; set; }
        public DateTime Posted { get; set; }
        public CoopRelay.Domain.Models.Member Member { get; set; }
        public String Message { get; set; }
    }
}
