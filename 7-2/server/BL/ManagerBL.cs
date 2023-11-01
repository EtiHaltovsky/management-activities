using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BL
{
    public class ManagerBL
    {
        //בדיקת סיסמא מנהל
        //public static DTO.Teacher CheckManagerPassword(string password)
        //{
        //    DAL.Teacher m = TeacherDAL.CheckTeacherPassword(password);
        //    return DTO.Teacher.ConvertTeacherToDTO(m, m.Person);
        //    //DAL.ManagerDAL m = DAL.DB.Manager.Find(m1 => m1.Password == password);
        //    //if (m == null)
        //    //    return false;
        //    //else
        //    //{
        //    //    return true;
        //    //}
        //}
       

        ////מחיקת מנהל
        //public static int GetDeleteManager(string id)
        //{

        //    return ManagerDAL.DeleteManager(id);
        //}

        //בדיקה אם זה מנהל או מורה
        public static bool CheckTeacherOrManager(string id)
        {
            return ManagerDAL.CheckTeacherOrManager(id);
        }
            //public static int ChangeDetailsMale(Matchmaker matchmaker)
            //{
            //    MatchmakerDAL changeMathDAL = DTO.Matchmaker.ConvertUserToDAL(matchmaker);
            //    int index = DB.Males.FindIndex(i => i.Id == matchmaker.Id);
            //    if (index == -1)
            //        return -1;

            //    DB.Matchmakers[index] = changeMathDAL;
            //    return index;



            //}



        }
}
