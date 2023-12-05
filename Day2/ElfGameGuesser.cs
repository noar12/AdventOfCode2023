using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day2;

public class ElfGameGuesser
{
    private readonly List<ElfGameResult> _gameResults;
    public ElfGameGuesser(string path)
    {
        _gameResults = new List<ElfGameResult>();
        string[] gamesText = File.ReadAllLines(path);
        foreach (string game in gamesText)
        {
            string[] splits = game.Split(":");
            string IdText = splits[0];
            string[] gameSetsText = splits[1].Split(";");

            var regexId = new Regex(@"\d+");
            int id = int.Parse(regexId.Match(IdText).Value);
            var gameSets = new List<ElfGameSet>();
            foreach (string gameSetText in gameSetsText)
            {
                string[] cubeInfo = gameSetText.Split(",");
                var gameSet = new ElfGameSet();
                foreach (string cube in cubeInfo)
                {
                    string[] cubeSplits = cube.Split(" ");
                    string color = cubeSplits[^1];
                    int count;
                    if (string.IsNullOrEmpty(cubeSplits[0]))
                    {
                        count = int.Parse(cubeSplits[1]);
                    }
                    else
                    {
                        count = int.Parse(cubeSplits[0]);
                    }
                    
                    switch (color)
                    {
                        case "red":
                            gameSet.RedCube = count;
                            break;
                        case "green":
                            gameSet.GreenCube = count;
                            break;
                        case "blue":
                            gameSet.BlueCube = count;
                            break;
                        default:
                            break;
                    }
                }
                gameSets.Add(gameSet);
            }
            _gameResults.Add(new ElfGameResult(id, gameSets));
        }
    }
    public int SumPossibleGames(int[] GameConfig)
    {
        int output = _gameResults.Where(g => g.GameSets.TrueForAll(s => s.RedCube <= GameConfig[0]) &&
                                           g.GameSets.TrueForAll(s => s.GreenCube <= GameConfig[1]) &&
                                           g.GameSets.TrueForAll(s => s.BlueCube <= GameConfig[2])).Sum(g => g.Id);
        return output;
    }
    public int GetPower()
    {
        return _gameResults.Select(g => g.GetGameMaxEachCube()).Sum();
    }
}

