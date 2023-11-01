using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public class Activities
    {
        public int Id { get; set; }
        public string ActivitiesName { get; set; }
        public string ActivitiesPlace { get; set; }
        public DateTime ActivitiesDate;
        public double Price { get; set; }

        public Activities(int id, string activitiesName, string activitiesPlace, DateTime activitiesDate, double price)
        {
            Id = id;
            ActivitiesName = activitiesName;
            ActivitiesPlace = activitiesPlace;
            ActivitiesDate = activitiesDate;
            Price = price;
        }

        public Activities(string activitiesName, string activitiesPlace, DateTime activitiesDate, double price)
        {
           
            ActivitiesName = activitiesName;
            ActivitiesPlace = activitiesPlace;
            ActivitiesDate = activitiesDate;
            Price = price;
        }
        public Activities()
        { }

        //public DateTime ActivitiesDate
        //{
        //    get { return activitiesDate; }
        //    set
        //    {
        //        if (value.Year < DateTime.Now.Year)
        //            activitiesDate = value;
        //    }
        //}

       


        public static DAL.Activity ConvertActivitiesToDAL(DTO.Activities activities)
        {
            return new DAL.Activity()
            {

                ActivityId = activities.Id,
                ActivitiesDate = activities.ActivitiesDate,
                ActivitiesName = activities.ActivitiesName,
                ActivitiesPlace = activities.ActivitiesPlace,
                Price = activities.Price
               
            };
        }

        public static DTO.Activities ConvertActivitiesToDTO(DAL.Activity activities)
        {
            return new DTO.Activities()
            {

                Id = activities.ActivityId,
                ActivitiesName = activities.ActivitiesName,
                ActivitiesPlace = activities.ActivitiesPlace,
                ActivitiesDate = activities.ActivitiesDate,
                Price = (double)activities.Price
            };
        }
    }
}