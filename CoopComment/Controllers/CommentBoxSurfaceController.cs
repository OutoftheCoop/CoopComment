using System;
using System.Web.Mvc;

namespace CoopComment.Controllers
{
    public class CommentBoxSurfaceController : Umbraco.Web.Mvc.SurfaceController
    {
        [HttpPost]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Submit(CommentBox model)
        {
            // POST COMMENT
            try
            {
                if (ModelState.IsValid)
                {
                    CommentService.Save(model.ContentId, model.Message);
                    return Content("Comment Saved.");
                }
                return Content("An error occurred. ");
            }
            catch (Exception ex) { return Content("An error occurred. " + ex.Message); }

        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return Redirect("/");
            }
        }
    }
}
