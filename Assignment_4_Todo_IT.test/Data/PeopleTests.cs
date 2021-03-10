using Xunit;
using Assignment_4_Todo_IT.Data;
using Assignment_4_Todo_IT.Models;

namespace Assignment_4_Todo_IT.Tests.Data
{
    [Collection("Assignment_4_Todo_IT")]
    public class PeopleTests
    {

        [Fact]
        public void Test_Add_Size()
        {
            People.Clear();

            Assert.Equal(0, People.Size());
            People.Add("Kalle", "Karlsson");
            Assert.Equal(1, People.Size());
            People.Add("Kent", "Larsson");
            Assert.Equal(2, People.Size());
            People.Add("Ebbe", "Karlsson");
            Assert.Equal(3, People.Size());
        }

        [Fact]
        public void Test_Add_FindById()
        {
            Person person;

            People.Clear();
            PersonSequencer.Reset();

            People.Add("Kalle", "Karlsson");
            People.Add("Kent", "Larsson");
            People.Add("Ebbe", "Karlsson");

            person = People.FindById(1);
            Assert.Equal("Kalle", person.FirstName);
            Assert.Equal("Karlsson", person.LastName);
            Assert.Equal(1, person.PersonId);

            person = People.FindById(2);
            Assert.Equal("Kent", person.FirstName);
            Assert.Equal("Larsson", person.LastName);
            Assert.Equal(2, person.PersonId);

            person = People.FindById(3);
            Assert.Equal("Ebbe", person.FirstName);
            Assert.Equal("Karlsson", person.LastName);
            Assert.Equal(3, person.PersonId);
        }

        [Fact]
        public void Test_Add_FindAll()
        {
            People.Clear();
            PersonSequencer.Reset();

            People.Add("Kalle", "Karlsson");
            People.Add("Kent", "Larsson");
            People.Add("Ebbe", "Karlsson");

            Person[] everybody = People.FindAll();

            Assert.Equal(3, everybody.Length);

            Assert.Equal("Kalle", everybody[0].FirstName);
            Assert.Equal("Karlsson", everybody[0].LastName);
            Assert.Equal(1, everybody[0].PersonId);

            Assert.Equal("Kent", everybody[1].FirstName);
            Assert.Equal("Larsson", everybody[1].LastName);
            Assert.Equal(2, everybody[1].PersonId);

            Assert.Equal("Ebbe", everybody[2].FirstName);
            Assert.Equal("Karlsson", everybody[2].LastName);
            Assert.Equal(3, everybody[2].PersonId);
        }

        [Fact]
        public void Test_Remove()
        {
            People.Clear();
            PersonSequencer.Reset();

            People.Add("Kalle", "Karlsson");
            People.Add("Kent", "Larsson");
            People.Add("Ebbe", "Karlsson");

            People.Remove(2);

            Person[] everybody = People.FindAll();

            Assert.Equal(2, everybody.Length);
            Assert.Equal("Kalle", everybody[0].FirstName);
            Assert.Equal("Ebbe", everybody[1].FirstName);
        }

        [Fact]
        public void Test_Add_Clear()
        {
            People.Add("Kalle", "Karlsson");
            People.Add("Kent", "Larsson");
            People.Add("Ebbe", "Karlsson");

            People.Clear();

            Assert.Equal(0, People.Size());
        }
    }
}
