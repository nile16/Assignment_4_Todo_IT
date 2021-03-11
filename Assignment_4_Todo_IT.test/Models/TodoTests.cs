using Xunit;
using Assignment_4_Todo_IT.Models;

namespace Assignment_4_Todo_IT.Tests.Models
{
    [Collection("Assignment_4_Todo_IT")]
    public class TodoTests
    {
        [Fact]
        public void Test_ConstructorAndDefaultValues()
        {
            // Arrange
            Todo t;
            
            // Act
            t = new Todo(101, "Testa Todo-klassen");

            // Assert
            Assert.Equal(101, t.Todoid);
            Assert.Equal("Testa Todo-klassen", t.Description);
            Assert.False(t.Done);
        }

        [Fact]
        public void Test_DotoIdGet()
        {
            // Arrange
            Todo todo;
            int todoId;
            todo = new Todo(101, "Testa Todo-klassen");

            // Act
            todoId = todo.Todoid;

            // Assert
            Assert.Equal(101, todoId);
        }

        [Fact]
        public void Test_DescriptionGetSet()
        {
            // Arrange
            string description;
            Todo t = new Todo(101, "Testa Todo-klassen");

            // Act
            t.Description = "Testa Todo-klassen genast!";
            description = t.Description;

            // Assert
            Assert.Equal("Testa Todo-klassen genast!", description);
        }

        [Fact]
        public void Test_DoneGetSet()
        {
            // Arrange
            bool done;
            Todo t = new Todo(101, "Testa denna klassen");

            // Act
            t.Done = true;
            done = t.Done;

            // Assert
            Assert.True(done);
        }

        [Fact]
        public void Test_AssigneeSetGet()
        {
            // Arrange
            Todo t = new Todo(101, "Testa denna klassen");
            Person person1 = new Person(101, "Kalle", "Karlsson"), person2;
            
            // Act
            t.Assignee = person1;
            person2 = t.Assignee;

            // Assert
            Assert.True(person1.Equals(person2));
        }
    }
}
