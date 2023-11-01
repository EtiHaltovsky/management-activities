using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BL;


namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/teacher")]
    public class TeacherController : ApiController
        {

        //עובד
        //להוספת מורה חדשה
        [Route("GetAddNewTeacher/{Id}/{FirstName}/{LastName}/{Phone}/{Address}/{Password}/{Educator}/{Email}/{role}")]
        public int GetAddNewTeacher(string id, string firstName, string lastName,
             string phone, string address, string password, string educator, string email,string role)
        {
            
            bool e = bool.Parse(educator);
            return  TeacherBL.AddTeacher(new Teacher(id, firstName, lastName, phone, address, password, e, email,role));
        }

        //עדכון פרטי מורה
        [Route("GetUpdateTeacherDetails/{Id}/{FirstName}/{LastName}/{Phone}/{Address}/{Password}/{Educator}/{Email}/{role}")]
        public string GetUpdateStudentDetails(string id, string firstName, string lastName,
             string phone, string address, string password, string educator, string email, string role)
        {
            bool e = bool.Parse(educator);
            return "change " + TeacherBL.UpdateTeacherDetails(new Teacher(id, firstName, lastName, phone, address, password, e, email, role));
        }

        //בחירת פעילות למורה
        [Route("GetChooseActivities/{teacherId}/{activitiesId}")]
        public string GetChooseActivities(string teacherId, int activitiesId)
        {
            TeacherBL.ChooseActivities(teacherId, activitiesId);
            return "choose activity to teacher" + activitiesId;
        }

        //סיסמת מורה
        [Route("GetCheckTeacherPassword/{password}")]
        public DTO.Teacher GetCheckTeacherPassword(string password)
        {
            DTO.Teacher t = TeacherBL.CheckTeacherPassword(password);
            return t;
        }

        //מחיקת מורה
        [Route("GetDelete/{Id}")]
        public int GetDelete(string id)
        {
            return TeacherBL.GetDeleteTeacher(id);
        }


        [Route("GetDeleteTeacherFromActivity/{activitiesId}/{teacherId}")]
        public int GetDeleteTeacherFromActivity(int activitiesId, string teacherId)
        {
            return TeacherBL.GetDeleteTeacherFromActivity(activitiesId, teacherId);
        }


        //לשליפת מורה לפי תעודת זהות
        [Route("GetTeacher/{Id}")]
        public Teacher GetTeacher(string id)
        {
            return TeacherBL.GetTeacherById(id);
        }


        //קבלת כל המורות
        [Route("GetAllTeachers")]
        public List<Teacher> GetAllTeachers()
        {
            //העברה לגורם המטפל
            List<Teacher> teachers = TeacherBL.GetTeachers();
            //החזרת התשובה למשתשמש
            return teachers;
        }

    }
}

