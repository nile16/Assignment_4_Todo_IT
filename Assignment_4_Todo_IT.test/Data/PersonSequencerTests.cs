using Xunit;
using Assignment_4_Todo_IT.Data;

namespace Assignment_4_Todo_IT.Tests.Data
{
    [Collection("Assignment_4_Todo_IT")]
    public class PersonSequencerTests
    {
        [Fact]
        public void Test_Reset()
        {
            // Arrange
            PersonSequencer.nextPersonId();
            PersonSequencer.nextPersonId();

            // Act
            PersonSequencer.Reset();

            // Assert
            Assert.Equal(1, PersonSequencer.nextPersonId());
        }

        [Fact]
        public void Test_NextPersonId()
        {
            // Arrange
            int id1, id2, id3;

            // Act
            id1 = PersonSequencer.nextPersonId();
            id2 = PersonSequencer.nextPersonId();
            id3 = PersonSequencer.nextPersonId();

            // Assert
            Assert.True(id2 == id1 + 1);
            Assert.True(id3 == id2 + 1);
        }
    }
}
