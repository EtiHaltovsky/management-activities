﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SchoolDBEntities : DbContext
    {
        public SchoolDBEntities()
            : base("name=SchoolDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Camp> Camps { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<ShabessCamp> ShabessCamps { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentToActivity> StudentToActivities { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeachersToActivity> TeachersToActivities { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }
}