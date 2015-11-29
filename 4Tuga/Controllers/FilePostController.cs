using _4Tuga.DAL;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers
{
    public class FilePostController : Controller
    {
        private PostContext db = new PostContext();
        //
        // GET: /File/
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}          
