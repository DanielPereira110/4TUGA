﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _4Tuga.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using _4Tuga.Models;
using System.Data.Entity;


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

            db.Entry(currentuser).State = EntityState.Modified;
            db.SaveChanges();
            
            return View(currentuser);
        }
    }
}