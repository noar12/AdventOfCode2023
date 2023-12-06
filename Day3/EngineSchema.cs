using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day3
{
    public class EngineSchema
    {
        private List<Point> _specialPosition = new();
        private List<EnginePart> _engineParts = new();
        public EngineSchema(string path)
        {
            string[] schemaLines = File.ReadAllLines(path);
            var specialRegex = new Regex(@"[^\d\.\n]+");
            var partRegex = new Regex(@"\d+");
            for (int lineNumber = 0; lineNumber < schemaLines.Length; ++lineNumber)
            {
                var matches = specialRegex.Matches(schemaLines[lineNumber]);
                foreach (var match in matches.Cast<Match>())
                {
                    _specialPosition.Add(new(match.Index, lineNumber));
                }
                matches = partRegex.Matches(schemaLines[lineNumber]);
                foreach (var match in matches.Cast<Match>())
                {
                    var part = new EnginePart();
                    part.Value = int.Parse(match.Value);
                    //add left border
                    if (match.Index > 1) part.Border.Add(new Point(match.Index - 1, lineNumber));
                    // add up and down border
                    for (int i = 0; i < match.Length + 2; ++i)
                    {
                        if (lineNumber > 1 &&
                            (match.Index + i) > 1 &&
                            (match.Index + i) < schemaLines[lineNumber].Length)
                        { part.Border.Add(new Point(match.Index - 1 + i, lineNumber - 1)); }
                        if (lineNumber < (schemaLines.Length - 1) &&
                            (match.Index + i) > 0 &&
                            (match.Index + i) < schemaLines[lineNumber].Length)
                        {
                            part.Border.Add(new Point(match.Index - 1 + i, lineNumber + 1));
                        }
                    }
                    // add right border
                    if (match.Index < (schemaLines[lineNumber].Length - 1)) part.Border.Add(new Point(match.Index + match.Length, lineNumber));
                    _engineParts.Add(part);
                }
            }
        }

        public int SumEnginePart()
        {
            int output = 0;
            foreach (var part in _engineParts.Where(p => p.Border.Any(b => _specialPosition.Contains(b))))
            {
                output += part.Value;
            }
            return output;
        }
    }
}
