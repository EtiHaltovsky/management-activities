using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ActivitiesBL
    {

        //הוספת פעילות
        public static int AddNewActivities(Activities activities)
        {
            DAL.Activity aDAL = Activities.ConvertActivitiesToDAL(activities);
            return DAL.ActivitiesDAL.AddNewActivities(aDAL);
            //return DAL.DB.Activity.Count;

        }

        //שליפה של התלמידות שנרשמו לפעילות מסוימת-מחנה טיול או שבת מחנה
        public static List<DTO.Student> GetStudentsOfActivity(int ActivitiesId)
        {
           List< DAL.Student> student = StudentDAL.GetStudentsOfActivity(ActivitiesId);
           
            List<DTO.Student> s = new List<DTO.Student>();
         for (int i = 0; i < student.Count(); i++)
            {
                DAL.Person person = StudentDAL.GetUserPersonId(student[i].Id);
                s.Add(DTO.Student.ConvertUserToDTO(student[i], person));
            }
            return s;

        }

     

        public static int GetCheckActivityById(int id)
        {
            return ActivitiesDAL.CheckActivityById(id);
        }

        

        public static DTO.Activities GetActivities(int id)
        {
            DAL.Activity activity = ActivitiesDAL.GetActivity(id);
            //activity = ActivitiesDAL.GetUserPersonId(id);
            if (activity != null) { 
                DTO.Activities a= DTO.Activities.ConvertActivitiesToDTO(activity);
            return a;}
            return null;
        }
        //עדכון פעילות
        public static bool UpdateActivities(Activities activities)
        {
            DAL.Activity changeDAL = Activities.ConvertActivitiesToDAL(activities);
            return ActivitiesDAL.UpdateActivities(changeDAL);
            //int index = DB.Activity.FindIndex(u => u.Id == activities.Id);
            //if (index == -1)
            //    return -1;
            //DB.Activity[index] = changeDAL;
            //return index;

            //return (DB.Activity.FindIndex(u => u.Password == password) != -1);


            //}
        }
        //מחיקת פעילות
        public static int GetDeleteActivity(int name)
        {

            return ActivitiesDAL.DeleteActivity(name);
        }



        //לסיים פונקציההה
        public static int SelectActivities(string studentId, int activitiesId)
        {

            //ActivitiesDAL changeDAL = Activities.ConvertActivitiesToDAL(Id);
            //StudentDAL change1DAL = Student.ConvertUserToDAL(id);
            //DB.Activity.Add(changeDAL);
            //DB.Student.Add(change1DAL);

            DAL.StudentDAL.AddActivityToPerson(studentId, activitiesId);
            return ActivitiesDAL.SelectTheActivities(studentId, activitiesId);
            //return DAL.DB.Activity.Count;
            //return ActivitiesDAL.
        }

        //שליפת כל הפעילויות
        public static List<DTO.Activities> GetActivities()
        {
            List<DAL.Activity> allActivitiesDal = ActivitiesDAL.GetAllActivities();
            List<DTO.Activities> allActivities = new List<DTO.Activities>();
            foreach (DAL.Activity s in allActivitiesDal)
            {

                allActivities.Add(DTO.Activities.ConvertActivitiesToDTO(s));
            }
            return allActivities;

   
        }
        //החזרת טיול
        public static DTO.Trip GetTrip(int year)
        {

            DAL.Trip trip = ActivitiesDAL.GetTrip(year);
            DTO.Trip trip1 = DTO.Trip.ConvertTripToDTO(trip);
            return trip1;        
        }

        //הוספת תלמידה לטיול
        public static int GetChooseTrip(string studentId, int tripId)
        {
           return DAL.ActivitiesDAL.ChooseTrip(studentId, tripId);
            //ActivitiesDAL.ChooseActivitiesToTeacher(changeDAL);
           

        }
        //החזרת מחנה
        public static DTO.Camp GetCamp(int year)
        {

            DAL.Camp camp = ActivitiesDAL.GetCamp(year);
            DTO.Camp camp1 = DTO.Camp.ConvertCampToDTO(camp);
            return camp1;
        }

        //הוספת תלמידה למחנה
        public static int GetChooseCamp(string studentId, int campId)
        {
            return DAL.ActivitiesDAL.ChooseCamp(studentId, campId);
            //ActivitiesDAL.ChooseActivitiesToTeacher(changeDAL);


        }
        //החזרת שבת מחנה
        public static DTO.ShabbesCamp GetShabbatCamp(int year)
        {

            DAL.ShabessCamp shabess = ActivitiesDAL.GetShabbatCamp(year);
            DTO.ShabbesCamp shabbes1 = DTO.ShabbesCamp.ConvertShabessCampToDTO(shabess);
            return shabbes1;
        }

        //הוספת תלמידה לשבת מחנה
        public static int GetChooseShabbatCamp(string studentId, int shabbatId)
        {
            return DAL.ActivitiesDAL.ChooseShabbatCamp(studentId, shabbatId);
            //ActivitiesDAL.ChooseActivitiesToTeacher(changeDAL);
        }
    }
}
