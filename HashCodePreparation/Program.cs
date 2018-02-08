using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashCodePreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputModel = new Input();
            var inputFile = @"c:\temp\input.txt";
            var lines = File.ReadAllLines(inputFile);

            var splittedLines = lines.Take(3).Select(l => l.Split(' ')).ToList();
            var numMovies = int.Parse(splittedLines[0][0]);
            var numEndpoints = int.Parse(splittedLines[0][1]);
            var numRequests = int.Parse(splittedLines[0][2]);
            var numCaches = int.Parse(splittedLines[0][3]);
            int cacheSize = int.Parse(splittedLines[0][4]);
            inputModel.Movies = new int[numMovies];
            for (int i = 0; i < splittedLines[1].Length; i++)
            {
                inputModel.Movies[i] = int.Parse(splittedLines[1][i]);
            }
            inputModel.Endpoints = new Endpoint[numEndpoints];
            inputModel.Requests = new Request[numRequests];
            inputModel.CacheCenterSize = cacheSize;
            inputModel.NumOfCacheCenters = numCaches;
            int lineIndex = 1;
            for (int i = 0; i < numEndpoints; i++)
            {
                var split = lines[++lineIndex].Split(' ');
                var endpoint = i;
                var dataCenterLatency = int.Parse(split[0]);
                int numCachesForEndpoints = int.Parse(split[1]);
                for (int j = 0; j < numCachesForEndpoints; j++)
                {
                    var currentLineSplitted = lines[++lineIndex].Split(' ');
                    var cache = int.Parse(currentLineSplitted[0]);
                    var latancy = int.Parse(currentLineSplitted[1]);
                    inputModel.Endpoints[endpoint] =
                        new Endpoint
                        {
                            LantencyToDataCenter = dataCenterLatency,
                            LantencyToCacheCenter = new Dictionary<int, int> { { cache, latancy } }
                        };
                }
            }

            lineIndex++;
            for (int i = lineIndex, j = 0; i < lines.Length; i++, j++)
            {
                var splittesRequestsDesc = lines[i].Split(' ');
                var video = int.Parse(splittesRequestsDesc[0]);
                var endpoint = int.Parse(splittesRequestsDesc[1]);
                var requests = int.Parse(splittesRequestsDesc[2]);
                inputModel.Requests[j] = new Request { NumEndpoint = endpoint, NumVideo = video, NumRequests = requests };
            }
        }
    }
}
