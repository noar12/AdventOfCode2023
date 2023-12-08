using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day5;

public class Almanac
{
    private List<Range> _seedToSoil = new();
    private List<Range> _soilToFertilizer = new();
    private List<Range> _fertilizerToWater = new();
    private List<Range> _waterToLight = new();
    private List<Range> _lightToTemperature = new();
    private List<Range> _temperatureToHumidity = new();
    private List<Range> _humidityToLocation = new();

    private List<long> _seeds = new();

    public Almanac(string path)
    {
        
        string[] almanacText = File.ReadAllLines(path);

        _seeds = almanacText[0]
            .Split(':')[1]
            .Split(' ')
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(x => long.Parse(x)).ToList();
        var map
        foreach (string line in almanacText)
        {
            if (line.Contains("seeds"))
            {
                _seeds = line
            .Split(':')[1]
            .Split(' ')
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(x => long.Parse(x)).ToList();
            }
            if (line.Contains("seed-to-soil"))
            {
                _seedToSoil = line.Split()
            }
        }
    }

}
