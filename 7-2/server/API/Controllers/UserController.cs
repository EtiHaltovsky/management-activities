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
    [EnableCors("*","*","*")]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [Route("GetSayHello/{name}")]
        public string GetSayHello(string name)
        {
            return "hello " + name;
        }

      
        //עובד
        //בדיקת סיסמת משתמש
        [Route("GetCheckPassword/{id}/{password}")]
        public  Person GetCheckPassword(string id,string password)
        {
            return userBL.CheckUserPassword(id,password);
        }


        //להוספת תלמידה חדשה
        [Route("GetAddNewUser/{Id}/{FirstName}/{LastName}/{FatherName}/{MotherName}/{Sister}/{Phone}/{Address}/{age}/{ClassNum}/{Pharm}/{Email}/{Password}/{Role}")]
        public int GetAddNewUser(string id,string firstName, string lastName,
            string fatherName, string motherName,bool sister, string phone, string address, double age,string classNum, string pharm, string email, string password, string role)
        {
            return  StudentBL.AddUser(new Student(id, firstName, lastName, fatherName, motherName,sister,phone, address,age,classNum,pharm, email,password,role));
        }




        //עדכון פרטי תלמידה
        [Route("GetUpdateStudentDetails/{Id}/{FirstName}/{LastName}/{FatherName}/{MotherName}/{Sister}/{Phone}/{Address}/{age}/{ClassNum}/{Pharm}/{Email}/{Password}/{Role}")]
        public string GetUpdateStudentDetails(string id, string firstName, string lastName, string fatherName, string motherName, bool sister, string phone, string address, double age, string classNum, string pharm,  string email,string password,string role)
        {
            return "change " + StudentBL.UpdateStudentDetails(new Student(id, firstName, lastName, fatherName, motherName, sister, phone, address, age, classNum, pharm,  email, password, role));
        }

        //עובד
        //לשליפת תלמידה לפי תעודת זהות
        [Route("GetUser/{Id}")]
        public Student GetUser(string id)
        {
            return StudentBL.GetUserById(id);
        }

        //עובד
        //מחיקת תלמידה
        [Route("GetDelete/{Id}")]
        public int GetDelete(string id)
        {
            return StudentBL.GetDeleteStudent(id);
        }
        //עובד
        //בחירת פעילות לתלמידה
        [Route("GetChooseActivities/{studentId}/{activitiesId}")]
        public string GetChooseActivities(string studentId, int activitiesId)
        {
            StudentBL.ChooseActivities(studentId, activitiesId);
            return "choose activity to student" + activitiesId;
        }

        //זיהוי המשתמש לפי ת.ז.
        [Route("GetCheckPersonById/{Id}")]
        public int GetCheckPersonById(string id)
        {
            return userBL.CheckPersonById(id);
        }

        [Route("GetDeserilazeFromXML")]
        public void GetDeserilazeFromXML()
        {
             StudentBL.DeserilazeFromXML();
        }

        //עובד
        //קבלת בקשה מהמשתמש
        //קבלת כל התלמידות
        [Route("GetAllUsers")]
        public List<Student> GetAllUsers()
        {
            //העברה לגורם המטפל
            List<Student> users = StudentBL.GetUsers();
            //החזרת התשובה למשתשמש
            return users;
        }

        //צריך לסדר
        //[Route("GetAddStudenToTrip/{Id}/{FirstName}/{LastName}/{FatherName}/{MotherName}/{Sister}/{Phone}/{Address}/{age}/{ClassNum}/{Pharm}/{Password}/{Email}/{Role}")]
        //public string GetAddStudenToTrip(string id, string firstName, string lastName,
        //    string fatherName, string motherName, bool sister, string phone, string address, double age, string classNum, string pharm, string password, string email,string role)
        //{
        //    return "add student to trip " + StudentBL.AddStudenToTrip(new Student(id, firstName, lastName, fatherName, motherName, sister, phone, address, age, classNum, pharm, password, email,role));
        //}

        //לסדרררררררררררר
        //[Route("GetSerilazeToXML")]
        //public string GetSerilazeToXML()
        //{
        //    return StudentBL.takeDB();


        //סיסמת תלמידה
        //[Route("GetCheckStudentPassword/{password}")]
        //public bool GetCheckStudentPassword(string password)
        //{
        //    return StudentBL.CheckStudentPassword(password);
        //}
    }
}
