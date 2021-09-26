namespace Enigma.Tests
{
    using Xunit;

    public class RotorTests
    {
        private readonly int[] rotorConfig = new[] {
                23, 19, 4, 5, 2, 7, 8, 21, 10, 11,
                9, 12, 15, 16, 13, 14, 3, 24, 26, 1,
                17, 6, 18, 20, 22, 25
            };

        [Theory]
        [InlineData(4, 7, 9)]
        [InlineData(6, 25, 2)]
        public void Translate_test(int setting, int input, int expectedOutput)
        {
            Rotor subject = new(setting, this.rotorConfig);

            var output = subject.Translate(input);

            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData(5, 6)]
        [InlineData(25, 26)]
        [InlineData(26, 1)]
        public void Settings_incremented_correctly(int setting, int expectedNewSetting)
        {
            Rotor subject = new(setting, this.rotorConfig);

            subject.IncrementSetting();

            Assert.Equal(expectedNewSetting, subject.Setting);
        }

        [Theory]
        [InlineData(7, 9)]
        [InlineData(25, 2)]
        public void Reverse_translate_test(int input, int expectedOutput)
        {
            // setting is irrelevant on reverse
            Rotor subject = new(setting: 0, this.rotorConfig);

            var output = subject.ReverseTranslation(input);
        }
    }
}
