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
            Todo[] allTodos;

            TodoItems.Clear();

            // Act
            todo1 = TodoItems.Add("Skotta snö");
            todo2 = TodoItems.Add("Klipp gräset");
            todo3 = TodoItems.Add("Gräv en brunn");

            // Assert
            allTodos = TodoItems.FindAll();
            Assert.Equal(3, allTodos.Length);
            Assert.Equal("Skotta snö", todo1.Description);
            Assert.Equal("Klipp gräset", todo2.Description);
            Assert.Equal("Gräv en brunn", todo3.Description);
            Assert.Contains(todo1, allTodos);
            Assert.Contains(todo2, allTodos);
            Assert.Contains(todo3, allTodos);
        }

        [Fact]
        public void Test_Size()
        {
            // Arrange
            int size;

            TodoItems.Clear();

            TodoItems.Add("Skotta snö");
            TodoItems.Add("Klipp gräset");
            TodoItems.Add("Gräv en brunn");

            // Act
            size = TodoItems.Size();

            // Assert
            Assert.Equal(3, size);
        }
        [Fact]

        public void Test_FindById()
        {
            // Arrange
            Todo todo1, todo2, todo3, todo4;
            int todoId1, todoId2, todoId3;

            TodoItems.Clear();

            todoId1 = TodoItems.Add("Skotta snö").Todoid;
            todoId2 = TodoItems.Add("Klipp gräset").Todoid;
            todoId3 = TodoItems.Add("Gräv en brunn").Todoid;

            // Act
            todo1 = TodoItems.FindById(todoId1);
            todo2 = TodoItems.FindById(todoId2);
            todo3 = TodoItems.FindById(todoId3);
            todo4 = TodoItems.FindById(0);

            // Assert
            Assert.Equal(todoId1, todo1.Todoid);
            Assert.Equal(todoId2, todo2.Todoid);
            Assert.Equal(todoId3, todo3.Todoid);
            Assert.Null(todo4);
        }

        [Fact]
        public void Test_FindAll()
        {
            // Arrange
            Todo todo1, todo2, todo3, todo4;
            Todo[] allTodoItems;

            TodoItems.Clear();

            todo1 = TodoItems.Add("Skotta snö");
            todo2 = TodoItems.Add("Klipp gräset");
            todo3 = TodoItems.Add("Gräv en brunn");

            // Act
            allTodoItems = TodoItems.FindAll();

            // Assert
            Assert.Equal(3, allTodoItems.Length);
            Assert.Contains(todo1, allTodoItems);
            Assert.Contains(todo2, allTodoItems);
            Assert.Contains(todo3, allTodoItems);
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
            Todo[] todoWithAssigneeId2, todoWithAssigneeId3;
            Person person1 = new Person(1, "Kalle", "Karlsson");
            Person person2 = new Person(2, "Kent", "Larsson");

            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö").Assignee = person2;
            TodoItems.Add("Klipp gräset").Assignee = person1;
            TodoItems.Add("Gräv en brunn").Assignee = person2;

            // Act
            todoWithAssigneeId2 = TodoItems.FindByAssignee(2);
            todoWithAssigneeId3 = TodoItems.FindByAssignee(999);

            // Assert
            Assert.Equal(2, todoWithAssigneeId2.Length);
            Assert.Equal("Skotta snö", todoWithAssigneeId2[0].Description);
            Assert.Equal("Gräv en brunn", todoWithAssigneeId2[1].Description);
            Assert.Empty(todoWithAssigneeId3);
        }

        [Fact]
        public void Test_FindByAssignee_Assignee()
        {
            // Arrange
            Todo[] todosWithAssigneePerson2, todosWithAssigneePerson3;
            Person person1 = new Person(1, "Kalle", "Karlsson");
            Person person2 = new Person(2, "Kent", "Larsson");
            Person person3 = new Person(3, "Ebbe", "Karlsson");

            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta snö").Assignee = person2;
            TodoItems.Add("Klipp gräset").Assignee = person1;
            TodoItems.Add("Gräv en brunn").Assignee = person2;

            // Act
            todosWithAssigneePerson2 = TodoItems.FindByAssignee(person2);
            todosWithAssigneePerson3 = TodoItems.FindByAssignee(person3);

            // Assert
            Assert.Equal(2, todosWithAssigneePerson2.Length);
            Assert.Equal("Skotta snö", todosWithAssigneePerson2[0].Description);
            Assert.Equal("Gräv en brunn", todosWithAssigneePerson2[1].Description);
            Assert.Empty(todosWithAssigneePerson3);
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
            Todo todo1, todo2, todo3;
            Todo[] allTodoItems;

            TodoItems.Clear();

            todo1 = TodoItems.Add("Skotta snö");
            todo2 = TodoItems.Add("Klipp gräset");
            todo3 = TodoItems.Add("Gräv en brunn");

            // Act
            TodoItems.Remove(todo2.Todoid);

            // Assert
            allTodoItems = TodoItems.FindAll();
            Assert.Equal(2, allTodoItems.Length);
            Assert.Contains(todo1, allTodoItems);
            Assert.DoesNotContain(todo2, allTodoItems);
            Assert.Contains(todo3, allTodoItems);
        }
    }
}
