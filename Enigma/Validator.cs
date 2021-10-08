using System.Collections.Generic;
using System.Linq;
using System;

public static class Validator
{
    public static bool ValidateConfiguration(Config config)
    {
        var validationErrors = GetValidationErrors(config);

        if (validationErrors.Count > 0)
        {
            foreach (var error in validationErrors)
            {
                Console.WriteLine(error);
            }

            return false;
        }

        Console.WriteLine("Valid configuration found");

        return true;
    }

    private static List<string> GetValidationErrors(Config config)
    {
        List<string> validationErrors = new();

        if (config.RotorOne == null
            || config.RotorTwo == null
            || config.RotorThree == null)
        {
            validationErrors.Add("One or more rotors are missing configuration, three rotors expected");

            // return here to avoid an exception below
            return validationErrors;
        }

        int[] control = Enumerable.Range(1, 26).ToArray();

        foreach (var rotor in new[] { config.RotorOne, config.RotorTwo, config.RotorThree })
        {
            if (rotor.Setting < 1 || rotor.Setting > 26)
            {
                validationErrors.Add($"Invalid rotor setting found: {rotor.Setting} (expected: 1-26)");
            }

            if (rotor.Config.Length != 26)
            {
                validationErrors.Add($"Incorrect number of entries in rotor config: {rotor.Config.Length} (expected: 26)");
            }

            if (rotor.Config.Length != rotor.Config.Distinct().ToArray().Length)
            {
                validationErrors.Add("Rotor config contains duplicate entries");
            }

            var orderedConfig = rotor.Config
                .OrderBy(x => x)
                .ToArray();

            if (orderedConfig.Except(control).Count() != 0)
            {
                validationErrors.Add("Invalid configuration found, config array must include all integers between 1-26 (inclusive) exactly once");
            }
        }

        return validationErrors;
    }
}