using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_Todo_IT.Data
{
    public class TodoSequencer
    {
        static int todoId = 1;

        public static int nextTodoId()
        {
            return todoId++;
        }

        public static void Reset()
        {
            todoId = 1;
        }
    }
}
