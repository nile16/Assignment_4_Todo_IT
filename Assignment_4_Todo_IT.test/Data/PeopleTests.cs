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
            Person[] allPersons;

            People.Clear();

            // Act
            person1 = People.Add("Kalle", "Karlsson");
            person2 = People.Add("Kent", "Larsson");
            person3 = People.Add("Ebbe", "Karlsson");

            // Assert
            allPersons = People.FindAll();
            Assert.Equal(3, People.Size());
            Assert.Equal("Kalle", person1.FirstName);
            Assert.Equal("Karlsson", person1.LastName);
            Assert.Equal("Kent", person2.FirstName);
            Assert.Equal("Larsson", person2.LastName);
            Assert.Equal("Ebbe", person3.FirstName);
            Assert.Equal("Karlsson", person3.LastName);
            Assert.Contains(person1, allPersons);
            Assert.Contains(person2, allPersons);
            Assert.Contains(person3, allPersons);
        }
        [Fact]

        public void Test_Size()
        {
            // Arrange
            int size;

            People.Clear();
        
            People.Add("Kalle", "Karlsson");
            People.Add("Kent", "Larsson");
            People.Add("Ebbe", "Karlsson");

            // Act
            size = People.Size();

            // Assert
            Assert.Equal(3, size);
        }

        [Fact]

        public void Test_FindById()
        {
            // Arrange
            Person person1, person2, person3, person4;
            int person1Id, person2Id, person3Id;
         
            People.Clear();
            
            person1Id = People.Add("Kalle", "Karlsson").PersonId;
            person2Id = People.Add("Kent", "Larsson").PersonId;
            person3Id = People.Add("Ebbe", "Karlsson").PersonId;

            // Act
            person1 = People.FindById(person1Id);
            person2 = People.FindById(person2Id);
            person3 = People.FindById(person3Id);
            person4 = People.FindById(0);

            // Assert
            Assert.Equal(person1Id, person1.PersonId);
            Assert.Equal(person2Id, person2.PersonId);
            Assert.Equal(person3Id, person3.PersonId);
            Assert.Null(person4);
        }

        [Fact]
        public void Test_FindAll()
        {
            // Arrange
            Person person1, person2, person3;
            Person[] everybody;
            
            People.Clear();
            
            person1 = People.Add("Kalle", "Karlsson");
            person2 = People.Add("Kent", "Larsson");
            person3 = People.Add("Ebbe", "Karlsson");

            // Act
            everybody = People.FindAll();

            // Assert
            Assert.Equal(3, everybody.Length);
            Assert.Contains(person1, everybody);
            Assert.Contains(person2, everybody);
            Assert.Contains(person3, everybody);
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
            Person person1, person2, person3;
            Person[] everybody;

            People.Clear();

            person1 = People.Add("Kalle", "Karlsson");
            person2 = People.Add("Kent", "Larsson");
            person3 = People.Add("Ebbe", "Karlsson");

            // Act
            People.Remove(person2.PersonId);

            // Assert
            everybody = People.FindAll();
            Assert.Equal(2, everybody.Length);
            Assert.Contains(person1, everybody);
            Assert.DoesNotContain(person2, everybody);
            Assert.Contains(person3, everybody);
        }
    }
}
