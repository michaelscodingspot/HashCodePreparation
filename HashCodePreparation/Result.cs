using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePreparation
{
    public class Result
    {
        //index is cache center. Value is list of video indexes
        public Dictionary<int, List<int>> Data { get; set; }
    }
}
