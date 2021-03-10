using System;
using Xunit;
using Assignment_4_Todo_IT.Data;
using Assignment_4_Todo_IT.Models;

namespace Assignment_4_Todo_IT.Tests.Data
{
    public class TodoItemsTests
    {

        [Fact]
        public void Test_Add_Size()
        {
            TodoItems.Clear();

            Assert.Equal(0, TodoItems.Size());
            TodoItems.Add("Kalle");
            Assert.Equal(1, TodoItems.Size());
            TodoItems.Add("Kent");
            Assert.Equal(2, TodoItems.Size());
            TodoItems.Add("Ebbe");
            Assert.Equal(3, TodoItems.Size());
        }

        [Fact]
        public void Test_Add_FindById()
        {
            Todo todo;

            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Kalle");
            TodoItems.Add("Kent");
            TodoItems.Add("Ebbe");

            todo = TodoItems.FindById(1);
            Assert.Equal("Kalle", todo.Description);
            Assert.Equal(1, todo.Todoid);

            todo = TodoItems.FindById(2);
            Assert.Equal("Kent", todo.Description);
            Assert.Equal(2, todo.Todoid);

            todo = TodoItems.FindById(3);
            Assert.Equal("Ebbe", todo.Description);
            Assert.Equal(3, todo.Todoid);
        }

        [Fact]
        public void Test_Add_FindAll()
        {
            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Kalle");
            TodoItems.Add("Kent");
            TodoItems.Add("Ebbe");

            Todo[] allTodoItems = TodoItems.FindAll();

            Assert.Equal(3, allTodoItems.Length);

            Assert.Equal("Kalle", allTodoItems[0].Description);
            Assert.Equal(1, allTodoItems[0].Todoid);

            Assert.Equal("Kent", allTodoItems[1].Description);
            Assert.Equal(2, allTodoItems[1].Todoid);

            Assert.Equal("Ebbe", allTodoItems[2].Description);
            Assert.Equal(3, allTodoItems[2].Todoid);
        }

        [Fact]
        public void Test_Add_Clear()
        {
            TodoItems.Add("Kalle");
            TodoItems.Add("Kent");
            TodoItems.Add("Ebbe");

            TodoItems.Clear();

            Assert.Equal(0, TodoItems.Size());
        }
    }
}
