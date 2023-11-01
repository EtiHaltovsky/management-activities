//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DAL;

//namespace DTO
//{
//    class Manager : Person
//    {
//        public Manager()
//        {
//        }

//        public Manager(string id, string firstName, string lastName, string phone, string address, string password, string email) : base(id, firstName, lastName, phone, address, password, email)
//        {
//        }

//        //public static DAL.Teacher ConvertTeacherToDAL(Teacher teacher)
//        //{
//        //    DAL.Person user = new DAL.Person()
//        //    {
//        //        Id= teacher.Id,
//        //        FirstName= teacher.FirstName,
//        //        LastName= teacher.LastName,
//        //        Phone= teacher.Phone,
//        //        Address= teacher.Address,
//        //        Password= teacher.Password,
//        //        Email= teacher.Email
//        //    };
//        //}
//        public static DAL.Student ConvertUserToDAL(Student student)
//        {
//            DAL.Person user = new DAL.Person()
//            {
//                Address = student.Address,
//                PersonId = student.Id,
//                FirstName = student.FirstName,
//                LastName = student.LastName,
//                Email = student.Email,
//                password = student.Password,

//            };


//            DAL.Student student1 = new DAL.Student()
//            {
//                Id = user.Id,

//                Pharm = student.Pharm,
//                FatherName = student.FatherName,
//                MotherName = student.MotherName,
//                Sister = student.Sister,
//                // Age = (int)(student.Age),
//                Age = student.Age,
//                ClassNum = student.ClassNum,
//                Person = user
//            };

//            return student1;
//        }


//    }
//}
//    //public static Teacher ConvertTeacherToDTO(DAL.Teacher teacher)
//    //    {
//    //        return new Teacher()
//    //        {
//    //            Id = teacher.Person.PersonId,
//    //            FirstName = teacher.FirstName,
//    //            LastName = teacher.LastName,
//    //            Phone = teacher.Phone,
//    //            Address = teacher.Address,
//    //            Password = teacher.Password,
//    //            Email = teacher.Email
//    //        };
//    //    }

//        //public Manager(string id, string firstName, string lastName, string phone, string address, string password, string email) : base(id, firstName, lastName, phone, address, password, email)
//        //{
//        //}

//        //public static ManagerDAL ConvertManagerToDAL(Manager manager)
//        //{
//        //    return new ManagerDAL()
//        //    {
//        //        Id = manager.Id,
//        //        FirstName = manager.FirstName,
//        //        LastName = manager.LastName,
//        //        Phone = manager.Phone,
//        //        Address = manager.Address,
//        //        Password = manager.Password,
//        //        Email = manager.Email
//        //    };
//        //}


//        //public static Manager ConvertManagerToDTO(ManagerDAL manager)
//        //{
//        //    return new Manager()
//        //    {
//        //        Id = manager.Id,
//        //        FirstName = manager.FirstName,
//        //        LastName = manager.LastName,
//        //        Phone = manager.Phone,
//        //        Address = manager.Address,
//        //        Password = manager.Password,
//        //        Email = manager.Email
//        //    };
//        //}








      
    

