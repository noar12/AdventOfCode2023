using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Range
    {
        public long DestinationStart { get; set; }
        public long SourceStart { get; set; }
        public long DestinationLast { get; set; }
        public long SourceLast { get; set; }
        public Range(long destinationStart, long sourceStart, long length)
        {
            DestinationStart = destinationStart;
            SourceStart = sourceStart;
            DestinationLast = destinationStart + length -1;
            SourceLast = sourceStart + length - 1;
        }

    }
}
