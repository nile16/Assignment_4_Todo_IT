using System;
using Xunit;
using Assignment_4_Todo_IT.Data;
using Assignment_4_Todo_IT.Models;

namespace Assignment_4_Todo_IT.Tests.Data
{
    public class PeopleTests
    {

        [Fact]
        public void Test_Constructor()
        {
            Assert.Equal(0, People.Size());
            People.Add("Kalle", "Karlsson");
            Assert.Equal(1, People.Size());
            People.Add("Kent", "Larsson");
            Assert.Equal(2, People.Size());
            People.Add("Ebbe", "Karlsson");
            Assert.Equal(3, People.Size());

            Person p = People.FindById(1);

            Assert.Equal("Kalle", p.FirstName);
            Assert.Equal("Karlsson", p.LastName);
            Assert.Equal(1, p.PersonId);

            Person[] all = People.FindAll();

            Assert.Equal(3, all.Length);

            Assert.Equal("Kalle", all[0].FirstName);
            Assert.Equal("Karlsson", all[0].LastName);
            Assert.Equal(1, all[0].PersonId);
            Assert.Equal("Kent", all[1].FirstName);
            Assert.Equal("Larsson", all[1].LastName);
            Assert.Equal(2, all[1].PersonId);
            Assert.Equal("Ebbe", all[2].FirstName);
            Assert.Equal("Karlsson", all[2].LastName);
            Assert.Equal(3, all[2].PersonId);

            People.Clear();

            Assert.Equal(0, People.Size());
        }
    }
}
