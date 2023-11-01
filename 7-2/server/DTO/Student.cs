using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   
    public class Student : Person
    {
        public double Age { get; set; }
        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public bool Sister { get; set; }

        public string ClassNum { get; set; }

        private string pharm;

            public string Pharm
            {
                get { return pharm; }
                set
                {
                    if (value == "מכבי" || value == "מאוחדת" || value == "לאומית" || value == "כללית")
                        pharm = value;
                }
            }


        //public static StudentDAL ConvertUserToDAL(Student student)
        //{
        //    throw new NotImplementedException();
        //}

        public Student(string id, string firstName, string lastName, string fatherName, string motherName,bool sister,
                string phone, string address, double age, string classNum, string pharm, string email, string password,string role)
                : base(id, firstName, lastName, phone, address, email, password,role)
            {

                FatherName = fatherName;
                MotherName = motherName;
                Sister = sister;
                Pharm = pharm;
                Age = age;
                ClassNum = classNum;
        }
        public Student():base()
        {
            
        }


        //public static Student ConvertUserToDTO(StudentDAL studentDAL)
        //{
        //    throw new NotImplementedException();
        //}

        //public static DTO.Student ConvertUserToDTO(DAL.Student student)
        //{

        //    return new DTO.Student()
        //    {

        //        Pharm = student.Pharm,
        //        FatherName = student.FatherName,
        //        MotherName = student.MotherName,
        //        Sister = student.Sister,
        //        Age = student.Age,
        //        ClassNum = student.ClassNum,
        //        Password = student.Person.password,
        //        Address = student.Person.Address,
        //        Email = student.Person.Email,
        //        FirstName = student.Person.FirstName,
        //        LastName = student.Person.LastName,
        //        pharm = student.Person.LastName,
        //        Phone = student.Person.LastName
        //    };

        //}

        public static DTO.Student ConvertUserToDTO(DAL.Student student, DAL.Person p)
        {

            return new DTO.Student()
            {
                Id=student.Id,
                Pharm = student.Pharm,
                FatherName = student.FatherName,
                MotherName = student.MotherName,
                Sister = student.Sister,
                Age = student.Age,
                ClassNum = student.ClassNum,
                Password = p.password,
                Address = p.Address,
                Email = p.Email,
                FirstName = p.FirstName,
                LastName = p.LastName,
                //pharm = p.LastName,
                Phone=p.Phone,
                Role=p.Role
            };

        }





        public static DAL.Student ConvertUserToDAL(Student student)
        {
            DAL.Person user = new DAL.Person()
            {
                Address = student.Address,
                PersonId = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                password = student.Password, 
                Phone=student.Phone,
                Role = student.Role

            };


            DAL.Student student1 = new DAL.Student()
            {
                Id = user.PersonId,

                Pharm = student.Pharm,
                FatherName = student.FatherName,
                MotherName = student.MotherName,
                Sister = student.Sister,
               // Age = (int)(student.Age),
                Age = student.Age,
                ClassNum = student.ClassNum,
                Person = user
            };

            return student1;
        }



        //public static StudentDAL ConvertUserToDAL(Student student)
        //{
        //    return new StudentDAL()
        //    {
        //        Address = student.Address,
        //        Id = student.Id,
        //        FirstName = student.FirstName,
        //        LastName = student.LastName,
        //        FatherName = student.FatherName,
        //        MotherName = student.MotherName,
        //        Sister = student.Sister,
        //        Age = student.Age,
        //        ClassNum = student.ClassNum,
        //        Email = student.Email,
        //        Phone = student.Phone,
        //        Password = student.Password,
        //        Pharm = student.Pharm
        //    };

        //}



        //public static Student ConvertUserToDTO(StudentDAL student)
        //{
        //    return new Student()
        //    {
        //        Address = student.Address,
        //        Id = student.Id,
        //        FirstName = student.FirstName,
        //        LastName = student.LastName,
        //        FatherName=student.FatherName,
        //        MotherName=student.MotherName,
        //        Sister=student.Sister,
        //        Age = student.Age,
        //        ClassNum=student.ClassNum,
        //        Email = student.Email,
        //        Phone = student.Phone,
        //        Password = student.Password,
        //        Pharm = student.Pharm
        //    };


        //}

        //public static int ChangeActivitiesDetails(Activities activities)
        //{
        //    ActivitiesDAL changeActDAL = Activities.ConvertActivitiesToDAL(activities);
        //    int index=DB.Activity.FindIndex(u => u.Id == activities.Id);
        //    if (index == -1)
        //        return -1;
        //     DB.Activity[index] == changeActDAL.ActivitiesDate;
        //    return index;
        //}
      
    }
    //public Students(string id, string firstName, string lastName, string phone, string password)
    //{
    //    Id = id;
    //    FirstName = firstName;
    //    LastName = lastName;
    //    Phone = phone;
    //    Password = password;
    //}

    //public Students(string id, string firstName, string lastName, string phone, string address) : base(id, firstName, lastName, phone, address)
    //{
    //}
    //פונקציות השוואה והדפסת מחרוזת
    //public override bool Equals(object obj)
    //{

    //    return base.Equals(obj);
    //}

    //public override string ToString()
    //{

    //    return this.Id + ": " + this.LastName + " " + this.FirstName;
    //}






    //convert
    //==> dal

    //public static Student ConvertUserToDAL(Student student)
    //{
    //    return new UserDAL()
    //    {

    //    };
    //}


    //convert dal ==>dto


    //convert
    //dto==> dal

    //public static UserDAL ConvertUserToDAL(User user)
    //{
    //    return new UserDAL()
    //    {
    //        MyAge = user.Age,
    //        Name = user.UserName,
    //        Pass = user.Password
    //    };
    //}








    //convert dal ==>dto
    //public static User ConvertUserToDTO(UserDAL user)
    //{
    //    return new User()
    //    {
    //        Age = user.MyAge,
    //        UserName = user.Name,
    //        Password = user.Pass
    //    };
    //}
}

    



