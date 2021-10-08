using Xunit;

public class ValidatorTests
{
    [Fact]
    public void Missing_rotors_fails_validation()
    {
        Assert.Equal(false, Validator.ValidateConfiguration(new()));
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(26, true)]
    [InlineData(-4, false)]
    [InlineData(33, false)]
    public void Validate_rotor_setting(int setting, bool expectedResult)
    {
        var validConfig = new[]{
            23, 19, 4, 5, 2, 7, 8, 21, 10, 11,
            9, 12, 15, 16, 13, 14, 3, 24, 26, 1,
            17, 6, 18, 20, 22, 25
        };

        Config config = new()
        {
            // use RotorOne for testing, other rotors need to be valid
            RotorOne = new(setting, validConfig),
            RotorTwo = new(1, validConfig),
            RotorThree = new(1, validConfig)
        };

        Assert.Equal(expectedResult, Validator.ValidateConfiguration(config));
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Validate_rotor_config(int[] testConfig, bool expectedResult)
    {
        var validConfig = new[]{
            23, 19, 4, 5, 2, 7, 8, 21, 10, 11,
            9, 12, 15, 16, 13, 14, 3, 24, 26, 1,
            17, 6, 18, 20, 22, 25
        };

        Config config = new()
        {
            // use RotorOne for testing, other rotors need to be valid
            RotorOne = new(1, testConfig),
            RotorTwo = new(1, validConfig),
            RotorThree = new(1, validConfig)
        };

        Assert.Equal(expectedResult, Validator.ValidateConfiguration(config));
    }

    public static TheoryData<int[], bool> TestData = new()
    {
        {
            new[]{ 23, 19, 4, 5, 2, 7, 8, 21, 10, 11,
            9, 12, 15, 16, 13, 14, 3, 24, 26, 1,
            17, 6, 18, 20, 22, 25 },
            true
        },
        {
            new[]{ 23, 19, 4, 5, 2, 7, 8, 21, 10, 11,
            9, 12, 15, 16, 13, 14, 3, 24, 26, 1,
            17, 6, 18, 20, 22, -12 }, // negative entry
            false
        },
        {
            new[]{ 23, 19, 4, 5, 2, 7, 8, 21, 10, 11,
            9, 12, 15, 16, 13, 14, 3, 24, 26, 1 },
            // fewer than 26 entries
            false
        },
        {
            new[]{ 23, 19, 4, 5, 2, 7, 8, 21, 10, 11,
            9, 12, 15, 16, 13, 14, 3, 24, 26, 1,
            17, 6, 18, 20, 22, 30 }, // entry > 26
            false
        },
        {
            new[]{ 23, 19, 4, 5, 2, 7, 8, 21, 10, 11,
            9, 12, 15, 16, 13, 14, 3, 24, 26, 1,
            17, 6, 18, 20, 22, 22 }, // duplicate entry
            false
        },
        {
            new[]{ 23, 19, 4, 5, 2, 7, 8, 21, 10, 11,
            9, 12, 15, 16, 13, 14, 3, 24, 26, 1,
            17, 6, 18, 20, 22, 25, 25 }, // more than 26 entries
            false
        },
    };
}