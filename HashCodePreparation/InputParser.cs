using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HashCodePreparation
{
    class InputParser
    {
        public static int[] ParseLine(string line)
        {
            var args = line.Split(' ');
            return args.Select(c => int.Parse(c)).ToArray();
        }

        public static Input ParseInput(string lines)
        {
            string[] result = Regex.Split(lines, "\r\n|\r|\n");
            return ParseInput(result[0], result.Skip(1));
        }

        private static Input ParseInput(string line, IEnumerable<string> rideLines) {
            var mainInput = ParseLine(line);
            
            var rides = rideLines.Select(l =>
            {
                var parsedLine = ParseLine(l);
                return new Ride(parsedLine[0], parsedLine[1], parsedLine[2], parsedLine[3], parsedLine[4], parsedLine[5]);
            }).ToList();

            return new Input(mainInput[0], mainInput[1], mainInput[2], mainInput[3], mainInput[4], mainInput[5], rides);
        }
    }
}
