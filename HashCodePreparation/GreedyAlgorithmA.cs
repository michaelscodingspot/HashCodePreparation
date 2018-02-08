using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePreparation
{
    public class GreedyAlgorithmA : IAlgorithm
    {

        
        //Key is KVP with first item CACHE CENTER, 2nd is Video
        //value is saves / MB 
        Dictionary<KeyValuePair<int, int>, double> _saves = new Dictionary<KeyValuePair<int, int>, double>();
        private Input _input;

        public Result Calc(Input input)
        {
            _input = input;
            //Step 1: calc permutation from cache & video as key to benefit / MB
            FillSaves();
        }

        private void FillSaves()
        {
            for (int iMovie = 0; iMovie < _input.Movies.Length; iMovie++)
            {
                for (int iCacheCenter = 0; iCacheCenter < _input.NumOfCacheCenters; iCacheCenter++)
                {
                    var key = new KeyValuePair<int, int>(iCacheCenter, iMovie);
                    double totalSaved = 0;
                    foreach (var request in _input.Requests)
                    {
                        if (request.NumVideo == iMovie 
                            && _input.Endpoints[request.NumEndpoint].LantencyToCacheCenter.ContainsKey(iCacheCenter))
                        {
                            var lagToCacheCenter = _input.Endpoints[request.NumEndpoint].LantencyToCacheCenter[iCacheCenter];
                            var lagToDataCenter = _input.Endpoints[request.NumEndpoint].LantencyToDataCenter;
                            var savedTime = lagToDataCenter - lagToCacheCenter;
                            totalSaved += savedTime * request.NumRequests;
                        }
                    }
                    var value = totalSaved / _input.Movies[iMovie];

                    _saves.Add(key, value);

                }

            }
        }
    }
}
