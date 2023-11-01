using Codingvila_ReadExcel_API;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
//using DTO;

namespace Codingvila_ReadExcel_API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("Api/Excel")]
    public class ReadExcelController : ApiController
    {
        [Route("ReadFile")]
        [HttpPost]
        public string ReadFile()
        {
            try
            {
                #region Variable Declaration
                string message = "";
                HttpResponseMessage ResponseMessage = null;
                var httpRequest = HttpContext.Current.Request;
                DataSet dsexcelRecords = new DataSet();
                IExcelDataReader reader = null;
                HttpPostedFile Inputfile = null;
                Stream FileStream = null;
                #endregion

                #region Save Student Detail From Excel
                //using (dbCodingvilaEntities objEntity = new dbCodingvilaEntities())
                
                    if (httpRequest.Files.Count > 0)
                    {
                        Inputfile = httpRequest.Files[0];
                        FileStream = Inputfile.InputStream;

                        if (Inputfile != null && FileStream != null)
                        {
                            if (Inputfile.FileName.EndsWith(".xls"))
                                reader = ExcelReaderFactory.CreateBinaryReader(FileStream);
                            else if (Inputfile.FileName.EndsWith(".xlsx"))
                                reader = ExcelReaderFactory.CreateOpenXmlReader(FileStream);
                            else
                                message = "The file format is not supported.";

                            dsexcelRecords = reader.AsDataSet();
                            reader.Close();

                            if (dsexcelRecords != null && dsexcelRecords.Tables.Count > 0)
                            {
                                DataTable dtStudentRecords = dsexcelRecords.Tables[0];
                                for (int i = 1; i < dtStudentRecords.Rows.Count; i++)
                                {
                                    DTO.Student objStudent = new DTO.Student();
                                    objStudent.Id = Convert.ToString(dtStudentRecords.Rows[i][0]);
                                    objStudent.LastName = Convert.ToString(dtStudentRecords.Rows[i][1]);
                                    objStudent.FirstName = Convert.ToString(dtStudentRecords.Rows[i][2]);
                                    objStudent.Email = Convert.ToString(dtStudentRecords.Rows[i][3]);
                                    objStudent.Address = Convert.ToString(dtStudentRecords.Rows[i][4]);
                                    objStudent.Phone = Convert.ToString(dtStudentRecords.Rows[i][5]);
                                    objStudent.MotherName = Convert.ToString(dtStudentRecords.Rows[i][6]);
                                    objStudent.FatherName = Convert.ToString(dtStudentRecords.Rows[i][7]);
                                    objStudent.Password = Convert.ToString(dtStudentRecords.Rows[i][8]);
                                    objStudent.ClassNum = Convert.ToString(dtStudentRecords.Rows[i][9]);
                                    objStudent.Pharm = Convert.ToString(dtStudentRecords.Rows[i][10]);
                                    objStudent.Age = Convert.ToDouble(dtStudentRecords.Rows[i][11]);
                                    objStudent.Role = Convert.ToString(dtStudentRecords.Rows[i][12]);


                                //Add student to db 
                                BL.StudentBL.AddUser(objStudent);
                                 //  objEntity.Students.Add(objStudent);
                                }

                                int output = 1;// objEntity.SaveChanges();
                                if (output > 0)
                                    message = "The Excel file has been successfully uploaded.";
                                else
                                    message = "Something Went Wrong!, The Excel file uploaded has fiald.";
                            }
                            else
                                message = "Selected file is empty.";
                        }
                        else
                            message = "Invalid File.";
                    }
                    else
                        ResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest);
                
                return message;
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}