# Enigma-Machine

## About
A simple implementation of the [Enigma Machine](https://en.wikipedia.org/wiki/Enigma_machine) used to encrypt messages during the Second World War. 

<div align="center">
     <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Enigma_wiring_kleur.svg/800px-Enigma_wiring_kleur.svg.png" 
          width="300"/>
</div>



This is currently a work in progresss, the intention is to produce a clean, easily maintainable solution to an interesting logic puzzle. 

## Setup
This project is written in C# using .NET 5, which can be downloaded here: https://dotnet.microsoft.com/download (SDK is required to build the solution, it also includes the .NET runtime). To build the solution install the .NET SDK, clone this repo and run `dotnet build` inside the `Enigma-Machine/` directory.

## Usage
- Configuration for the rotors is defined inside `Enigma/Config/rotorsettings.json` 
- Run `dotnet run` inside the `Enigma-Machine/Enigma` directory to launch the program
- Input will be encrypted as you type
- Run `dotnet test` inside the `Enigma-Machine/` directory to run the unit tests
