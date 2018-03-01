using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePreparation
{
    public class RidesForVehicle
    {
        public List<Ride> RidesTaken;
    }

    public class Result
    {
        public Dictionary<int, RidesForVehicle> RidesForAllVehicles { get; set; } = new Dictionary<int, RidesForVehicle>();
    }
}
