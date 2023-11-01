using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Teacher : Person
    {
        public bool educator { get; set; }

        public Teacher(string id, string firstName, string lastName, string phone, string address, string password, bool educator, string email,string role) : base(id, firstName, lastName, phone, address, email, password, role)
        {
            this.educator = educator;
        }
        public Teacher()
        {
            
        }

        public Teacher(string id, string firstName, string lastName, string phone, string address, string password, string email,string role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Address = address;
            Password = password;
            Email = email;
            Role = role;

        }

        public static DTO.Teacher ConvertTeacherToDTO(DAL.Teacher teacher, DAL.Person p)
        {


            return new DTO.Teacher()
            {
                Id =p.PersonId,
                educator = teacher.Educator,
                Password = p.password,
                Address = p.Address,
                Email = p.Email,
                FirstName = p.FirstName,
                LastName = p.LastName,                
                Phone = p.Phone,
                Role=p.Role
            };

        }


        public static DAL.Teacher ConvertTeacherToDAL(Teacher teacher)
        {
            DAL.Person user = new DAL.Person()
            {
                Address = teacher.Address,
                PersonId = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                password = teacher.Password,
                Phone=teacher.Phone,
                Role = teacher.Role
            };


            DAL.Teacher teacher1 = new DAL.Teacher()
            {
                Id = user.PersonId,
                Educator= teacher.educator,
                Person = user
            };

            return teacher1;
        }

    }
}
