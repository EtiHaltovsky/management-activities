using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManagerDAL 
    {
        //עובד
        // בודקת סיסמת מנהל
        //public static Teacher CheckManagerPassword(string password)
        //{
        //    using (SchoolDBEntities DB = new SchoolDBEntities())
        //    {
        //        Teacher t = DB.Teachers.Include("Person").Where(i => i.Person.password == password).FirstOrDefault();
        //        return t;
        //        //DB.Students.Add(s);
        //        //return DB.Students.ToList().Count;
        //    }
        //}

        //בדיקה אם זה מנהל או מורה
        public static bool CheckTeacherOrManager(string id)
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                Teacher t = DB.Teachers.Where(i => i.Person.Teacher.Id == id).FirstOrDefault();
               
                if (t != null&& t.Educator)
                    return true;
                else
                    return false;
            }
        }
        //מחיקת מנהל
        //public static int DeleteManager(string id)
        //{
        //    using (SchoolDBEntities DB = new SchoolDBEntities())
        //    {
        //        DB.People.Remove(DB.People.First(c1 => c1.PersonId == id));
        //        DB.Teachers.Remove(DB.Teachers.First(c1 => c1.Id == id));
        //        DB.SaveChanges();
        //        //DB.People.Remove(DB.People.Where(c1 => c1.PersonId == id).FirstOrDefault());

        //        Teacher c = DB.Teachers.Where(c1 => c1.Id == id).FirstOrDefault();
        //        Person p = DB.People.Where(c1 => c1.PersonId == id).FirstOrDefault();
        //        if (p == null && c == null)
        //            return 1;
        //        return 0;
        //    }
        //}


    }
}
