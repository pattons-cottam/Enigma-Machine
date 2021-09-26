using System;
using System.IO;
using Newtonsoft.Json; // dotnet add package Newtonsoft.Json

public class Program
{
    static void Main()
    {
        var configJson = File.ReadAllText("./Config/rotorsettings.json");
        var config = JsonConvert.DeserializeObject<Config>(configJson);
        // todo: validate config

        EnigmaMachine machine = new(config);

        var input = 'g';
        Console.WriteLine(machine.Process(input));
    }

    public class EnigmaMachine
    {
        Rotor RotorOne { get; set; }
        Rotor RotorTwo { get; set; }
        Rotor RotorThree { get; set; }
        Rotor ReflectionPlate { get; set; }

        public EnigmaMachine(Config config)
        {
            this.RotorOne = config.RotorOne;
            this.RotorTwo = config.RotorTwo;
            this.RotorThree = config.RotorThree;
            this.ReflectionPlate = config.ReflectionPlate;
        }

        public int Process(char input)
        {
            // convert the character into its alphabetical numerical equivalent 
            var inputValue = (int)Char.ToLower(input) - ((int)'a' - 1);

            // todo: combine these without making a nested mess
            // var a = SteckerTranslation();
            var b = RotorTranslations(inputValue);
            var c = Reflection(b);
            var d = RotorTranslations(c, reverse: true);
            // var e = SteckerTranslation(d);

            return 1;
        }

        int SteckerTranslation(int input)
        {
            throw new NotImplementedException();
        }

        public int RotorTranslations(int input, bool reverse = false)
        {
            if (reverse)
            {
                return RotorOne.ReverseTranslation(
                    RotorTwo.ReverseTranslation(
                        RotorThree.ReverseTranslation(input)));
            }

            return RotorThree.Translate(
                    RotorTwo.Translate(
                        RotorOne.Translate(input)));
        }

        /// "The reflector connected outputs of the last rotor in pairs, redirecting current back 
        /// through the rotors by a different route. The reflector ensured that Enigma would be 
        /// self-reciprocal; thus, with two identically configured machines, a message could be 
        /// encrypted on one and decrypted on the other, without the need for a bulky mechanism 
        /// to switch between encryption and decryption modes. The reflector allowed a more compact 
        /// design, but it also gave Enigma the property that no letter ever encrypted to itself."
        public int Reflection(int input)
        {
            return ReflectionPlate.Translate(input, useSetting: false);
        }
    }
}