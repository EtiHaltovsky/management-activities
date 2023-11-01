using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using BL;
using DTO;
namespace API.Controllers
{

    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/manager")]
    public class ManagerController : ApiController
    {


        //בדיקה אם זה מנהל או מורה
        [Route("GetCheckTeacherOrManager/{id}")]

        public bool GetCheckTeacherOrManager(string id)
        {
            return ManagerBL.CheckTeacherOrManager(id);
        }
    }


    // בודקת סיסמת מנהל
    //[Route("GetCheckManagerPassword/{password}")]

    //public bool GetCheckManagerPassword(string password)
    //{
    //    return ManagerBL.CheckManagerPassword(password);
    //}


    //מחיקת מנהל
    //[Route("GetDelete/{Id}")]
    //public int GetDelete(string id)
    //{
    //    return ManagerBL.GetDeleteManager(id);
    //}
}

