using Xunit;

namespace Enigma.Tests
{
    public class TranslationTests
    {
        [Fact]
        public void Single_rotor_translation()
        {
            // represents an input of 'g' with a rotor
            // setting of 4
            var result = Translation.Translate(7, 4);

            Assert.Equal(9, result);
        }

        [Fact]
        public void Three_rotor_simulation()
        {
            var r1 = Translation.Translate(7, 4);
            var r2 = Translation.Translate(r1, 15);
            var r3 = Translation.Translate(r2, 22);

            Assert.Equal(14, r3);
        }
    }
}
