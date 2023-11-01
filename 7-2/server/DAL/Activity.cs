//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Activity
    {
        public Activity()
        {
            this.StudentToActivities = new HashSet<StudentToActivity>();
            this.TeachersToActivities = new HashSet<TeachersToActivity>();
        }
    
        public int ActivityId { get; set; }
        public string ActivitiesName { get; set; }
        public string ActivitiesPlace { get; set; }
        public System.DateTime ActivitiesDate { get; set; }
        public Nullable<double> Price { get; set; }
    
        public virtual Camp Camp { get; set; }
        public virtual ShabessCamp ShabessCamp { get; set; }
        public virtual ICollection<StudentToActivity> StudentToActivities { get; set; }
        public virtual ICollection<TeachersToActivity> TeachersToActivities { get; set; }
        public virtual Trip Trip { get; set; }
    }
}