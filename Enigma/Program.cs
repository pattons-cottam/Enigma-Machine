using System;

var rotorOne = new Rotor(4);

Console.WriteLine("");

// process three steps manually, incrementing the index for the next rotor 
// depending on the value of the index on the previous one

// ** Assumptions:
// There is no translation between the key and home plate
// Each rotor is alphabetical on the entry side (and so the output side is also 
//  alphabetical when just using a simple shift)
// All rotor use the same internal shift mechanism

// ** Process:
// - Select a key, this dictates the entry letter on the first rotor
//  - Entry point is also affected by the initial setting
// - Translate the key inside the first rotor, this dictates the entry on the
//  second rotor
// - Shift the first rotor setting by one
// - Shift second rotor if first is > 26, same for third
// ** Reflection

