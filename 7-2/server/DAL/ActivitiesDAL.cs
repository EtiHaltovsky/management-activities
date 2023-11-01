using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ActivitiesDAL
    {
        //הוספת פעילות
        public static int AddNewActivities(DAL.Activity activities)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                Activity a = db.Activities.Where(ac => ac.ActivitiesName == activities.ActivitiesName).FirstOrDefault();
                if(a==null)
                {
                    activities.ActivityId = db.Activities.Count() + 2;
                    //db.Activities.Add(new Activity());
                    db.Activities.Add(activities);
                    db.SaveChanges();
                    return db.Activities.Count();
                }
                return -1;
            }
        }


        public static int CheckActivityById(int id)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                Activity p = db.Activities.Where(c1 => c1.ActivityId == id).FirstOrDefault();
                if (p == null)
                    return -1;
                    return 1;
              
            }
        }
        public static DAL.Activity GetActivity(int id)
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                foreach (DAL.Activity p in DB.Activities)
                    if (p.ActivityId.Equals(id))
                    {
                        return p;
                    }
            }
            return null;
        }
        //עדכון פעילות
        public static bool UpdateActivities(DAL.Activity activities)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {

                DAL.Activity activity = db.Activities.Where(a => a.ActivityId == activities.ActivityId).FirstOrDefault();
                if (activity.ActivityId == null)
                    return false;
                activity.ActivitiesName = activities.ActivitiesName;
                activity.ActivitiesDate = activities.ActivitiesDate;
                activity.ActivitiesPlace = activities.ActivitiesPlace;
                activity.Price = activities.Price;
          
                db.SaveChanges();
                return true;

            }

        }

        //מחיקת פעילות
        public static int DeleteActivity(int name)
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                Activity a1 = DB.Activities.FirstOrDefault(c1 => c1.ActivityId == name);
                if (a1 != null) {
                    TeachersToActivity t = DB.TeachersToActivities.FirstOrDefault(a => a.ActivitiesId == a1.ActivityId);
                    if (t != null)
                        return 2;
                    StudentToActivity s = DB.StudentToActivities.FirstOrDefault(a => a.ActivitiesId == a1.ActivityId);
                    if (s != null)
                        return 3;
                    DB.Activities.Remove(a1);
                DB.SaveChanges();
                //DB.People.Remove(DB.People.Where(c1 => c1.PersonId == id).FirstOrDefault());

                Activity c = DB.Activities.Where(c1 => c1.ActivityId == name).FirstOrDefault();
               
                if (c == null)
                    return 1;}
                return 0;
            }
        }

        //שליפת כל הפעילויות
        public static List<DAL.Activity> GetAllActivities()
        {
            List<DAL.Activity> activities = new List<DAL.Activity>();
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                foreach (DAL.Activity a in DB.Activities)

                    activities.Add(a);

            }
            return activities;
        }

        //שליפת פעילויות לפי תלמידה
        public static int SelectTheActivities(string studentId, int ActivityId)
        {
            DAL.StudentToActivity s = new StudentToActivity();
            s.StudentId = studentId;
            s.ActivitiesId = ActivityId;
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                db.StudentToActivities.Add(s);
                return 1;                 
            }
        }

        //בחירת פעילות למורה
        public static int ChooseActivitiesToTeacher(string teacherId, int ActivityId)
        {
            DAL.TeachersToActivity t = new TeachersToActivity();
            t.TeacherId = teacherId;
            t.ActivitiesId = ActivityId;
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                db.TeachersToActivities.Add(t);
                //DB.Activity.FindIndex(u => u.Id == activities.Id);
                return 1;
            }

        }

        //בחירת פעילות לתלמידה
        public static int ChooseActivitiesToStudent(string studentId, int ActivityId)
        {
            DAL.StudentToActivity t = new StudentToActivity();
            t.StudentId = studentId;
            t.ActivitiesId = ActivityId;
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                db.StudentToActivities.Add(t);
                return 1;
            }

        }

        //החזרת טיול
        public static DAL.Trip GetTrip(int year)
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                return DB.Trips.Where(s => s.Year == year).FirstOrDefault();
            }
        }

        //הוספת תלמידה לטיול
        public static int ChooseTrip(string studentId, int tripId)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                DAL.Trip trip = db.Trips.Where(i => i.Year == tripId).FirstOrDefault();
                //DAL.Activity activity = db.Activities.Where(i => i.ActivityId == tripId).FirstOrDefault();
                db.StudentToActivities.Add(new StudentToActivity() { StudentId = studentId, ActivitiesId = trip.TripId });
                db.SaveChanges();
                return 1;
            }

        }

        //החזרת מחנה
        public static DAL.Camp GetCamp(int year)
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                return DB.Camps.Where(s => s.Year == year).FirstOrDefault();
            }
        }

        //הוספת תלמידה למחנה
        public static int ChooseCamp(string studentId, int campId)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                DAL.Camp camp = db.Camps.Where(i => i.Year == campId).FirstOrDefault();

                db.StudentToActivities.Add(new StudentToActivity() { StudentId = studentId, ActivitiesId = camp.CampId });
                db.SaveChanges();
                return 1;
            }

        }

        //החזרת שבת מחנה
        public static DAL.ShabessCamp GetShabbatCamp(int year)
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                return DB.ShabessCamps.Where(s => s.Year == year).FirstOrDefault();
            
            }
        }

        //הוספת תלמידה לשבת מחנה
        public static int ChooseShabbatCamp(string studentId, int shabbatId)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                DAL.ShabessCamp shabess = db.ShabessCamps.Where(i => i.Year == shabbatId).FirstOrDefault();
                db.StudentToActivities.Add(new StudentToActivity() { StudentId = studentId, ActivitiesId = shabess.shabbesCampId });
                db.SaveChanges();
                return 1;
            }

        }
    }
}



  
