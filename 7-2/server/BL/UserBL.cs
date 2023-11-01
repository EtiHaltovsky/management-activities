using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BL
{
  public class userBL
    {
        //עובד
        //בדיקת סיסמת משתמש
        public static DTO.Person CheckUserPassword(string id, string password)
        {
            DAL.Person p = userDAL.CheckUserPassword(id,password);
            if (p == null)
                return null;
            return DTO.Person.ConvertPersonToDTO(p);
        }

        //זיהוי המשתמש לפי ת.ז.
        public static int CheckPersonById(string id)
        {
            return userDAL.CheckPersonById(id);
        }
       
    }
}
