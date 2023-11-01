using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ShabbesCamp : Activities
    {
        public int ShabbesCampId { get; set; }
        public DateTime TimeOfPrayInBeitKneset { get; set; }

        public string Lecturers { get; set; }
        public int Year { get; set; }

        public ShabbesCamp()
        {
        }

        public static DAL.ShabessCamp ConvertShabessCampToDAL(DTO.ShabbesCamp shabbes)
        {
            return new DAL.ShabessCamp()
            {
                shabbesCampId = shabbes.ShabbesCampId,
                Year = shabbes.Year,
                Lecturers=shabbes.Lecturers,
                TimeOfPrayInBeitKneset=shabbes.TimeOfPrayInBeitKneset
            };
        }

        public static DTO.ShabbesCamp ConvertShabessCampToDTO(DAL.ShabessCamp shabess)
        {
            return new DTO.ShabbesCamp()
            {
                ShabbesCampId=shabess.shabbesCampId,
                Year=shabess.Year,
                Lecturers=shabess.Lecturers,
                TimeOfPrayInBeitKneset=shabess.TimeOfPrayInBeitKneset
            };
        }
    }
}
