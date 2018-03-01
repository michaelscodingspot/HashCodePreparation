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
            //args = new string[]
            //{
            //    "3 4 2 3 2 10",
            //    "0 0 1 3 2 9",
            //    "1 2 1 0 0 9",
            //    "2 0 2 2 0 9",
            //};

            var lines = File.ReadAllText(@"C:\Users\moaid\Downloads\c_no_hurry.in");
            //string inputLines = string.Join("\n", lines);

            var input = InputParser.ParseInput(lines);
            //var input = CreateFakeInput();

            //var input = MockData();

            var algorithm = SelectAlgorithm(input);
            var result = algorithm.Calc(input);

            var output = CreateOutput(result);

            var text = SerializeOutput(output);
            DeliverOutput(text);
        }



        //private static Input MockData()
        //{
        //    return new Input()
        //    {
        //        Bonus = 2,
        //        Columens = 4,
        //        Rows = 3,
        //        RideNumber = 3,
        //        Steps = 10,
        //        Vehicales = 2,
        //        Rides = new List<Ride>()
        //        {
        //            new Ride(0, 0, 1, 3, 2, 9, 0),
        //            new Ride(1,2,1,0, 0, 9, 1),
        //            new Ride(2,0,2,2, 0, 9, 2),
        //        }
        //    };
        //}

        
        static IAlgorithm SelectAlgorithm(Input input)
        {
            return new Algorithm();
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
            return output.Result.Select(list => list.Select(i => i.ToString()).Aggregate((a, b) => $"{a} {b}")).Aggregate((a, b) => $"{a}\n{b}").TrimEnd();
        }

        static void DeliverOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}
