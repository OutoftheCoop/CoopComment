using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopComment
{
    public class CommentService
    {
        public static void Save(int contentid, string message)
        {
            var c = new Comment();
            c.IsApproved = true;
            c.Member = CoopRelay.Relay.Member.Current;
            c.Message = System.Web.HttpUtility.HtmlEncode(message);
            c.Posted = DateTime.Now.ToUniversalTime();
            c.PostId = contentid;
            CommentRepository.Save(c);
        }

        public static List<Comment> GetAll(int contentid)
        {
            return CommentRepository.GetAll(contentid);
        }

        public static String ToJavascriptTime(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss UTC");
        }
    }
}
