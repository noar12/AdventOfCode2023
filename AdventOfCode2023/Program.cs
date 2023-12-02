using Day1;

namespace AdventOfCode2023;

internal class Program
{
    static void Main()
    {
        string dataPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly()!.Location)!, "DayInputs");
        Console.WriteLine("************** Day 1 example 1 ******************");
        var calib = new Calibration(Path.Combine(dataPath, "Day1Example1.txt"));
        Console.WriteLine($"Example 1 result : {calib.GetCalibrationSum()}");
        calib = new Calibration(Path.Combine(dataPath, "Day1Input1.txt"));
        Console.WriteLine($"First part result : {calib.GetCalibrationSum()}");
        calib = new Calibration(Path.Combine(dataPath, "Day1Example2.txt"));
        Console.WriteLine($"Example 2 result : {calib.GetCalibrationSum(true)}");
        calib = new Calibration(Path.Combine(dataPath, "Day1Input1.txt"));
        Console.WriteLine($"Second part result : {calib.GetCalibrationSum(true)}");
    }
}
