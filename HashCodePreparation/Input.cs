using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePreparation
{
    public class Endpoint
    {
        public int LantencyToDataCenter { get; set; }
        public Dictionary<int, int> LantencyToCacheCenter { get; set; }//index is cache center, value is lantency
    }

    public class Request
    {
        public int NumRequests { get; set; }
        public int NumVideo { get; set; }
        public int NumEndpoint { get; set; }
    }

    public class Input
    {
        public int[] Movies { get; set; }//index is movie number, size is value
        public int NumOfCacheCenters { get; set; }
        public int CacheCenterSize { get; set; }
        public Endpoint[] Endpoints { get; set; }
        public Request[] Requests { get; set; }

    }
}
