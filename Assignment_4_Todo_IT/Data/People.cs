using System;
using System.Collections.Generic;
using System.Text;
using Assignment_4_Todo_IT.Models;

namespace Assignment_4_Todo_IT.Data
{
    public class People
    {
        static Person[] people = new Person[0];

        public static int Size()
        {
            return people.Length;
        }

        public static Person[] FindAll()
        {
            return people;
        }

        public static Person FindById(int personId)
        {
            return Array.Find(people, person => person.PersonId == personId);
        }

        public static Person Add(string firstName, string lastName)
        {
            Person[] tempPeople = new Person[people.Length + 1];

            people.CopyTo(tempPeople, 0);

            tempPeople[^1] = new Person(PersonSequencer.nextPersonId(), firstName, lastName);

            people = tempPeople;

            return people[^1];
        }

        public static void Clear()
        {
            people = new Person[0];
        }
    }
}
