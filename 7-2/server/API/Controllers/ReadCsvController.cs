using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using DTO;
using System.IO;


namespace API.Controllers
{

    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/ReadCsv")]
    public class ReadCsvController : ApiController
    {
        //[Route("getExel"), HttpPost]
        //public void LoadNeedies()
        //{
        //    HttpPostedFile file = HttpContext.Current.Request.Files[0];
        //    string path = HttpContext.Current.Server.MapPath("~/App_Data" + file.FileName);
        //    file.SaveAs(path);
        //}
        [HttpPost]
        [Route("PostExcel")]
        public bool PostExcel()
        {
            readFromExcel r = new readFromExcel();
            try
            {
                var files = HttpContext.Current.Request.Files;
                var folderName = Path.Combine("files");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (files.Count > 0)
                {
                    var docfiles = new List<string>();
                    foreach (string item in files)
                    {
                        var postedFile = files[item];
                        var fullPath = Path.Combine(pathToSave, postedFile.FileName);
                        var dbPath = Path.Combine(folderName, postedFile.FileName);
                        var filePath = HttpContext.Current.Server.MapPath("~/" + folderName + "//" + postedFile.FileName);
                        postedFile.SaveAs(filePath);
                        docfiles.Add(filePath);
                        r.ReadFromExcel(filePath);
                        //r.ReadFromExcel(@"D:\shoshi\driversShiftsProject\server\Bll\API\files\" + postedFile.FileName);
                        //string s = OcrText.OpticalCharacterRecognition(filePath.ToString()).ToString();
                        //מתחיל להפעיל את האלגוריתם

                        //Resources\\Images\\pic45.png
                    }
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}





