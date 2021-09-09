public class Rotor
{
    public Rotor(int setting)
    {
        this.Setting = setting;
    }

    /// the start and current position of the rotor
    public int Setting { get; set; }

    /// the translation inside the rotor
    char[] matrix = new[] {
        'w', 's', 'd', 'e', 'b', 'g', 'h', 'u', 'j', 'k',
        'i', 'l', 'o', 'p', 'm', 'n', 'c', 'x', 'z', 'a',
        'q', 'f', 'r', 't', 'v', 'y'
    };

    public char Translate(char input)
    {
        // this is where it enters the rotor
        var index = (int)input - ((int)'a' - 1) + this.Setting;
        var output = (char)matrix[index - 1];

        this.Setting += 1;

        return output;
    }
}

