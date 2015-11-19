using MVCRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace MVCRegistration.Controllers
{
    public class PostController : Controller
    {
        private string imgFolder = "/Images/profileimages/";
        private string defaultAvatar = "user.png";
        private UsersContext db = new UsersContext();

        // GET api/WallPost
        public JsonResult GetPosts()
        {
            var ret = (from post in db.Posts.ToList()
                       orderby post.PostedDate descending
                       select new
                       {
                           Message = post.Message,
                           PostedBy = post.PostedBy,
                           // UserId = post.UserId,
                           PostedByName = post.UserProfile.UserName,
                           PostedByAvatar = imgFolder + (String.IsNullOrEmpty(post.UserProfile.AvatarExt) ? defaultAvatar : post.PostedBy + "." + post.UserProfile.AvatarExt),
                           PostedDate = post.PostedDate,
                           PostId = post.PostId,
                           PostComments = from comment in post.PostComments.ToList()
                                          orderby comment.CommentedDate
                                          select new
                                          {
                                              CommentedBy = comment.CommentedBy,
                                              CommentedByName = comment.UserProfile.UserName,
                                              CommentedByAvatar = imgFolder + (String.IsNullOrEmpty(comment.UserProfile.AvatarExt) ? defaultAvatar : comment.CommentedBy + "." + comment.UserProfile.AvatarExt),
                                              CommentedDate = comment.CommentedDate,
                                              CommentId = comment.CommentId,
                                              Message = comment.Message,
                                              PostId = comment.PostId
                                              //  UserId = comment.UserId
                                          }
                       }).AsEnumerable(); 
                return Json(ret, JsonRequestBehavior.AllowGet);
        }

        

        // POST api/WallPost
        public JsonResult PostPost(Post post)
        {
            post.PostedBy = WebSecurity.CurrentUserId;
            post.PostedDate = DateTime.UtcNow;
            // post.UserProfile.UserId = WebSecurity.CurrentUserId;
            ModelState.Remove("post.PostedBy");
            ModelState.Remove("post.PostedDate");
            //  ModelState.Remove("post.UserProfile.UserId");

           // if (ModelState.IsValid)
          //  {
                db.Posts.Add(post);
                db.SaveChanges();
                var usr = db.UserProfile.FirstOrDefault(x => x.UserId == post.PostedBy);
                var ret = new
                {
                    Message = post.Message,
                    PostedBy = post.PostedBy,
                    PostedByName = usr.UserName,
                    PostedByAvatar = imgFolder + (String.IsNullOrEmpty(usr.AvatarExt) ? defaultAvatar : post.PostedBy + "." + post.UserProfile.AvatarExt),
                    PostedDate = post.PostedDate,
                    PostId = post.PostId
                    //  UserId = usr.UserId
                };
              //  HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, ret);
              //  response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = post.PostId }));
              //  return response;
         //   }
            //else
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            //}
                return Json(ret, JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
