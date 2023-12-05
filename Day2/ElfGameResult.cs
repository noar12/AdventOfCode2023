using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class ElfGameResult
    {
        public List<ElfGameSet> GameSets { get; private set; }

        public ElfGameResult(int id, List<ElfGameSet> gameSets)
        {
            Id = id;
            GameSets = gameSets;
        }
        public int GetGameMaxEachCube()
        {
            int maxRed = 0, maxGreen = 0, maxBlue =0;
            maxRed = GameSets.Max(s => s.RedCube);
            maxGreen = GameSets.Max(s => s.GreenCube);
            maxBlue = GameSets.Max(s => s.BlueCube);

            return maxRed * maxGreen * maxBlue;
        }
        public int Id { get; private set; }
    }
}
