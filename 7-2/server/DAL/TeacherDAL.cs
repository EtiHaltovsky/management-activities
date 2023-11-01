using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class TeacherDAL
    {
       

        //בחירת פעילויות למורה
        public static void ChooseActivitiesToTeacher(string teacherId, int activitiesId)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                db.TeachersToActivities.Add(new TeachersToActivity() { ActivitiesId = activitiesId, TeacherId = teacherId });
                db.SaveChanges();
            }

        }
        //עובד
        //להוספת מורה חדשה
        public static int Add(DAL.Teacher teacher)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                Teacher teacher1 = db.Teachers.Where(t => t.Id == teacher.Id).FirstOrDefault();
                if(teacher1==null)
                {
                    db.People.Add(teacher.Person);
                    teacher.Id = teacher.Person.PersonId;
                    db.Teachers.Add(teacher);
                    db.SaveChanges();

                    return db.Teachers.Count();
                }
                return -1;
            }

        }
        
        //עדכון פרטי מורה
        public static int Update(DAL.Teacher teacher)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                bool flag = false;
                foreach (DAL.Teacher teacher1 in db.Teachers.Include("Person"))
                {
                    if (teacher1.Id.Equals(teacher.Id))
                    {
                        flag = true;
                        teacher1.Id = teacher.Id;
                        teacher1.Educator = teacher.Educator;
                        teacher1.Person.Role = teacher.Person.Role;
                        teacher1.Person.Address = teacher.Person.Address;
                        teacher1.Person.Email = teacher.Person.Email;
                        teacher1.Person.FirstName = teacher.Person.FirstName;
                        teacher1.Person.LastName = teacher.Person.LastName;
                        teacher1.Person.password = teacher.Person.password;
                        teacher1.Person.Phone = teacher.Person.Phone;
                    }
                }
                if (!flag)
                    Add(teacher);
                db.SaveChanges();
                return 1;
            }
        }

        //סיסמת מורה
        public static Teacher CheckTeacherPassword(string password)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                Teacher t = db.Teachers.Include("Person").Where(i => i.Person.password == password).FirstOrDefault();
                return t;
               
                //db.SaveChanges();
                //DB.Students.Add(s);
                //return DB.Students.ToList().Count;
            }
        }

        //עובד
        //מחיקת מורה
        public static int DeleteTeacher(string id)
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                DAL.Person p1 = DB.People.First(c1 => c1.PersonId == id);
                if (p1 != null)
                {
                    DAL.TeachersToActivity teacher = DB.TeachersToActivities.FirstOrDefault(s => s.TeacherId == id);
                    if (teacher != null)
                    {
                        return 2;
                    }
                    DB.People.Remove(p1);
                    DB.Teachers.Remove(DB.Teachers.First(c1 => c1.Id == id));
                    DB.SaveChanges();
                    //DB.People.Remove(DB.People.Where(c1 => c1.PersonId == id).FirstOrDefault());

                    Teacher t = DB.Teachers.Where(t1 => t1.Id == id).FirstOrDefault();
                    Person p = DB.People.Where(c1 => c1.PersonId == id).FirstOrDefault();
                    if (p == null && t == null)
                        return 1;
                }
                return 0;
            }
        }


        public static int DeleteTeacherFromActivity(int idActivity,string teacherId)
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                DAL.TeachersToActivity p1 = DB.TeachersToActivities.First(c1 => c1.ActivitiesId == idActivity);
                if (p1 != null)
                {
                  
                    DB.TeachersToActivities.Remove(p1);
                    
                    DB.SaveChanges();
                    //DB.People.Remove(DB.People.Where(c1 => c1.PersonId == id).FirstOrDefault());

                        return 1;
                }
                return 0;
            }
        }



        //לשליפת מורה לפי תעודת זהות
        public static DAL.Teacher TeacherById(string id)
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                return DB.Teachers.Where(s => s.Id == id).FirstOrDefault();
            }
        }
        public static DAL.Person GetUserPersonId(string id)
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                foreach (DAL.Person p in DB.People)
                    if (p.PersonId.Equals(id))
                    {
                        return p;
                    }
            }
            return null;
        }

        public static DAL.Person getPerson(string id)
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                return DB.People.Where(i => i.PersonId.Equals(id)).FirstOrDefault();
            }
        }

            //קבלת כל המורות
        public static List<DAL.Teacher> GetAllTeachers()
        {
            List<DAL.Teacher> teacher = new List<DAL.Teacher>();
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                foreach (DAL.Teacher c in DB.Teachers)
                {
                    c.Person = getPerson(c.Id);
                    teacher.Add(c);
                }
            }
            return teacher;
        }

    }
}
