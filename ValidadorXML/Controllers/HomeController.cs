using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace ValidadorXML.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Example()
        {
            return View();
        }

        public ActionResult SaveDropzoneJsUploadedFiles()
        {
            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];
                //You can Save the file content here
                BinaryReader b = new BinaryReader(file.InputStream);
                byte[] binData = b.ReadBytes(file.ContentLength);
                string result = System.Text.Encoding.UTF8.GetString(binData);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);
                string json = JsonConvert.SerializeXmlNode(doc);
                json = json.Replace("?", "");
                json = json.Replace("@", "");
                json = json.Replace("cfdi:", "");
                json = json.Replace("tfd:", "");
                json = json.Replace("nomina12:", "");
                json = json.Replace("pago10:", "");
            }

            return Json(new { Message = string.Empty });
        }
    }
}