using System;


var rotorOne = new RotorConfig('e', 1, 10);


Console.WriteLine(rotorOne.Value);

// process three steps manually, incrementing the index for the next rotor 
// depending on the value of the index on the previous one

