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
            var input = CreateInput(args);
            var algorithm = ProvideAlgorithm(input);

            var result = algorithm.Calc(input);
            var output = CreateOutput(result);

            DeliverOutput(output);
        }

        static Input CreateInput(string[] args)
        {
            throw new NotImplementedException();
        }

        static IAlgorithm ProvideAlgorithm(Input input)
        {
            throw new NotImplementedException();
        }

        static Output CreateOutput(Result result)
        {
            throw new NotImplementedException();
        }

        static void DeliverOutput(Output output)
        {
            throw new NotImplementedException();
        }
    }
}
