using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4;

public class ScratchCard
{
    public int Id { get; set; }
    public List<int> WinningNumbers { get; set; } = new();
    public List<int> Numbers { get; set; } = new();
    public int GetPoints()
    {
        return (int)Math.Pow(2, GetMatchesCount() - 1);
    }
    public int GetMatchesCount()
    {
        return Numbers.Count(n => WinningNumbers.Contains(n));
    }
}
