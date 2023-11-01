using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }
        public string Password { get; set; }

        //private string password;

        //public string Password
        //{
        //    get { return password; }
        //    set
        //    {
        //        if ((value.Length == 9) && (value == Phone))
        //            password = value;
        //    }
        //}

        public string Email { get; set; }

        public string Role { get; set; }
         


        public Person(string id, string firstName, string lastName, string phone, string address, string email, string password,string role)
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

        public Person(string id, string firstName, string lastName, string phone, string address, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Address = address;
            Password = password;
            Email = email;
            
        }

        public Person()
        {
        }

        public static DTO.Person ConvertPersonToDTO(DAL.Person p)
        {

            return new DTO.Person()
            {

                Id=p.PersonId,
                Password = p.password,
                Address = p.Address,
                Email = p.Email,
                FirstName = p.FirstName,
                LastName = p.LastName,
                //pharm = p.LastName,
                Phone = p.Phone,
                Role = p.Role
            };

        }





        public static DAL.Person ConvertPersonToDAL(Person person)
        {
           return  new DAL.Person()
            {
                Address = person.Address,
                PersonId = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                password = person.Password,
                Phone = person.Phone,
                Role = person.Role

            };


           
        }


    }

}


