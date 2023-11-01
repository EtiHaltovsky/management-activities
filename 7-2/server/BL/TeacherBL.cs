using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL
{
    public class TeacherBL
    {

        //בחירת פעילות למורה
        public static int ChooseActivities(string teacherId, int activitiesId)
        {
            DAL.TeacherDAL.ChooseActivitiesToTeacher(teacherId, activitiesId);
            //ActivitiesDAL.ChooseActivitiesToTeacher(changeDAL);
            return ActivitiesDAL.ChooseActivitiesToTeacher(teacherId, activitiesId);

        }

        //עובד
        //להוספת מורה חדשה
        public static int AddTeacher(DTO.Teacher teacher)
        {
            DAL.Teacher sDAL = DTO.Teacher.ConvertTeacherToDAL(teacher);
            return TeacherDAL.Add(sDAL);
       
        }

        //עדכון פרטי מורה
        public static int UpdateTeacherDetails(DTO.Teacher teacher)
        {
            DAL.Teacher changeDAL = DTO.Teacher.ConvertTeacherToDAL(teacher);
            return TeacherDAL.Update(changeDAL);

            //send to dal and return index;

        }

        //סיסמת מורה
        public static DTO.Teacher CheckTeacherPassword(string password)
        {
            //DAL.Student sDAL = DTO.Student.ConvertUserToDAL(password);
            DAL.Teacher t = TeacherDAL.CheckTeacherPassword(password);
            DTO.Teacher t1= DTO.Teacher.ConvertTeacherToDTO(t, t.Person);
            return t1;
        }

        //מחיקת מורה
        public static int GetDeleteTeacher(string id)
        {

            return TeacherDAL.DeleteTeacher(id);
        }

        public static int GetDeleteTeacherFromActivity(int idActivity,string teacherId)
        {

            return TeacherDAL.DeleteTeacherFromActivity(idActivity, teacherId);
        }


        //לשליפת מורה לפי תעודת זהות
        public static DTO.Teacher GetTeacherById(string id)
        {
            DAL.Teacher teacher = TeacherDAL.TeacherById(id);
            teacher.Person = TeacherDAL.GetUserPersonId(id);
            if (teacher != null)
                return DTO.Teacher.ConvertTeacherToDTO(teacher, teacher.Person);
            return null;
        }

        //קבלת כל המורות
        public static List<DTO.Teacher> GetTeachers()
        {
            List<DAL.Teacher> allTeachersDal = TeacherDAL.GetAllTeachers();
            List<DTO.Teacher> allTeachers = new List<DTO.Teacher>();
            foreach (DAL.Teacher s in allTeachersDal)
            {

                allTeachers.Add(DTO.Teacher.ConvertTeacherToDTO(s, s.Person));
            }
            return allTeachers;

        }

    }

   

}
