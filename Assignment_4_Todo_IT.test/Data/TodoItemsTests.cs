using Xunit;
using Assignment_4_Todo_IT.Data;
using Assignment_4_Todo_IT.Models;

namespace Assignment_4_Todo_IT.Tests.Data
{
    [Collection("Assignment_4_Todo_IT")]
    public class TodoItemsTests
    {

        [Fact]
        public void Test_Add()
        {
            // Arrange
            Todo todo1, todo2, todo3;

            TodoItems.Clear();
            TodoSequencer.Reset();

            // Act
            todo1 = TodoItems.Add("Skotta snö");
            todo2 = TodoItems.Add("Klipp gräset");
            todo3 = TodoItems.Add("Gräv en brunn");

            // Assert
            Assert.Equal(1, todo1.Todoid);
            Assert.Equal("Skotta snö", todo1.Description);
            Assert.Equal(2, todo2.Todoid);
            Assert.Equal("Klipp gräset", todo2.Description);
            Assert.Equal(3, todo3.Todoid);
            Assert.Equal("Gräv en brunn", todo3.Description);
        }

        [Fact]
        public void Test_Size()
        {
            // Arrange
            TodoItems.Clear();

            // Act
            TodoItems.Add("Skotta snö");
            TodoItems.Add("Klipp gräset");
            TodoItems.Add("Gräv en brunn");

            // Assert
            Assert.Equal(3, TodoItems.Size());
        }
        [Fact]

        public void Test_FindById()
        {
            // Arrange
            Todo todo1, todo2, todo3;

            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö");
            TodoItems.Add("Klipp gräset");
            TodoItems.Add("Gräv en brunn");

            // Act
            todo1 = TodoItems.FindById(1);
            todo2 = TodoItems.FindById(2);
            todo3 = TodoItems.FindById(3);

            // Assert
            Assert.Equal(1, todo1.Todoid);
            Assert.Equal(2, todo2.Todoid);
            Assert.Equal(3, todo3.Todoid);
        }

        [Fact]
        public void Test_FindAll()
        {
            // Arrange
            Todo[] allTodoItems;

            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö");
            TodoItems.Add("Klipp gräset");
            TodoItems.Add("Gräv en brunn");

            // Act
            allTodoItems = TodoItems.FindAll();

            // Assert
            Assert.Equal(3, allTodoItems.Length);

            Assert.Equal("Skotta snö", allTodoItems[0].Description);
            Assert.Equal(1, allTodoItems[0].Todoid);

            Assert.Equal("Klipp gräset", allTodoItems[1].Description);
            Assert.Equal(2, allTodoItems[1].Todoid);

            Assert.Equal("Gräv en brunn", allTodoItems[2].Description);
            Assert.Equal(3, allTodoItems[2].Todoid);
        }

        [Fact]
        public void Test_Clear()
        {
            // Arrange
            TodoItems.Add("Skotta snö");
            TodoItems.Add("Klipp gräset");
            TodoItems.Add("Gräv en brunn");

            // Act
            TodoItems.Clear();

            // Assert
            Assert.Equal(0, TodoItems.Size());
        }

        [Fact]
        public void Test_FindByDoneStatus()
        {
            // Arrange
            Todo[] notDoneTodos;

            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö");
            TodoItems.Add("Klipp gräset").Done = true;
            TodoItems.Add("Gräv en brunn");

            // Act
            notDoneTodos = TodoItems.FindByDoneStatus(false);

            // Assert
            Assert.Equal(2, notDoneTodos.Length);
            Assert.False(notDoneTodos[0].Done);
            Assert.Equal("Skotta snö", notDoneTodos[0].Description);
            Assert.False(notDoneTodos[1].Done);
            Assert.Equal("Gräv en brunn", notDoneTodos[1].Description);
        }

        [Fact]
        public void Test_FindByAssignee_PersonId()
        {
            // Arrange
            Todo[] todoWithAssigneeId2;
            Person person1 = new Person(1, "Kalle", "Karlsson");
            Person person2 = new Person(2, "Kent", "Larsson");

            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö").Assignee = person2;
            TodoItems.Add("Klipp gräset").Assignee = person1;
            TodoItems.Add("Gräv en brunn").Assignee = person2;

            // Act
            todoWithAssigneeId2 = TodoItems.FindByAssignee(2);

            // Assert
            Assert.Equal(2, todoWithAssigneeId2.Length);
            Assert.Equal("Skotta snö", todoWithAssigneeId2[0].Description);
            Assert.Equal("Gräv en brunn", todoWithAssigneeId2[1].Description);
       }

        [Fact]
        public void Test_FindByAssignee_Assignee()
        {
            // Arrange
            Todo[] todosWithAssigneePerson2;
            Person person1 = new Person(1, "Kalle", "Karlsson");
            Person person2 = new Person(2, "Kent", "Larsson");

            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö").Assignee = person2;
            TodoItems.Add("Klipp gräset").Assignee = person1;
            TodoItems.Add("Gräv en brunn").Assignee = person2;

            // Act
            todosWithAssigneePerson2 = TodoItems.FindByAssignee(person2);

            // Assert
            Assert.Equal(2, todosWithAssigneePerson2.Length);
            Assert.Equal("Skotta snö", todosWithAssigneePerson2[0].Description);
            Assert.Equal("Gräv en brunn", todosWithAssigneePerson2[1].Description);
        }

        [Fact]
        public void Test_FindUnassignedTodoItems()
        {
            // Arrange
            Todo[] unassignedDotos;
            Person person = new Person(1, "Kalle", "Karlsson");
            
            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö");
            TodoItems.Add("Klipp gräset").Assignee = person;
            TodoItems.Add("Gräv en brunn");

            // Act
            unassignedDotos = TodoItems.FindUnassignedTodoItems();

            // Assert
            Assert.Equal(2, unassignedDotos.Length);
            Assert.Equal("Skotta snö", unassignedDotos[0].Description);
            Assert.Equal("Gräv en brunn", unassignedDotos[1].Description);
        }

        [Fact]
        public void Test_Remove()
        {
            // Arrange
            Todo[] allTodoItems;

            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö");
            TodoItems.Add("Klipp gräset");
            TodoItems.Add("Gräv en brunn");

            // Act
            TodoItems.Remove(2);

            // Assert
            allTodoItems = TodoItems.FindAll();
            Assert.Equal(2, allTodoItems.Length);
            Assert.Equal("Skotta snö", allTodoItems[0].Description);
            Assert.Equal("Gräv en brunn", allTodoItems[1].Description);
        }
    }
}
