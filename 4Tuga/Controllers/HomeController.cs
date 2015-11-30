using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _4Tuga.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using _4Tuga.Models;
using System.Data.Entity;
using System.Threading.Tasks;


namespace _4Tuga.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Cookies()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Regulation()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult userdet(HttpPostedFileBase upload)
        {
            ViewBag.Message = "Your contact page.";
            string userid = User.Identity.GetUserId();
            var currentuser = db.Users.SingleOrDefault(u => u.Id == userid); 
            return View(currentuser);
        }

        //
        //GET : edit user
        [Authorize]
        public ActionResult userEdit()
        {
            ViewBag.Message = "Your contact page.";
            string userid = User.Identity.GetUserId();
            var currentuser = db.Users.SingleOrDefault(u => u.Id == userid);
            return View(currentuser);
        }

        //
        //POST: edit user
        [Authorize]
        [HttpPost]
        public ActionResult userEdit(ApplicationUser model, HttpPostedFileBase upload)
        {
            ViewBag.Message = "Your contact page.";
            string userid = User.Identity.GetUserId();
            var currentuser = db.Users.SingleOrDefault(u => u.Id == userid);
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (upload != null && upload.ContentLength > 0)
            {
                if (currentuser.Files.Any(f => f.FileType == FileType.Avatar))
                {
                    db.Files.Remove(currentuser.Files.First(f => f.FileType == FileType.Avatar));
                }
                var avatar = new File
                {
                    FileName = System.IO.Path.GetFileName(upload.FileName),
                    FileType = FileType.Avatar,
                    ContentType = upload.ContentType
                };
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    avatar.Content = reader.ReadBytes(upload.ContentLength);
                }
                currentuser.Files = new List<File> { avatar };
            }
            currentuser.UserName = model.Email;
            currentuser.Email = model.Email;
            currentuser.Name = model.Name;
            currentuser.Gender = model.Gender;
            currentuser.DateofBirth = model.DateofBirth;

            
            var result = UserManager.Update(currentuser);
            db.Entry(currentuser).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("userdet");
        }

        //
        //GET: delete user
        [Authorize]
        public ActionResult userDelete()
        {
            ViewBag.Message = "Your contact page.";
            string userid = User.Identity.GetUserId();
            var currentuser = db.Users.SingleOrDefault(u => u.Id == userid);
            return View(currentuser);
        }

        //
        //POST: Delete user
        [Authorize]
        [HttpPost]
        public ActionResult userDelete(ApplicationUser model)
        {
            ViewBag.Message = "Your contact page.";
            string userid = User.Identity.GetUserId();
            var currentuser = db.Users.SingleOrDefault(u => u.Id == userid);
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var logins = currentuser.Logins;

            foreach (var login in logins.ToList())
            {
                 UserManager.RemoveLogin(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
            }

            var rolesForUser = UserManager.GetRoles(userid);

            if (rolesForUser.Count() > 0)
            {
                foreach (var item in rolesForUser.ToList())
                {
                    // item should be the name of the role
                    var result = UserManager.RemoveFromRole(currentuser.Id, item);
                }
            }

            var PostsForUser = currentuser.Posts;

            foreach (var item in PostsForUser.ToList())
            {
                db.Posts.Remove(item);
            }

            var ComentsForUser = currentuser.Comments;

            foreach (var item in ComentsForUser.ToList())
            {
                db.Comments.Remove(item);
            }

            UserManager.Delete(currentuser);

            return RedirectToAction("AfterDelete");
        }

        //
        //GET: delete user
        [Authorize]
        public ActionResult AfterDelete()
        {
            return View();
        }

    }
}