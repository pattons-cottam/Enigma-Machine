using Xunit;

namespace Enigma.Tests
{
    public class RotorTests
    {
        [Fact]
        public void Translation_test()
        {
            // test 'G' being hit on the keyboard and being processed by the 
            // first rotor, which is set at position 4
            var rotor = new Rotor(4);

            var result = rotor.Translate('g');

            Assert.Equal('i', result);
            Assert.Equal(5, rotor.Setting);
        }

        [Fact]
        public void Two_translations()
        {
            var rotor = new Rotor(4);

            rotor.Translate('g');
            var result = rotor.Translate('g');

            Assert.Equal('l', result);
            Assert.Equal(6, rotor.Setting);
        }
    }
}
