using Xunit;
using Assignment_4_Todo_IT.Data;

namespace Assignment_4_Todo_IT.Tests.Data
{
    [Collection("Assignment_4_Todo_IT")]
    public class TodoSequencerTests
    {
        [Fact]
        public void Test_Reset()
        {
            // Arrange
            TodoSequencer.nextTodoId();
            TodoSequencer.nextTodoId();

            // Act
            TodoSequencer.Reset();

            // Assert
            Assert.Equal(1, TodoSequencer.nextTodoId());
        }

        [Fact]
        public void Test_NextTodoId()
        {
            // Arrange
            int id1, id2, id3;

            // Act
            id1 = TodoSequencer.nextTodoId();
            id2 = TodoSequencer.nextTodoId();
            id3 = TodoSequencer.nextTodoId();

            // Assert
            Assert.True(id2 == id1 + 1);
            Assert.True(id3 == id2 + 1);
        }
    }
}
