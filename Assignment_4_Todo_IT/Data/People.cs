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
            Person[] temp = new Person[people.Length + 1];
            Person addedPerson;

            for (int i=0; i < people.Length; i++)
            {
                temp[i] = people[i];
            }

            addedPerson = new Person(PersonSequencer.nextPersonId(), firstName, lastName);

            temp[^1] = addedPerson;

            people = temp;

            return people[^1];
        }

        public static void Clear()
        {
            people = new Person[0];
        }
    }
}
