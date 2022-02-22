using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWindow
{
    public class User
    {
        // user properties
        public enum SexOfPerson {  Male = 1, Female = 2 }

        private string _firstName;
        private string _lastName;
        private string _id;

        // user constructor
        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }


        // get and set First Name 
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value.Length > 50)
                    Console.Write("ERROR: FirstName must not exceed 50 characters");
                else
                    _firstName = value;
            }
        }

        // get and set Last Name 
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Length > 50)
                    Console.Write("ERROR: LastName must not exceed 50 characters");
                else
                    _lastName = value;   
            }
        }

        // get ID 
        public string ID
        {
            get { return _id; }
        }
    }
}
