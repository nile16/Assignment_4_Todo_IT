using Xunit;
using Assignment_4_Todo_IT.Models;

namespace Assignment_4_Todo_IT.Tests.Models
{
    [Collection("Assignment_4_Todo_IT")]
    public class PersonTests
    {
        [Fact]
        public void Test_ConstructorAndDefaultValues()
        {
            // Arrange
            Person person;
            
            // Act
            person = new Person(101, "Kalle", "Sändare");

            // Assert
            Assert.Equal(101, person.PersonId);
            Assert.Equal("Kalle", person.FirstName);
            Assert.Equal("Sändare", person.LastName);
        }

        [Fact]
        public void Test_NameChange()
        {
            // Arrange
            Person person= new Person(101, "", "");

            // Act
            person.FirstName = "Kenta";
            person.LastName = "Larsson";
            person.FirstName = "";
            person.LastName = "";
            person.FirstName = null;
            person.LastName = null;

            // Assert
            Assert.Equal(101, person.PersonId);
            Assert.Equal("Kenta", person.FirstName);
            Assert.Equal("Larsson", person.LastName);
        }
    }
}
