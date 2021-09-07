public class RotorConfig
{
    public RotorConfig(int value, int index, int shift)
    {
        this.Value = value;
        this.Index = index;
        this.Shift = shift;        
    }

    // todo: generate random character set for the rotor, or allow input

    public int Value { get; set; }
    public int Index { get; set; }
    public int Shift { get; set; }

    public void Translate()
    {
        this.Value += this.Shift;

        if (this.Value > 122) // 'z'
        {
            this.Value = 96 + (this.Value - 122);
        }
    }

    public void IncrementIndex()
    {
        this.Index++;

        if (this.Index > 26)
        {
            this.Index = 1;
        }
    }
}