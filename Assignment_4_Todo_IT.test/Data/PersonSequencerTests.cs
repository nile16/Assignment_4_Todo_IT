using Xunit;
using Assignment_4_Todo_IT.Data;

namespace Assignment_4_Todo_IT.Tests.Data
{
    [Collection("Assignment_4_Todo_IT")]
    public class PersonSequencerTests
    {

        [Fact]
        public void Test_NextId()
        {
            PersonSequencer.Reset();
            Assert.Equal(1, PersonSequencer.nextPersonId());
            Assert.Equal(2, PersonSequencer.nextPersonId());
            Assert.Equal(3, PersonSequencer.nextPersonId());
            PersonSequencer.Reset();
            Assert.Equal(1, PersonSequencer.nextPersonId());
            Assert.Equal(2, PersonSequencer.nextPersonId());
            Assert.Equal(3, PersonSequencer.nextPersonId());
        }
    }
}
