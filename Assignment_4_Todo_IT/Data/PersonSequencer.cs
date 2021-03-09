using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_Todo_IT.Data
{
    public class PersonSequencer
    {
        static int personId = 1;

        public static int nextPersonId()
        {
            return personId++;
        }

        public static void Reset()
        {
            personId = 1;
        }
    }
}
