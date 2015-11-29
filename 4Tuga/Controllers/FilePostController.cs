using _4Tuga.DAL;
using System.Web.Mvc;

namespace _4Tuga.Controllers
{
    public class FilePostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /File/
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.FilesPost.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}          
