using Xunit;
using Assignment_4_Todo_IT.Models;

namespace Assignment_4_Todo_IT.Tests.Models
{
    [Collection("Assignment_4_Todo_IT")]
    public class PersonTests
    {
        [Fact]
        public void Test_Constructor()
        {
            Person p = new Person(101, "Kalle", "Sändare");

            Assert.Equal(101, p.PersonId);
            Assert.Equal("Kalle", p.FirstName);
            Assert.Equal("Sändare", p.LastName);
        }

        [Fact]
        public void Test_NameChange()
        {
            Person p = new Person(101, "", "");

            p.FirstName = "Kenta";
            p.LastName = "Larsson";

            Assert.Equal(101, p.PersonId);
            Assert.Equal("Kenta", p.FirstName);
            Assert.Equal("Larsson", p.LastName);

            p.FirstName = "";
            p.LastName = "";

            Assert.Equal(101, p.PersonId);
            Assert.Equal("Kenta", p.FirstName);
            Assert.Equal("Larsson", p.LastName);

            p.FirstName = null;
            p.LastName = null;

            Assert.Equal(101, p.PersonId);
            Assert.Equal("Kenta", p.FirstName);
            Assert.Equal("Larsson", p.LastName);
        }
    }
}
