using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePreparation
{
    public class Algorithm : IAlgorithm
    {
        private Input _input;

        public Result Calc(Input input)
        {
            _input = input;
            var allRides = new List<Ride>(input.Rides);
            Result result = new Result();
            for (int iVehicle = 0; iVehicle < input.Vehicales; iVehicle++)
            {
                List<Ride> rides = GetBestRides(iVehicle, allRides).ToList();
                foreach (var ride in rides)
                {
                    allRides.Remove(ride);
                }
                result.RidesForAllVehicles.Add(iVehicle, new RidesForVehicle()
                    { RidesTaken = rides});
            }


            return result;
        }

        private IEnumerable<Ride> GetBestRides(int iVehicle, List<Ride> rides)
        {
            int time = 0;
            int x = 0;
            int y = 0;
            while(time < _input.Steps)
            {
                Ride ride = GetBestRide(time, y, x, rides, out int arrival);
                if (ride == null)
                    yield break;
                yield return ride;
                x = ride.RideTo.X;
                y = ride.RideTo.Y;
                time += arrival;
            }
        }

        private Ride GetBestRide(int time, int x, int y, List<Ride> rides, out int arrival)
        {
            arrival = 0;
            if (rides.Count == 0)
                return null;
            Ride result = null;
            int closestDistance = 1000000;
            foreach (var ride in rides)
            {
                int distanceToFrom = Math.Abs(ride.RideFrom.X - x) + Math.Abs(ride.RideFrom.Y - y);
                int rideLength = Math.Abs(ride.RideFrom.X - ride.RideTo.X) + Math.Abs(ride.RideFrom.Y - ride.RideTo.Y);//TODO Maybe cache

                bool canMakeIt = time + distanceToFrom + rideLength < ride.LatestFinish;
                if (!canMakeIt)
                    continue;

                bool isBonus = time + distanceToFrom <= ride.EarliestStart;
                int bonus = isBonus ? _input.Bonus : 0;
                var closestDistance1 = distanceToFrom;
                if (closestDistance1 < closestDistance)
                {
                    closestDistance = closestDistance1;
                    result = ride;
                    arrival = time + distanceToFrom + rideLength;
                }

            }
            return result;
        }
    }
}
