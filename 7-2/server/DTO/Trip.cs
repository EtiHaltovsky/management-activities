using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Trip : Activities
    {
        public string Guide { get; set; }
        public double DurationOfTheTrip { get; set; }
        public string Sites { get; set; }
        public string Buses { get; set; }
        public int Year { get; set; }

        public Trip(string guide, double durationOfTheTrip, string sites, string buses ,int year)
        {
            Guide = guide;
            DurationOfTheTrip = durationOfTheTrip;
            Sites = sites;
            Buses = buses;
            Year = year;
        }

        public Trip()
        {
        }


        public static DAL.Trip ConvertTripToDAL(DTO.Trip trip)
        {
            return new DAL.Trip()
            {
               Guide=trip.Guide,
                DurationOfTheTrip=trip.DurationOfTheTrip,
                Sites=trip.Sites,
                Buses=trip.Buses,
                Year = trip.Year,
                //Activity.ActivityId = trip.Id
            };
        }

        public static DTO.Trip ConvertTripToDTO(DAL.Trip trip)
        {
            return new DTO.Trip()
            {
                Guide = trip.Guide,
                Id=trip.Activity.ActivityId,
                DurationOfTheTrip = trip.DurationOfTheTrip,
                Sites = trip.Sites,
                Buses = trip.Buses,
                Year = trip.Year
        };
        }
    }
}
