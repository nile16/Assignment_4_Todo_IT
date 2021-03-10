using System;
using System.Linq;
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
            Person newPerson = new Person(PersonSequencer.nextPersonId(), firstName, lastName);

            people = people.Append(newPerson).ToArray();

            return newPerson;
        }

        public static void Remove(int personId)
        {
            people = people.Where(person => person.PersonId != personId).ToArray();
        }

        public static void Clear()
        {
            people = new Person[0];
        }
    }
}
