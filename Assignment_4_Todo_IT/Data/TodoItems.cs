using System;
using System.Collections.Generic;
using System.Text;
using Assignment_4_Todo_IT.Models;

namespace Assignment_4_Todo_IT.Data
{
    public class TodoItems
    {
        static Todo[] todos = new Todo[0];

        public static int Size()
        {
            return todos.Length;
        }

        public static Todo[] FindAll()
        {
            return todos;
        }

        public static Todo FindById(int personId)
        {
            return Array.Find(todos, todo => todo.Todoid == personId);
        }

        public static Todo Add(string description)
        {
            Todo[] tempTodos = new Todo[todos.Length + 1];

            todos.CopyTo(tempTodos, 0);

            tempTodos[^1] = new Todo(TodoSequencer.nextTodoId(), description);

            todos = tempTodos;

            return todos[^1];
        }

        public static void Clear()
        {
            todos = new Todo[0];
        }
    }
}
