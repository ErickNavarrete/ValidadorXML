using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using ValidadorXML.Models;

namespace ValidadorXML.Controllers
{
    public class HomeController : Controller
    {
        private Entities db = new Entities();
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
                string result = new StreamReader(file.InputStream).ReadToEnd();
                
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);

                Inicial datos_generales = new Inicial();
                
                string json = JsonConvert.SerializeXmlNode(doc);
                json = json.Replace("?", "");
                json = json.Replace("@", "");
                json = json.Replace("cfdi:", "");
                json = json.Replace("tfd:", "");
                json = json.Replace("nomina12:", "");
                json = json.Replace("pago10:", "");

                datos_generales = JsonConvert.DeserializeObject<Inicial>(json);

                var rfc_e = db.rfc_lista_negra.Where(x => x.rfc == datos_generales.Comprobante.Emisor.Rfc).ToList();
                var rfc_r = db.rfc_lista_negra.Where(x => x.rfc == datos_generales.Comprobante.Receptor.Rfc).ToList();
            }

            return Json(new { Message = string.Empty });
        }
    }
}