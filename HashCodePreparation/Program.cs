using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[2];
            args[0] = @"c:\Temp\inputB.txt";
            args[1] = @"c:\Temp\result.txt";
            string filename = args[0];
            var outputFileName = args[1];
            var lines = File.ReadAllText(filename);
            var input = InputParser.ParseInput(lines);
            var algorithm = SelectAlgorithm(input);
            var result = algorithm.Calc(input);
            var output = CreateOutput(result);
            var serialized = SerializeOutput(output);

            var scoreCalculator = new ScoreCalculator();

            var score = scoreCalculator.Calculate(input, result);
            Debug.WriteLine($"Score is {score}");

            DeliverOutput(serialized, outputFileName);
        }


        static IAlgorithm SelectAlgorithm(Input input)
        {
            return new AlgorithmC();
        }

        static Output CreateOutput(Result result)
        {
            return new Output
            {
                Result = result.RidesForAllVehicles.OrderBy(pair => pair.Key).Select(pair => pair.Value.RidesTaken.Select(ride => ride.Index).ToList()).ToList()
            };
        }

        static string SerializeOutput(Output output)
        {
            return output.Result.Select((list, index) => $"{list.Count} {list.Select(i => i.ToString()).Aggregate((a, b) => $"{a} {b}")}").Aggregate((a, b) => $"{a}\n{b}").TrimEnd();
        }

        static void DeliverOutput(string output, string path)
        {
            File.WriteAllText(path, output);
        }
    }
}
