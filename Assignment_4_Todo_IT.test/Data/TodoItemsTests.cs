using Xunit;
using Assignment_4_Todo_IT.Data;
using Assignment_4_Todo_IT.Models;

namespace Assignment_4_Todo_IT.Tests.Data
{
    [Collection("Assignment_4_Todo_IT")]
    public class TodoItemsTests
    {

        [Fact]
        public void Test_Add_Size()
        {
            TodoItems.Clear();

            Assert.Equal(0, TodoItems.Size());
            TodoItems.Add("Skotta snö");
            Assert.Equal(1, TodoItems.Size());
            TodoItems.Add("Klipp gräset");
            Assert.Equal(2, TodoItems.Size());
            TodoItems.Add("Gräv en brunn");
            Assert.Equal(3, TodoItems.Size());
        }

        [Fact]
        public void Test_Add_FindById()
        {
            Todo todo;

            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö");
            TodoItems.Add("Klipp gräset");
            TodoItems.Add("Gräv en brunn");

            todo = TodoItems.FindById(1);
            Assert.Equal("Skotta snö", todo.Description);
            Assert.Equal(1, todo.Todoid);

            todo = TodoItems.FindById(2);
            Assert.Equal("Klipp gräset", todo.Description);
            Assert.Equal(2, todo.Todoid);

            todo = TodoItems.FindById(3);
            Assert.Equal("Gräv en brunn", todo.Description);
            Assert.Equal(3, todo.Todoid);
        }

        [Fact]
        public void Test_Add_FindAll()
        {
            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö");
            TodoItems.Add("Klipp gräset");
            TodoItems.Add("Gräv en brunn");

            Todo[] allTodoItems = TodoItems.FindAll();

            Assert.Equal(3, allTodoItems.Length);

            Assert.Equal("Skotta snö", allTodoItems[0].Description);
            Assert.Equal(1, allTodoItems[0].Todoid);

            Assert.Equal("Klipp gräset", allTodoItems[1].Description);
            Assert.Equal(2, allTodoItems[1].Todoid);

            Assert.Equal("Gräv en brunn", allTodoItems[2].Description);
            Assert.Equal(3, allTodoItems[2].Todoid);
        }

        [Fact]
        public void Test_Add_Clear()
        {
            TodoItems.Add("Skotta snö");
            TodoItems.Add("Klipp gräset");
            TodoItems.Add("Gräv en brunn");

            TodoItems.Clear();

            Assert.Equal(0, TodoItems.Size());
        }

        [Fact]
        public void Test_FindByDoneStatus()
        {
            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö");
            TodoItems.FindById(1).Done = true;
            TodoItems.Add("Klipp gräset");
            TodoItems.Add("Gräv en brunn");

            Todo[] notDoneTodos = TodoItems.FindByDoneStatus(false);

            Assert.Equal(2, notDoneTodos.Length);
        }

        [Fact]
        public void Test_FindByAssignee_PersonId()
        {
            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö");
            TodoItems.Add("Klipp gräset");
            TodoItems.Add("Gräv en brunn");
            TodoItems.FindById(1).Assignee = new Person(1, "Kalle", "Karlsson");
            TodoItems.FindById(2).Assignee = new Person(2, "Kent", "Larsson");

            Todo[] todoWithAssigneeId2 = TodoItems.FindByAssignee(2);

            Assert.Single(todoWithAssigneeId2);
        }

        [Fact]
        public void Test_FindByAssignee_Assignee()
        {
            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö");
            TodoItems.Add("Klipp gräset");
            TodoItems.Add("Gräv en brunn");
            TodoItems.Add("Åk och handla");

            Person person1 = new Person(1, "Kalle", "Karlsson");
            Person person2 = new Person(2, "Kent", "Larsson");

            TodoItems.FindById(1).Assignee = person1;
            TodoItems.FindById(2).Assignee = person2;
            TodoItems.FindById(4).Assignee = person2;

            Todo[] todosWithAssigneePerson2 = TodoItems.FindByAssignee(person2);

            Assert.Equal(2, todosWithAssigneePerson2.Length);
        }

        [Fact]
        public void Test_FindUnassignedTodoItems()
        {
            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö");
            TodoItems.Add("Klipp gräset");
            TodoItems.Add("Gräv en brunn");
            TodoItems.Add("Åk och handla");

            Person person1 = new Person(1, "Kalle", "Karlsson");
            Person person2 = new Person(2, "Kent", "Larsson");

            TodoItems.FindById(2).Assignee = person1;
            TodoItems.FindById(3).Assignee = person2;

            Todo[] unassignedDotos = TodoItems.FindUnassignedTodoItems();

            Assert.Equal(2, unassignedDotos.Length);
        }

        [Fact]
        public void Test_Remove()
        {
            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö");
            TodoItems.Add("Klipp gräset");
            TodoItems.Add("Gräv en brunn");
            TodoItems.Add("Åk och handla");

            TodoItems.Remove(2);

            Todo[] allTodoItems = TodoItems.FindAll();

            Assert.Equal(3, allTodoItems.Length);
        }
    }
}
