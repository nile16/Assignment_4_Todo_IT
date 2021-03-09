using System;
using Xunit;
using Assignment_4_Todo_IT.Data;

namespace Assignment_4_Todo_IT.Tests.Data
{
    public class TodoSequencerTests
    {

        [Fact]
        public void Test_NextId()
        {
            Assert.Equal(1, TodoSequencer.nextTodoId());
            Assert.Equal(2, TodoSequencer.nextTodoId());
            Assert.Equal(3, TodoSequencer.nextTodoId());
            TodoSequencer.Reset();
            Assert.Equal(1, TodoSequencer.nextTodoId());
            Assert.Equal(2, TodoSequencer.nextTodoId());
            Assert.Equal(3, TodoSequencer.nextTodoId());
        }
    }
}
