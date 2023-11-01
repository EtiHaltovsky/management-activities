using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Camp : Activities
    {
        public int CampId { get; set; }
        public int Year { get; set; }

        public Camp(int campId, int year)
        {
            CampId = campId;
            Year = year;
        }
        public Camp()
        {
        }
        public static DAL.Camp ConvertCampToDAL(DTO.Camp camp)
        {
            return new DAL.Camp()
            {
                CampId=camp.CampId,
                Year=camp.Year
            };
        }

        public static DTO.Camp ConvertCampToDTO(DAL.Camp camp)
        {
            return new DTO.Camp()
            {
                CampId = camp.CampId,
                Year = camp.Year
            };
        }

    }


}

