using System;
using Xunit;

namespace Enigma.Tests
{
    public class RotorTests
    {
        [Theory]
        [InlineData('a', 15, 'p')]
        [InlineData('x', 10, 'h')]
        public void Caesar_translation_test(char input, int shift, char expectedResult)
        {
            var rotor = new RotorConfig(input, 1, shift);

            rotor.Translate();

            Assert.Equal(expectedResult, (char)rotor.Value);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(26, 1)]
        public void Incrementing_test(int startingIndex, int expectedIndex)
        {
            var rotor = new RotorConfig('a', startingIndex, 1);

            rotor.Translate();
            rotor.IncrementIndex();

            Assert.Equal(expectedIndex, rotor.Index);
        }
    }
}
