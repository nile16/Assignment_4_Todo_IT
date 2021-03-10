using System;
using System.Linq;
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

        public static Todo FindById(int todoId)
        {
            return Array.Find(todos, todo => todo.Todoid == todoId);
        }

        public static Todo Add(string description)
        {
            Todo newTodo = new Todo(TodoSequencer.nextTodoId(), description);

            todos = todos.Append(newTodo).ToArray();

            return newTodo;
        }

        public static void Clear()
        {
            todos = new Todo[0];
        }

        public static Todo[] FindByDoneStatus(bool doneStatus)
        {
            return todos.Where(todo => todo.Done == doneStatus).ToArray();
        }

        public static Todo[] FindByAssignee(int personId)
        {
            return todos.Where(todo => todo.Assignee?.PersonId == personId).ToArray();
        }

        public static Todo[] FindByAssignee(Person assignee)
        {
            return todos.Where(todo => todo.Assignee?.PersonId == assignee.PersonId).ToArray();
        }

        public static Todo[] FindUnassignedTodoItems()
        {
            return todos.Where(todo => todo.Assignee == null).ToArray();
        }

        public static void Remove(int todoId)
        {
            todos = todos.Where(todo => todo.Todoid != todoId).ToArray();
        }
    }
}
