using System;
using System.IO;
using Newtonsoft.Json; // dotnet add package Newtonsoft.Json

class Program
{
    static void Main()
    {
        var configJson = File.ReadAllText("./Config/rotorsettings.json");
        var config = JsonConvert.DeserializeObject<Config>(configJson);

        EnigmaMachine machine = new(config);

        var input = (int)'g' - ((int)'a' - 1);
        Console.WriteLine(machine.FirstRotorPass(input));
    }

    class EnigmaMachine
    {
        Rotor RotorOne { get; set; }
        Rotor RotorTwo { get; set; }
        Rotor RotorThree { get; set; }

        public EnigmaMachine(Config config)
        {
            this.RotorOne = config.RotorOne;
            this.RotorTwo = config.RotorTwo;
            this.RotorThree = config.RotorThree;
        }

        void FirstSteckerPass()
        {
            throw new NotImplementedException();
        }

        public int FirstRotorPass(int input)
        {
            return RotorThree.Translate(
                RotorTwo.Translate(
                    RotorOne.Translate(input)));
        }
    }
}