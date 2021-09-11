using System;

var r1Setting = 4;
var r2Setting = 15;
var r3Setting = 22;

var input = 'g';

var r1Output = Translation.Translate((int)input - ((int)'a' - 1), r1Setting);
var r2Output = Translation.Translate(r1Output, r2Setting);
var r3Output = Translation.Translate(r2Output, r3Setting);
IncrementRotors();

// translation into reflection plate
// translation inside reflection plate
// reverse translation through the rotors
// translation onto home plate
// steckerbrett translation back to character lamps

void IncrementRotors()
{
    r1Setting += 1;

    if (r1Setting > 26)
    {
        r1Setting = 1;
        r2Setting += 1;
    }

    if (r2Setting > 26)
    {
        r2Setting = 1;
        r3Setting += 1;
    }
}

public static class Translation
{
    public static int Translate(int input, int setting)
    {
        var index = input - 1 + setting;

        if (index > 26)
        {
            index = index - 26;
        }

        int[] matrix = new[] {
        23, 19, 4, 5, 2, 7, 8, 21, 10, 11,
        9, 12, 15, 16, 13, 14, 3, 24, 26, 1,
        17, 6, 18, 20, 22, 25
    };

        return matrix[index];
    }
}
