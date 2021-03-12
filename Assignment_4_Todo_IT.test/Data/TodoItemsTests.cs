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
            Todo todo1, todo2, todo3;
            Todo[] doneTodos, notDoneTodos;

            TodoItems.Clear();

            todo1 = TodoItems.Add("Skotta snö");
            todo2 = TodoItems.Add("Klipp gräset");
            todo3 = TodoItems.Add("Gräv en brunn");

            todo1.Done = false;
            todo2.Done = true;
            todo3.Done = false;

            // Act
            doneTodos = TodoItems.FindByDoneStatus(true);
            notDoneTodos = TodoItems.FindByDoneStatus(false);

            // Assert
            Assert.Contains(todo1, notDoneTodos);
            Assert.Contains(todo2, doneTodos);
            Assert.Contains(todo3, notDoneTodos);
        }

        [Fact]
        public void Test_FindByAssignee_PersonId()
        {
            // Arrange
            Todo todo1, todo2, todo3;
            Todo[] todosAssignedToPerson1, todosAssignedToUnusedPersonId;
            Person person1 = new Person(1, "Kalle", "Karlsson");
            Person person2 = new Person(2, "Kent", "Larsson");

            TodoItems.Clear();

            todo1 = TodoItems.Add("Skotta snö");
            todo2 = TodoItems.Add("Klipp gräset");
            todo3 = TodoItems.Add("Gräv en brunn");
            TodoItems.Add("Handla mat");

            todo1.Assignee = person1;
            todo2.Assignee = person2;
            todo3.Assignee = person1;

            // Act
            todosAssignedToPerson1 = TodoItems.FindByAssignee(person1.PersonId);
            todosAssignedToUnusedPersonId = TodoItems.FindByAssignee(0);

            // Assert
            Assert.Equal(2, todosAssignedToPerson1.Length);
            Assert.Contains(todo1, todosAssignedToPerson1);
            Assert.Contains(todo3, todosAssignedToPerson1);
            Assert.Empty(todosAssignedToUnusedPersonId);
        }

        [Fact]
        public void Test_FindByAssignee_Assignee()
        {
            // Arrange
            Todo todo1, todo2, todo3;
            Todo[] todosWithAssigneePerson1, todosWithAssigneePerson3;
            Person person1 = new Person(1, "Kalle", "Karlsson");
            Person person2 = new Person(2, "Kent", "Larsson");
            Person person3 = new Person(3, "Ebbe", "Karlsson");

            TodoItems.Clear();

            todo1 = TodoItems.Add("Skotta snö");
            todo2 = TodoItems.Add("Klipp gräset");
            todo3 = TodoItems.Add("Gräv en brunn");
            TodoItems.Add("Handla mat");

            todo1.Assignee = person1;
            todo2.Assignee = person2;
            todo3.Assignee = person1;

            // Act
            todosWithAssigneePerson1 = TodoItems.FindByAssignee(person1);
            todosWithAssigneePerson3 = TodoItems.FindByAssignee(person3);

            // Assert
            Assert.Equal(2, todosWithAssigneePerson1.Length);
            Assert.Contains(todo1, todosWithAssigneePerson1);
            Assert.Contains(todo3, todosWithAssigneePerson1);
            Assert.Empty(todosWithAssigneePerson3);
        }

        [Fact]
        public void Test_FindUnassignedTodoItems()
        {
            // Arrange
            Todo todo1, todo2, todo3, todo4;
            Todo[] unassignedDotos;
            Person person1 = new Person(1, "Kalle", "Karlsson");
            
            TodoItems.Clear();

            todo1 = TodoItems.Add("Skotta snö");
            todo2 = TodoItems.Add("Klipp gräset");
            todo3 = TodoItems.Add("Gräv en brunn");
            todo4 = TodoItems.Add("Handla mat");

            todo1.Assignee = person1;
            todo3.Assignee = person1;

            // Act
            unassignedDotos = TodoItems.FindUnassignedTodoItems();

            // Assert
            Assert.Equal(2, unassignedDotos.Length);
            Assert.Contains(todo2, unassignedDotos);
            Assert.Contains(todo4, unassignedDotos);
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
