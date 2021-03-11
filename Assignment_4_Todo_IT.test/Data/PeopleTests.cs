using Xunit;
using Assignment_4_Todo_IT.Data;
using Assignment_4_Todo_IT.Models;

namespace Assignment_4_Todo_IT.Tests.Data
{
    [Collection("Assignment_4_Todo_IT")]
    public class PeopleTests
    {
        [Fact]
        public void Test_Add()
        {
            // Arrange
            Person person1, person2, person3;

            People.Clear();
            PersonSequencer.Reset();

            // Act
            person1 = People.Add("Kalle", "Karlsson");
            person2 = People.Add("Kent", "Larsson");
            person3 = People.Add("Ebbe", "Karlsson");

            // Assert
            Assert.Equal(3, People.Size());

            Assert.Equal(1, person1.PersonId);
            Assert.Equal("Kalle", person1.FirstName);
            Assert.Equal("Karlsson", person1.LastName);

            Assert.Equal(2, person2.PersonId);
            Assert.Equal("Kent", person2.FirstName);
            Assert.Equal("Larsson", person2.LastName);

            Assert.Equal(3, person3.PersonId);
            Assert.Equal("Ebbe", person3.FirstName);
            Assert.Equal("Karlsson", person3.LastName);
        }
        [Fact]

        public void Test_Size()
        {
            // Arrange
            People.Clear();
        
            // Act
            People.Add("Kalle", "Karlsson");
            People.Add("Kent", "Larsson");
            People.Add("Ebbe", "Karlsson");

            // Assert
            Assert.Equal(3, People.Size());
        }

        [Fact]

        public void Test_FindById()
        {
            // Arrange
            Person person1, person2, person3;
         
            People.Clear();
            PersonSequencer.Reset();
            
            People.Add("Kalle", "Karlsson");
            People.Add("Kent", "Larsson");
            People.Add("Ebbe", "Karlsson");

            // Act
            person1 = People.FindById(1);
            person2 = People.FindById(2);
            person3 = People.FindById(3);

            // Assert
            Assert.Equal(1, person1.PersonId);
            Assert.Equal(2, person2.PersonId);
            Assert.Equal(3, person3.PersonId);
        }

        [Fact]
        public void Test_FindAll()
        {
            // Arrange
            Person[] everybody;
            
            People.Clear();
            PersonSequencer.Reset();
            
            People.Add("Kalle", "Karlsson");
            People.Add("Kent", "Larsson");
            People.Add("Ebbe", "Karlsson");

            // Act
            everybody = People.FindAll();

            // Assert
            Assert.Equal(3, everybody.Length);

            Assert.Equal(1, everybody[0].PersonId);
            Assert.Equal("Kalle", everybody[0].FirstName);
            Assert.Equal("Karlsson", everybody[0].LastName);

            Assert.Equal(2, everybody[1].PersonId);
            Assert.Equal("Kent", everybody[1].FirstName);
            Assert.Equal("Larsson", everybody[1].LastName);

            Assert.Equal(3, everybody[2].PersonId);
            Assert.Equal("Ebbe", everybody[2].FirstName);
            Assert.Equal("Karlsson", everybody[2].LastName);
        }

        [Fact]
        public void Test_Clear()
        {
            // Arrange
            People.Add("Kalle", "Karlsson");
            People.Add("Kent", "Larsson");
            People.Add("Ebbe", "Karlsson");

            // Act
            People.Clear();
            
            // Assert
            Assert.Equal(0, People.Size());
        }
        [Fact]
        public void Test_Remove()
        {
            // Arrange
            Person[] everybody;

            People.Clear();
            PersonSequencer.Reset();

            People.Add("Kalle", "Karlsson");
            People.Add("Kent", "Larsson");
            People.Add("Ebbe", "Karlsson");

            // Act
            People.Remove(2);

            // Assert
            everybody = People.FindAll();
            Assert.Equal(2, everybody.Length);
            Assert.Equal("Kalle", everybody[0].FirstName);
            Assert.Equal("Ebbe", everybody[1].FirstName);
        }
    }
}
