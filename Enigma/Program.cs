using System;
using System.IO;
using Newtonsoft.Json; // dotnet add package Newtonsoft.Json

public class Program
{
    static void Main()
    {
        var configJson = File.ReadAllText("./Config/rotorsettings.json");
        var config = JsonConvert.DeserializeObject<Config>(configJson);
        
        if (!Validator.ValidateConfiguration(config)) return;

        EnigmaMachine machine = new(config);

        var input = 'g';
        Console.WriteLine(machine.Process(input)); // this is outputting a number
    }
}