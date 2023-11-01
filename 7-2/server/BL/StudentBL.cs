using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL
{
   public class StudentBL
    {
        public static int AddUser(DTO.Student student)
        {
            DAL.Student sDAL = DTO.Student.ConvertUserToDAL(student);
            return StudentDAL.Add(sDAL);
            //if (student.Password.Length <= 4)
            //{
            //    return -1;
            //}
            //התחברות לדאטה בייס שנמצא בדאל
            //DAL.Student sDAL = DTO.Student.ConvertUserToDAL(student);
            //  DAL.DB.Student.Add(sDAL);

            //return DAL.DB.Student.Count;
            //return 1;
        }

        //צריך לסדר...................................
        //public static int AddStudenToTrip(DTO.Student student)
        //{

        //    //התחברות לדאטה בייס שנמצא בדאל
        //    DAL.Student sDAL = DTO.Student.ConvertUserToDAL(student);
        //    return StudentDAL.AddStudensToTrip(sDAL);

        //    // DAL.DB.Student.Add(sDAL);

        //    return DAL.DB.Student.Count;
        //}


        //סיסמת תלמידה
        //public static bool CheckStudentPassword(string password)
        //{
        //    //DAL.Student sDAL = DTO.Student.ConvertUserToDAL(password);
        //    return StudentDAL.CheckStudentPassword(password);

        //    //DAL.StudentDAL s = DAL.DB.Student.Find(s1 => s1.Id == password);
        //    //if(s==null)
        //    //    return false;
        //    //else
        //    //{
        //    //    return true;
        //    //}
        //}

        //לסיים פונקציההה
        //public static bool CheckClassOfStudent(string classNum)
        //{
        //    //DAL.Student sDAL = DTO.Student.ConvertUserToDAL(classNum);
        //    //return StudentDAL.CheckClassOfStudent(classNum);


        //    //DAL.StudentDAL s = DAL.DB.Student.Find(s1 => s1.ClassNum == "d");
        //    //if (s == null)
        //    //    return false;
        //    //else
        //    //{
        //    //    return true;
        //    //}

        //    //}

        //    ////     לבדוק שינויים..................

        //קבלת כל התלמידות
        public static List<DTO.Student> GetUsers()
        {
            List<DAL.Student> allStudentsDal = StudentDAL.GetAllStudents();
            List<DTO.Student> allStudents = new List<DTO.Student>();
            foreach(DAL.Student s in allStudentsDal)
            {
               
                allStudents.Add(DTO.Student.ConvertUserToDTO(s,s.Person));
            }
            return allStudents;

        }

        //בחירת פעילות לתלמידה
        public static int ChooseActivities(string studentId, int activitiesId)
        {
            DAL.StudentDAL.ChooseActivitiesToStudent(studentId, activitiesId);
            //ActivitiesDAL.ChooseActivitiesToTeacher(changeDAL);
            return ActivitiesDAL.ChooseActivitiesToStudent(studentId, activitiesId);

        }


        //לשליפת תלמידה לפי תעודת זהות
        //public static List<DTO.Student> GetUserById(string id)
        //{
        //    List<DAL.Student> students = StudentDAL.GetUserId(id);
        //    List<DTO.Student> student = new List<DTO.Student>();
        //    foreach (DAL.Student c in students)
        //        student.Add(DTO.Student.ConvertUserToDTO(c));
        //    return student;
        //}

        public static DTO.Student GetUserById(string id)
        {
            DAL.Student student = StudentDAL.GetUserId(id);
            student.Person = StudentDAL.GetUserPersonId(id);
            if (student != null)
                return DTO.Student.ConvertUserToDTO(student,student.Person);
            return null;
        }

        public static int GetDeleteStudent(string id)
        {
           
            return StudentDAL.DeleteStudent(id);
        }


        //public static DTO.Student GetUser(string id)
        //{
        //    DAL.Student b = DAL.StudentDAL.GetStudent(id);
        //    DTO.Student sDTO = DTO.Student.ConvertUserToDTO(b);

        //    //dto ל dal המרת נתונים מה

        //    //b.Person.FirstName = firstName;
        //    return DTO.Student.ConvertUserToDTO(DAL.StudentDAL.GetStudent(id));

        //}

        //עדכון פרטי תלמידה
        public static int UpdateStudentDetails(DTO.Student student)
        {
            DAL.Student changeDAL = DTO.Student.ConvertUserToDAL(student);
            return StudentDAL.Update(changeDAL);

            //send to dal and return index;

        }

        //public static int DeleteStudentDetails(Student student)
        //{


        //}


        //לבדוקקקקקקק................
        //public static string takeDB()
        //{
        //    SerilazeToXML(DAL.DB.Student);
        //    return "good!!!";

        //}

        public static void DeserilazeFromXML()
          {
            

            const string PATH = "E:\\שנה ב\\המורה לירז פרץ\\server\\DAL\\xmlFiles\\students.xml";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<DAL.StudentDAL>));

            List<DAL.StudentDAL> newListOfUsers = new List<DAL.StudentDAL>();
           
            using (StreamReader reader = new StreamReader(PATH))
            {
                newListOfUsers = (List<DAL.StudentDAL>)xmlSerializer.Deserialize(reader);
               
            }
        }


        public static void SerilazeToXML(List<StudentDAL> allUsers)
        {

            const string PATH = "E:\\שנה ב\\המורה לירז פרץ\\server\\DAL\\xmlFiles\\students.xml";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<StudentDAL>));

            using (StreamWriter writer = File.AppendText(PATH))
            {
                xmlSerializer.Serialize(writer, allUsers);
            }
        }
    }
}

