namespace AdventOfCode

open System

module Day1 =

    let calculateFuelForMass (mass: int) = mass / 3 - 2

    let rec calculateFuelWithFuel mass =
        let fuel = calculateFuelForMass mass
        if fuel <= 0 then 0
        else fuel + calculateFuelWithFuel fuel

    let readFileInput filePath = System.IO.File.ReadLines(filePath)

    let calculateCounterUpper filePath =
        readFileInput filePath
        |> Seq.map Convert.ToInt32
        |> Seq.sumBy calculateFuelWithFuel
