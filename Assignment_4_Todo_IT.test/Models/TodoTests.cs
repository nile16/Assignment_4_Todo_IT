using System;
using Xunit;
using Assignment_4_Todo_IT.Models;

namespace Assignment_4_Todo_IT.Tests.Models
{
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
        public void Test_GetSet()
        {
            Todo t = new Todo(101, "Testa denna klassen");

            Assert.Equal(101, t.Todoid);
            Assert.Equal("Testa denna klassen", t.Description);
            Assert.False(t.Done);
        }
    }
}
