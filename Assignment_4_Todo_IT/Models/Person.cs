using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_Todo_IT.Models
{
    public class Person
    {
        private readonly int personId;
        private string firstName, lastName;

        public Person(int personId, string firstName, string lastName)
        {
            this.personId = personId;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int PersonId
        {
            get
            {
                return this.personId;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (value != "" && value !=null)
                {
                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value != "" && value != null)
                {
                    this.lastName = value;
                }
            }
        }
    }
}
