using Xunit;
using Assignment_4_Todo_IT.Models;

namespace Assignment_4_Todo_IT.Tests.Models
{
    [Collection("Assignment_4_Todo_IT")]
    public class TodoTests
    {
        [Fact]
        public void Test_Constructor()
        {
            Todo t = new Todo(101, "Testa denna klassen");

            Assert.Equal(101, t.Todoid);
            Assert.Equal("Testa denna klassen", t.Description);
            Assert.False(t.Done);
        }

        [Fact]
        public void Test_Description()
        {
            Todo t = new Todo(101, "Testa denna klassen.");

            Assert.Equal("Testa denna klassen.", t.Description);

            t.Description = "Testa denna klassen genast!";

            Assert.Equal("Testa denna klassen genast!", t.Description);
        }

        [Fact]
        public void Test_Done()
        {
            Todo t = new Todo(101, "Testa denna klassen");

            Assert.False(t.Done);

            t.Done = true;

            Assert.True(t.Done);
        }

        [Fact]
        public void Test_Assign()
        {
            Todo t = new Todo(101, "Testa denna klassen");

            t.Assignee = new Person(101, "Kalle", "Karlsson"); 

            Assert.Equal("Karlsson", t.Assignee.LastName);
        }
    }
}
