using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;

namespace MvcGarage2.Controllers
{
   
    public class HtmlToPdfConverterController : Controller
    {
        // GET: HtmlToPdfConverter 
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitAction(IFormCollection collection)
        {
            // instantiate a html to pdf converter object 
            HtmlToPdf converter = new HtmlToPdf();

            // create a new pdf document converting an url 
            PdfDocument doc = converter.ConvertUrl(collection["TxtUrl"]);

            // save pdf document 
            byte[] pdf = doc.Save();

            // close pdf document 
            doc.Close();

            // return resulted pdf document 
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";
            return fileResult;
        }

    }

}