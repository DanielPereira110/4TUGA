using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _4Tuga.DAL;
using _4Tuga.Models;
using Microsoft.AspNet.Identity;

namespace _4Tuga.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index(int? id)
        {
            if(id != null)
                return View(db.Posts.ToList().Where(p => p.SubCategoryID == id));

            return RedirectToAction("Index", "Home");
        }

        // Admin GET: Posts
        public ActionResult IndexAdmin() 
        {
            //if(User.IsInRole(""))
                return View(db.Posts.ToList());

            //return RedirectToAction("Index", "Home");
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Include(s=>s.FilesPost).SingleOrDefault(s => s.ID == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.SubCategoryID = new SelectList(db.SubCategories, "ID", "Name");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Body,PublishDate,Image,SubCategoryID")] Post post, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                //GET ID
                string currentUserID = User.Identity.GetUserId();
                //Search in db for username with this id
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserID);
                //post.User = currentUser;
                var subcateg = db.SubCategories.FirstOrDefault(s => s.ID == post.SubCategoryID);

                if (upload != null && upload.ContentLength > 0)
                {
                    var avatar = new FilePost
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    post.FilesPost = new List<FilePost> { avatar };
                }


                db.Posts.Add(post);
                subcateg.Post.Add(post);
                currentUser.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index", "Categories");
            }

            ViewBag.SubCategoryID = new SelectList(db.SubCategories, "ID", "Name", post.SubCategoryID);
            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategoryID = new SelectList(db.SubCategories, "ID", "Name");
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Body,PublishDate,Image,SubCategoryID")] Post post, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                //if (upload != null && upload.ContentLength > 0)
                //{
                //    if (post.FilesPost.Any(f => f.FileType == FileType.Avatar))
                //    {
                //        db.FilesPost.Remove(post.FilesPost.First(f => f.FileType == FileType.Avatar));
                //    }
                //    var avatar = new FilePost
                //    {
                //        FileName = System.IO.Path.GetFileName(upload.FileName),
                //        FileType = FileType.Avatar,
                //        ContentType = upload.ContentType
                //    };
                //    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                //    {
                //        avatar.Content = reader.ReadBytes(upload.ContentLength);
                //    }
                //    post.FilesPost = new List<FilePost> { avatar };
                //}


                db.Entry(post).State = EntityState.Modified;

                /* 
                SubCategory subcateg = db.SubCategories.FirstOrDefault(s => s.ID == post.SubCategoryID);
                var postdb = db.Posts.FirstOrDefault(p => p.ID == post.ID);
                postdb.SubCategory.Clear();
                subcateg.Post.Add(postdb);
                */

                db.SaveChanges();
                return RedirectToAction("Index", "Categories");
            }

            ViewBag.SubCategoryID = new SelectList(db.SubCategories, "ID", "Name", post.SubCategoryID);
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index", "Categories");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
