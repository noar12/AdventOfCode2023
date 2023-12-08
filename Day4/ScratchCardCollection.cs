using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day4;

public class ScratchCardCollection
{
    private readonly List<ScratchCard> _cards = new();
    public ScratchCardCollection(string path, int firstWinningIndex, int lastWinningIndex, int firstNumberIndex, int lastNumberIndex)
    {
        string[] cardCollectionText = File.ReadAllLines(path);
        var cardRegex = new Regex(@"Card \d+ :\s+\d+|\s+\d+");
        foreach (var cardText in cardCollectionText)
        {
            var matches = cardRegex.Matches(cardText);
            var card = new ScratchCard()
            {
                Id = int.Parse(matches[0].Value),
            };
            for (int i = firstWinningIndex; i <= lastWinningIndex; ++i)
            {
                card.WinningNumbers.Add(int.Parse(matches[i].Value));
            }
            for (int i = firstNumberIndex; i <= lastNumberIndex; ++i)
            {
                card.Numbers.Add(int.Parse(matches[i].Value));
            }
            _cards.Add(card);
        }
    }
    public int GetTotalPoints()
    {
        return _cards.Sum(c => c.GetPoints());
    }
}
