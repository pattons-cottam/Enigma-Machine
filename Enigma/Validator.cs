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

    public static List<string> GetValidationErrors(Config config)
    {
        List<string> validationErrors = new();
        int[] control = Enumerable.Range(1, 26).ToArray();

        foreach (var rotor in new[] { config.RotorOne, config.RotorTwo, config.RotorThree })
        {
            if (rotor.Setting < 1 || rotor.Setting > 26)
            {
                validationErrors.Add($"Invalid rotor setting found: {rotor.Setting} (expected: 1-26)");
            }

            var orderedConfig = rotor.Config.OrderBy(x => x).ToArray();

            if (orderedConfig.Except(control).Count() != 0)
            {
                validationErrors.Add("Invalid configuration found, config array must include all integers between 1-26 (inclusive) exactly once");
            }
        }

        return validationErrors;
    }
}