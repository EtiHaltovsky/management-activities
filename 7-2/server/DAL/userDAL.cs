using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public class userDAL
  {
        //עובד
        //בדיקת סיסמת משתמש
        public static DAL.Person CheckUserPassword(string id,string password)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {

              DAL.Person p = db.People.Where(i => i.password == password&&i.PersonId==id).FirstOrDefault();
                if (p == null)
                    return null;
                return p;

                //db.SaveChanges();
                //DB.Students.Add(s);
                //return DB.Students.ToList().Count;
            }

        }
        //זיהוי המשתמש לפי ת.ז.
        public static int CheckPersonById(string id)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                Person p = db.People.Where(c1 => c1.PersonId == id).FirstOrDefault();
                if (p == null)
                    return -1;
                Teacher t = db.Teachers.Where(c1 => c1.Id == p.PersonId).FirstOrDefault();
                Student s = db.Students.Where(p1 => p1.Id == p.PersonId).FirstOrDefault();
                if (t == null && s != null)
                    return 1;
                else
                    return 2;
                    
            }
        }

  }
}

