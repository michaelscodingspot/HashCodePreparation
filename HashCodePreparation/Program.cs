using System;
using System.Collections.Generic;
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
            string filename = args[0];
            var lines = File.ReadAllText(filename);
            var input = InputParser.ParseInput(lines);
            var algorithm = SelectAlgorithm(input);
            var result = algorithm.Calc(input);
            var output = CreateOutput(result);
            var serialized = SerializeOutput(output);
            DeliverOutput(serialized, Path.Combine(Path.GetDirectoryName(filename), "result.txt"));
        }


        static IAlgorithm SelectAlgorithm(Input input)
        {
            return new AlgorithmB();
        }

        static Output CreateOutput(Result result)
        {
            return new Output
            {
                Result = result.RidesForAllVehicles.OrderBy(pair => pair.Key).Select(pair => pair.Value.RidesTaken.Select(ride => ride.Index + 1).ToList()).ToList()
            };
        }

        static string SerializeOutput(Output output)
        {
            return output.Result.Select((list, index) => $"{index} {list.Select(i => i.ToString()).Aggregate((a, b) => $"{a} {b}")}").Aggregate((a, b) => $"{a}\n{b}").TrimEnd();
        }

        static void DeliverOutput(string output, string path)
        {
            File.WriteAllText(path, output);
        }
    }
}
