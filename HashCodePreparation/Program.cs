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
            var input = ParseInput(args);
            var algorithm = SelectAlgorithm(input);

            var result = algorithm.Calc(input);
            var output = CreateOutput(result);

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
    }
}
