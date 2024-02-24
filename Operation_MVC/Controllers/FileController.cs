using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Operation_MVC.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        public FileResult Download(string fileName)
        {
            var filePath = Path.Combine(Server.MapPath("~/Uploads"), fileName);
            return File(filePath, MimeMapping.GetMimeMapping(filePath), fileName);
        }

    }
}