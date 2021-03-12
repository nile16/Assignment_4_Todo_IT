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
            TodoSequencer.Reset();

            // Act
            todo1 = TodoItems.Add("Skotta sn�");
            todo2 = TodoItems.Add("Klipp gr�set");
            todo3 = TodoItems.Add("Gr�v en brunn");

            // Assert
            allTodos = TodoItems.FindAll();
            Assert.Equal(3, allTodos.Length);
            Assert.Equal("Skotta sn�", todo1.Description);
            Assert.Equal("Klipp gr�set", todo2.Description);
            Assert.Equal("Gr�v en brunn", todo3.Description);
            Assert.Contains(todo1, allTodos);
            Assert.Contains(todo2, allTodos);
            Assert.Contains(todo3, allTodos);
        }

        [Fact]
        public void Test_Size()
        {
            // Arrange
            TodoItems.Clear();

            // Act
            TodoItems.Add("Skotta sn�");
            TodoItems.Add("Klipp gr�set");
            TodoItems.Add("Gr�v en brunn");

            // Assert
            Assert.Equal(3, TodoItems.Size());
        }
        [Fact]

        public void Test_FindById()
        {
            // Arrange
            Todo todo1, todo2, todo3, todo4;

            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta sn�");
            TodoItems.Add("Klipp gr�set");
            TodoItems.Add("Gr�v en brunn");

            // Act
            todo1 = TodoItems.FindById(1);
            todo2 = TodoItems.FindById(2);
            todo3 = TodoItems.FindById(3);
            todo4 = TodoItems.FindById(999);

            // Assert
            Assert.Equal(1, todo1.Todoid);
            Assert.Equal(2, todo2.Todoid);
            Assert.Equal(3, todo3.Todoid);
            Assert.Null(todo4);
        }

        [Fact]
        public void Test_FindAll()
        {
            // Arrange
            Todo[] allTodoItems;

            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta sn�");
            TodoItems.Add("Klipp gr�set");
            TodoItems.Add("Gr�v en brunn");

            // Act
            allTodoItems = TodoItems.FindAll();

            // Assert
            Assert.Equal(3, allTodoItems.Length);

            Assert.Equal("Skotta sn�", allTodoItems[0].Description);
            Assert.Equal(1, allTodoItems[0].Todoid);

            Assert.Equal("Klipp gr�set", allTodoItems[1].Description);
            Assert.Equal(2, allTodoItems[1].Todoid);

            Assert.Equal("Gr�v en brunn", allTodoItems[2].Description);
            Assert.Equal(3, allTodoItems[2].Todoid);
        }

        [Fact]
        public void Test_Clear()
        {
            // Arrange
            TodoItems.Add("Skotta sn�");
            TodoItems.Add("Klipp gr�set");
            TodoItems.Add("Gr�v en brunn");

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

            TodoItems.Add("Skotta sn�");
            TodoItems.Add("Klipp gr�set").Done = true;
            TodoItems.Add("Gr�v en brunn");

            // Act
            notDoneTodos = TodoItems.FindByDoneStatus(false);

            // Assert
            Assert.Equal(2, notDoneTodos.Length);
            Assert.False(notDoneTodos[0].Done);
            Assert.Equal("Skotta sn�", notDoneTodos[0].Description);
            Assert.False(notDoneTodos[1].Done);
            Assert.Equal("Gr�v en brunn", notDoneTodos[1].Description);
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

            TodoItems.Add("Skotta sn�").Assignee = person2;
            TodoItems.Add("Klipp gr�set").Assignee = person1;
            TodoItems.Add("Gr�v en brunn").Assignee = person2;

            // Act
            todoWithAssigneeId2 = TodoItems.FindByAssignee(2);
            todoWithAssigneeId3 = TodoItems.FindByAssignee(999);

            // Assert
            Assert.Equal(2, todoWithAssigneeId2.Length);
            Assert.Equal("Skotta sn�", todoWithAssigneeId2[0].Description);
            Assert.Equal("Gr�v en brunn", todoWithAssigneeId2[1].Description);
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

            TodoItems.Add("Skotta sn�").Assignee = person2;
            TodoItems.Add("Klipp gr�set").Assignee = person1;
            TodoItems.Add("Gr�v en brunn").Assignee = person2;

            // Act
            todosWithAssigneePerson2 = TodoItems.FindByAssignee(person2);
            todosWithAssigneePerson3 = TodoItems.FindByAssignee(person3);

            // Assert
            Assert.Equal(2, todosWithAssigneePerson2.Length);
            Assert.Equal("Skotta sn�", todosWithAssigneePerson2[0].Description);
            Assert.Equal("Gr�v en brunn", todosWithAssigneePerson2[1].Description);
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

            TodoItems.Add("Skotta sn�");
            TodoItems.Add("Klipp gr�set").Assignee = person;
            TodoItems.Add("Gr�v en brunn");

            // Act
            unassignedDotos = TodoItems.FindUnassignedTodoItems();

            // Assert
            Assert.Equal(2, unassignedDotos.Length);
            Assert.Equal("Skotta sn�", unassignedDotos[0].Description);
            Assert.Equal("Gr�v en brunn", unassignedDotos[1].Description);
        }

        [Fact]
        public void Test_Remove()
        {
            // Arrange
            Todo[] allTodoItems;

            TodoItems.Clear();
            TodoSequencer.Reset();

            TodoItems.Add("Skotta sn�");
            TodoItems.Add("Klipp gr�set");
            TodoItems.Add("Gr�v en brunn");

            // Act
            TodoItems.Remove(2);

            // Assert
            allTodoItems = TodoItems.FindAll();
            Assert.Equal(2, allTodoItems.Length);
            Assert.Equal("Skotta sn�", allTodoItems[0].Description);
            Assert.Equal("Gr�v en brunn", allTodoItems[1].Description);
        }
    }
}
