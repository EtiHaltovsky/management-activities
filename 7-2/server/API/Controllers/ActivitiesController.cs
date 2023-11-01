using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using DTO;

namespace API.Controllers
{ 
    
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/activity")]
    public class ActivitiesController : ApiController
    {

        //שליפת פעילות לעדכון לפי id
        [Route("GetActivitiesById/{ActivityId}")]
        public DTO.Activities GetActivitiesById(int ActivityId)
        {
            DTO.Activities a= ActivitiesBL.GetActivities(ActivityId);
            return a;
        }

        ////זיהוי פעילות לפי ת.ז.
        //[Route("GetCheckActivityById/{Id}")]
        //public int GetCheckActivityById(int id)
        //{
        //    return ActivitiesBL.GetCheckActivityById(id);
        //}

        //עובד
        //הוספת פעילות
        [Route("GetAddNewActivities/{ActivitiesName}/{ActivitiesPlace}/{ActivitiesDate}/{Price}")]
        public string GetAddNewActivities(string activitiesName, string activitiesPlace, DateTime activitiesDate, double price)
        {
            return "new activity " + ActivitiesBL.AddNewActivities(new Activities(activitiesName, activitiesPlace, activitiesDate, price));
        }

        //עדכון פעילות
        [Route("GetUpdateActivity/{id}/{activitiesName}/{activitiesPlace}/{activitiesDate}/{price}")]
        public string GetUpdateActivity(int id, string activitiesName, string activitiesPlace, DateTime activitiesDate, double price)
        {
            if(ActivitiesBL.UpdateActivities(new Activities(id, activitiesName, activitiesPlace, activitiesDate, price))==true)
              return "change activity " +id ;
            return "dont change activity " + id;
        }
       
        //עובד
        //מחיקת פעילות
        [Route("GetDelete/{Name}")]
        public int GetDelete(int name)
        {
            return ActivitiesBL.GetDeleteActivity(name);
        }
        //עובד
        //שליפת כל הפעילויות
        [Route("GetAllActivities")]
        public List<Activities> GetAllActivities()
        {
            //העברה לגורם המטפל
            List<Activities> activities = ActivitiesBL.GetActivities();
            //החזרת התשובה למשתשמש
            return activities;
        }

        //החזרת טיול
        [Route("GetTrip/{year}")]
        public DTO.Trip GetTrip(int year)
        {
            return ActivitiesBL.GetTrip(year);
        }

        //החזרת מחנה
        [Route("GetCamp/{year}")]
        public DTO.Camp GetCamp(int year)
        {
            return ActivitiesBL.GetCamp(year);
        }

        //החזרת שבת מחנה
        [Route("GetShabbatCamp/{year}")]
        public DTO.ShabbesCamp GetShabbatCamp(int year)
        {
            return ActivitiesBL.GetShabbatCamp(year);
        }

        //הוספת תלמידה לטיול
        [Route("GetChooseTrip/{studentId}/{tripId}")]
        public int GetChooseTrip(string studentId, int tripId)
        {
            ActivitiesBL.GetChooseTrip(studentId, tripId);
            return 1;
        }

        //הוספת תלמידה למחנה
        [Route("GetChooseCamp/{studentId}/{campId}")]
        public int GetChooseCamp(string studentId, int campId)
        {
            ActivitiesBL.GetChooseCamp(studentId, campId);
            return 1;
        }

        //הוספת תלמידה לשבת מחנה
        [Route("GetChooseShabbatCamp/{studentId}/{shabbatId}")]
        public int GetChooseShabbatCamp(string studentId, int shabbatId)
        {
            ActivitiesBL.GetChooseShabbatCamp(studentId, shabbatId);
            return 1;
        }


        //שליפה של התלמידות שנרשמו לפעילות מסוימת-מחנה טיול או שבת מחנה
        [Route("GetStudentsOfActivity/{ActivitiesId}")]
        public List<Student> GetStudentsOfActivity(int ActivitiesId)
        {
            return BL.ActivitiesBL.GetStudentsOfActivity(ActivitiesId);
        }





    }



}