using System;
using System.Collections.Generic;

namespace CoopComment
{
    public class CommentList
    {
        public int ContentId { get; set; }
        public List<Comment> Comments { get; set; }

        public CommentList(int contentid)
        {
            ContentId = contentid;
            Comments = CommentService.GetAll(contentid);
        }
    }
}
