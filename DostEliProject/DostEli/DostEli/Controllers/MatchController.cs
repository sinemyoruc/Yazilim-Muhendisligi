using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;
using DostEli.Models;

namespace DostEli.Controllers
{
    public class MatchController : Controller
    {
        // GET: Match
        DostEliEntities db = new DostEliEntities();
        public ActionResult Index()
        {
            var degerler = db.Table_Volunteer.ToList();
            var UserDegerler = db.Table_User.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult UploadExcel(HttpPostedFileBase excelFile)
        {
            if (excelFile == null || excelFile.ContentLength == 0)
            {
                ViewBag.Error = "Lütfen dosya seçimi yapınız.";
                return View();
            }
            else
            {
                if (excelFile.FileName.EndsWith("xls") || excelFile.FileName.EndsWith("xlsx"))
                {
                    string path = Server.MapPath("~/Content/" + excelFile.FileName);
                    //Dosya kontrol edilir, varsa silinir.
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    //Ecxel path altına kaydedilir.
                    excelFile.SaveAs(path);

                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;

                    List<ListeModel> MatchList = new List<ListeModel>();
                    for (int i = 1; i <= range.Rows.Count; i++)
                    {
                        ListeModel lm = new ListeModel();
                        lm.Yaslilar = ((Excel.Range)range.Cells[i, 1]).Text;
                        lm.Gonulluler = ((Excel.Range)range.Cells[i, 2]).Text;
                        MatchList.Add(lm);
                    }
                    application.Quit();
                    ViewBag.ListDetay = MatchList;
                    return View("Listele");

                }
                else
                {
                    ViewBag.Error = "Dosya tipiniz yanlış, lütfen '.xls' ya da '.xlsx' uzantılı dosya yükleyiniz! ";
                    return View();
                }

            }

        }
    }
}