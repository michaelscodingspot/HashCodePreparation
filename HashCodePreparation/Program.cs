using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePreparation
{
    class Program   
    {
        static void Main(string[] args)
        {
            //var input = ParseInput(args);
            //var input = CreateFakeInput();

            var input = MockData();

            var algorithm = new Algorithm();//SelectAlgorithm(input);

            var result = algorithm.Calc(input);
            //var output = CreateOutput(result);

            //var text = SerializeOutput(output);
            //DeliverOutput(text);
        }

        private static Input MockData()
        {
            return new Input()
            {
                Bonus = 2,
                Columens = 4,
                Rows = 3,
                RideNumber = 3,
                Steps = 10,
                Vehicales = 2,
                Rides = new List<Ride>()
                {
                    new Ride(0, 0, 1, 3, 2, 9, 0),
                    new Ride(1,2,1,0, 0, 9, 1),
                    new Ride(2,0,2,2, 0, 9, 2),
                }
            };
        }

        static Input ParseInput(string[] args)
        {
            throw new NotImplementedException();
        }

        static IAlgorithm SelectAlgorithm(Input input)
        {
            throw new NotImplementedException();
        }


        static Output CreateOutput(Result result)
        {
            throw new NotImplementedException();
        }

        static string SerializeOutput(Output output)
        {
            throw new NotImplementedException();
        }

        static void DeliverOutput(string output)
        {
            throw new NotImplementedException();
        }

        // Mocking
        static Input CreateFakeInput()
        {
            throw new NotImplementedException();
        }
    }
}
