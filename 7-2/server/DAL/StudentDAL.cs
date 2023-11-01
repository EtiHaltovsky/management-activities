using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentDAL
    {
        public static void AddActivityToPerson(string studentId, int activitiesId)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                db.StudentToActivities.Add(new StudentToActivity() { ActivitiesId = activitiesId, StudentId = studentId });
            }

        }
        //שליפה של התלמידות שנרשמו לפעילות מסוימת-מחנה טיול או שבת מחנה
        public static List<Student> GetStudentsOfActivity(int idActivities)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
              return  db.Students.Where(s => s.StudentToActivities.Any(a => a.ActivitiesId == idActivities)).ToList();
            }
        }

        //להוספת תלמידה חדשה
        public static int Add(DAL.Student student)
        {
            //DAL.Student sDAL = DTO.Student.ConvertUserToDAL(student);
            //  DAL.DB.Student.Add(sDAL);
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                Student s1 = db.Students.Where(s => s.Id == student.Id).FirstOrDefault();
                if (s1 == null)
                {
                    db.People.Add(student.Person);
                    //student.Id = student.Person.PersonId;
                    db.Students.Add(student);
                    db.SaveChanges();

                    return db.Students.Count();
                }
                return -1;
            }

        }

        //עדכון פרטי תלמידה
        public static int Update(DAL.Student student)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                bool flag = false;
                foreach (DAL.Student student1 in db.Students.Include("Person"))
                {
                    if (student1.Id.Equals(student.Id))
                    {
                        flag = true;
                        student1.Id = student.Id;
                        student1.MotherName = student.MotherName;
                        student1.Pharm = student.Pharm;
                        student1.Sister = student.Sister;
                        student1.Age = student.Age;
                        student1.ClassNum = student.ClassNum;
                        student1.FatherName = student.FatherName;
                        student1.Person.Address = student.Person.Address;
                        student1.Person.Email = student.Person.Email;
                        student1.Person.FirstName = student.Person.FirstName;
                        student1.Person.LastName = student.Person.LastName;
                        student1.Person.password = student.Person.password;
                        student1.Person.Phone = student.Person.Phone;


                    }

                }
                if (!flag)
                    Add(student);
                db.SaveChanges();
                //db.Students.Where(c => c.Id == student.Id) = student;
                //db.Students.(student);
                return 1;
            }
        }

        //מחיקת תלמידה
        public static int DeleteStudent(string id)
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                DAL.Person p = DB.People.First(c1 => c1.PersonId == id);
                if (p != null){
                DAL.StudentToActivity student = DB.StudentToActivities.FirstOrDefault(s=> s.StudentId == id);
                if (student != null)
                {
                    return 2;
                }
               
                DB.People.Remove(p);
                DB.Students.Remove(DB.Students.First(c1 => c1.Id == id));
                DB.SaveChanges();
                //DB.People.Remove(DB.People.Where(c1 => c1.PersonId == id).FirstOrDefault());

                Student c = DB.Students.Where(c1 => c1.Id == id).FirstOrDefault();
                Person p1 = DB.People.Where(c1 => c1.PersonId == id).FirstOrDefault();
                if (p1 == null && c == null)
                    return 1;}
                return 0;
            }
        }


        public static DAL.Student GetStudent(string id)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {

                DAL.Student a = db.Students.First(t => t.Id == id);
                return a;
            }
        }

        //הוספת תלמידה לטיול
        //public static int AddStudensToTrip(DAL.Student student)
        //{
        //    using (SchoolDBEntities db = new SchoolDBEntities())
        //    {
        //        StudentToActivity s1 = db.StudentToActivities.Where(s => s.StudentId == student.Id).FirstOrDefault();
        //        if (s1 == null)
        //        {
        //            db.People.Add(student.Person);
        //            //student.Id = student.Person.PersonId;
        //            db.StudentToActivities.Add(student);
        //            db.SaveChanges();

        //            return db.StudentToActivities.Count();
        //        }
        //        return -1;
        //    }
        //}


       

        //מיון תלמידות לפי קופת חולים
        public static List<Student> GetStudentsPharm()
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                DB.Students.Add(new Student());

                List<Student> allStudents = DB.Students.Where(c => c.Pharm == "macabi").ToList();

                return allStudents;
            }
        }


        //public static int addStudent(Student s)
        //{
        //    using (SchoolDBEntities DB = new SchoolDBEntities())
        //    {
        //        DB.Students.Select(i => i.Id == s.Id);

        //        DB.Students.Add(s);
        //        return DB.Students.ToList().Count;
        //    }
        //}

        public static List<Student> accountStudentByClass()
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                DB.Students.Add(new Student());

                List<Student> allStudents = DB.Students.Where(c => c.ClassNum == "d").ToList();

                return allStudents;
            }
        }

      
        //קבלת כל התלמידות
        public static DAL.Person getPerson(string id)
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                return DB.People.Where(i => i.PersonId.Equals(id)).FirstOrDefault();
            }
        }
        public static List<DAL.Student> GetAllStudents()
        {
            List<DAL.Student> student = new List<DAL.Student>();
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                foreach (DAL.Student c in DB.Students)
                {
                    c.Person = getPerson(c.Id);
                    student.Add(c);
                }


            }
            return student;
        }

        //בחירת פעילות לתלמידה
        public static void ChooseActivitiesToStudent(string studentId, int activitiesId)
        {
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                db.StudentToActivities.Add(new StudentToActivity() { ActivitiesId = activitiesId, StudentId = studentId });
                db.SaveChanges();
            }

        }
       
        public static DAL.Student GetUserId(string id)
        {
            using (SchoolDBEntities DB = new SchoolDBEntities())
            {
                return DB.Students.Include("Person").Where(s => s.Id == id).FirstOrDefault();
                //foreach (DAL.Student c in DB.Students)
                //    if (c.Id.Equals(id))
                //    {
                //                return c;
                //    }
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

    }

    //סיסמת תלמידה
    //public static bool CheckStudentPassword(string password)
    //{
    //    using (SchoolDBEntities db = new SchoolDBEntities())
    //    {
    //      Student s= db.Students.Where(i => i.Person.password == password).FirstOrDefault();

    //        if (s != null)
    //            return true;
    //        else
    //            return false;
    //        //DB.Students.Add(s);
    //        //return DB.Students.ToList().Count;
    //    }
    //}

    //שליפת תלמידה לפי id
    //public static List<DAL.Student> GetUserId(string id)
    //{
    //    List<DAL.Student> student = new List<DAL.Student>();y
    //    using (SchoolDBEntities DB = new SchoolDBEntities())
    //    {
    //        foreach (DAL.Student c in DB.Students)
    //            if (c.Id.Equals(id))
    //            {
    //                student.Add(c);
    //            }
    //    }
    //    return student;
    //}

}



