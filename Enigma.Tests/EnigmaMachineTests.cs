namespace Enigma.Tests
{
    using System.IO;
    using Newtonsoft.Json;
    using Xunit;
    using static Program;

    public class EnigmaMachineTests
    {
        private readonly EnigmaMachine subject;

        public EnigmaMachineTests()
        {
            var configJson = File.ReadAllText("./Config/rotorsettings.json");
            var config = JsonConvert.DeserializeObject<Config>(configJson);
            
            this.subject = new(config);
        }

        [Theory]
        [InlineData(7, 7)]
        [InlineData(15, 23)]
        public void First_rotor_pass_test(int input, int expectedOutput)
        {
            Assert.Equal(expectedOutput, this.subject.RotorTranslations(input));
        }
        
        [Theory]
        [InlineData(7, 7)]
        [InlineData(23, 15)]
        public void Reverse_rotor_pass_test(int input, int expectedOutput)
        {
            Assert.Equal(expectedOutput, this.subject.RotorTranslations(input, reverse: true));
        }
    }
}