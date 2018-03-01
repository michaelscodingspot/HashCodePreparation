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
            ////var input = CreateFakeInput();

            //var algorithm = SelectAlgorithm(input);

            //var result = algorithm.Calc(input);
            var output = CreateOutput(null);

            var text = SerializeOutput(output);
            DeliverOutput(text);
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
            return new Output
            {
                Result = new List<List<int>>
                {
                    new List<int>{ 1, 0},
                    new List<int>{ 2, 2, 1}
                }
            };
        }

        static string SerializeOutput(Output output)
        {
            return output.Result.Select(list => list.Select(i => i.ToString()).Aggregate((a, b) => $"{a} {b}")).Aggregate((a, b) => $"{a}\n{b}");
        }

        static void DeliverOutput(string output)
        {
            Console.WriteLine(output);
        }

        // Mocking
        static Input CreateFakeInput()
        {
            throw new NotImplementedException();
        }
    }
}
