using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoopRelay.Domain.Models;

namespace CoopComment
{
    public class CommentRepository
    {
        public static void Save(Comment c)
        {
            var pc = new PropertyCollection();
            pc.Add(new Property() { Alias = "isApproved", Value = c.IsApproved });
            pc.Add(new Property() { Alias = "posted", Value = c.Posted });
            pc.Add(new Property() { Alias = "member", Value = c.Member.Id });
            pc.Add(new Property() { Alias = "message", Value = c.Message });
            CoopRelay.Relay.Content.Create(c.Member.Name + " " + c.Posted, c.PostId, "Comment", pc);
        }

        public static List<Comment> GetAll(int postid)
        {
            var cs = CoopRelay.Relay.Content.GetChildren(postid, "Comment");
            var result = new List<Comment>();
            foreach (var c in cs)
            {
                result.Add(Map(c));
            }
            var tmp = result.OrderBy(c => c.Posted);
            return tmp.ToList();
        }

        public static Comment Map(Content c)
        {
            return new Comment()
            {
                Id = c.Id,
                PostId = c.ParentId,
                IsApproved = c.Properties.GetBoolean("isApproved"),
                Posted = c.Properties.GetDateTime("posted"),
                Member = CoopRelay.Relay.Member.Get(c.Properties.GetInt("member")),
                Message = c.Properties.GetString("message")
            };
        }
    }
}
