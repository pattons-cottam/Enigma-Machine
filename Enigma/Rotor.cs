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

    public int Translate(int input, bool useSetting = true)
    {
        input = useSetting
            ? input + this.Setting
            : input;

        if (input > 26)
        {
            input = input - 26;
        }

        return this.Config[input - 1];
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
        // intentionally left like this for readability
        var positionOfFinalValue = Array.IndexOf(this.Config, input);
        var accountForZeroIndex = positionOfFinalValue + 1;
        var positionMinusSetting = accountForZeroIndex - this.Setting;

        if (positionMinusSetting <= 0)
        {
            positionMinusSetting += 26;
        }

        return positionMinusSetting;
    }
}