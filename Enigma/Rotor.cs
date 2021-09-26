using System;

public class Rotor
{
    public int Setting { get; set; }
    public int[] Config { get; set; }

    public Rotor(int setting, int[] config)
    {
        this.Setting = setting;
        this.Config = config;
    }

    public int Translate(int input)
    {
        var index = input + this.Setting;

        if (index > 26)
        {
            index = index - 26;
        }

        return this.Config[index - 1];
    }

    public void IncrementSetting()
    {
        this.Setting++;

        if (this.Setting > 26)
        {
            this.Setting = 1;
        }
    }

    public int ReverseTranslation(int input)
    {
        return Array.IndexOf(this.Config, input) + 1;
    }
}