using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePreparation
{
    public class AlgorithmB : IAlgorithm
    {
        private Input _input;

        

        public Result Calc(Input input)
        {
            _input = input;
            var allRides = new List<Ride>(input.Rides);

            //var allRides = input.Rides.OrderBy(r => r.EarliestStart).ToList();

            Result result = new Result();
            //var allRides = input.Rides.ToDictionary(ride => ride.)
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
                rides.Remove(ride);
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
            Ride result = null;//rides.FirstOrDefault();
            double score = 0;
            foreach (var ride in rides)
            {
                int distanceToFrom = Math.Abs(ride.RideFrom.X - x) + Math.Abs(ride.RideFrom.Y - y);
                int rideLength = Math.Abs(ride.RideFrom.X - ride.RideTo.X) + Math.Abs(ride.RideFrom.Y - ride.RideTo.Y);//TODO Maybe cache

                bool canMakeIt = time + distanceToFrom + rideLength < ride.LatestFinish;
                if (!canMakeIt)
                    continue;

                bool isBonus = time + distanceToFrom <= ride.EarliestStart;
                int bonus = isBonus ? _input.Bonus : 0;
                //int score = bonus + 
                double actualScore = (double)(bonus + rideLength);
                var arrival1 = Math.Max(time + distanceToFrom, ride.EarliestStart) + rideLength;
                double score1 = (actualScore / (double)(arrival1 - time));
                if (score1 > score)
                {
                    score = score1;
                    result = ride;
                    arrival = arrival1;
                }

            }
            return result;
        }
    }
}
