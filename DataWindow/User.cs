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
        private SexOfPerson _sex;

        // user constructor
        public User(string firstName, string lastName, string id, SexOfPerson sex)
        {
            FirstName = firstName;
            LastName = lastName;
            _id = id;
            Sex = sex;
        }


        // get and set first name 
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

        // get and set last name 
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Length > 50)
                    Console.Write("ERROR: Name must not exceed 50 characters");
                else
                    _lastName = value;   
            }
        }

        // get and set ID 
        public string ID
        {
            get { return _id; }
            set {
                if (value.Length > 10)
                    Console.WriteLine("ERRIRL ID must not exceed 10 characters");
                else
                    _id = value;
                }
        }

        // get and set sex
        public SexOfPerson Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

    }
}
