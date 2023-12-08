using Day1;
using Day2;
using Day3;
using Day4;
using Day5;

namespace AdventOfCode2023;

internal class Program
{
    static void Main()
    {
        string dataPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly()!.Location)!, "DayInputs");
        Console.WriteLine("************** Day 1 ******************");
        var calib = new Calibration(Path.Combine(dataPath, "Day1Example1.txt"));
        Console.WriteLine($"Example 1 result : {calib.GetCalibrationSum()}");
        calib = new Calibration(Path.Combine(dataPath, "Day1Input1.txt"));
        Console.WriteLine($"First part result : {calib.GetCalibrationSum()}");
        calib = new Calibration(Path.Combine(dataPath, "Day1Example2.txt"));
        Console.WriteLine($"Example 2 result : {calib.GetCalibrationSum(true)}");
        calib = new Calibration(Path.Combine(dataPath, "Day1Input1.txt"));
        Console.WriteLine($"Second part result : {calib.GetCalibrationSum(true)}");

        Console.WriteLine("************** Day 2 ******************");
        var elfGameGuesser = new ElfGameGuesser(Path.Combine(dataPath, "Day2Example1.txt"));
        int[] elfGameConfig = { 12, 13, 14 };
        int sumPossibleGame = elfGameGuesser.SumPossibleGames(elfGameConfig);
        Console.WriteLine($"Example 1 result : {sumPossibleGame}");
        Console.WriteLine($"Example part 2: {elfGameGuesser.GetPower()}");
        elfGameGuesser = new ElfGameGuesser(Path.Combine(dataPath, "Day2Input1.txt"));
        sumPossibleGame = elfGameGuesser.SumPossibleGames(elfGameConfig);
        Console.WriteLine($"First part result : {sumPossibleGame}");
        Console.WriteLine($"Second part : {elfGameGuesser.GetPower()}");

        Console.WriteLine("************** Day 3 ******************");
        var engineSchema = new EngineSchema(Path.Combine(dataPath, "Day3Example1.txt"));
        Console.WriteLine($"Example 1 result : {engineSchema.SumEnginePart()}");
        Console.WriteLine($"Example 2 result : {engineSchema.GearRatioSum}");
        engineSchema = new EngineSchema(Path.Combine(dataPath, "Day3Input1.txt"));
        Console.WriteLine($"Part 1 result : {engineSchema.SumEnginePart()}");
        Console.WriteLine($"Part 2 result : {engineSchema.GearRatioSum}");

        Console.WriteLine("************** Day 4 ******************");
        var cardsCollection = new ScratchCardCollection(Path.Combine(dataPath, "Day4Example1.txt"),1,5,6,13);
        Console.WriteLine($"Example 1 result : {cardsCollection.GetTotalPoints()}");
        Console.WriteLine($"Example 2 result : {cardsCollection.GetCardCountAfterProcess()}");
        cardsCollection = new ScratchCardCollection(Path.Combine(dataPath, "Day4Input1.txt"), 1, 10, 11, 35);
        Console.WriteLine($"First part result : {cardsCollection.GetTotalPoints()}");
        //Console.WriteLine($"Part 2 result : {cardsCollection.GetCardCountAfterProcess()}");
        Console.WriteLine($"Part 2 result : not enabled");

        Console.WriteLine("************** Day 4 ******************");
        var almannac = new Almanac(Path.Combine(dataPath, "Day5Example1.txt"));

    }
}
