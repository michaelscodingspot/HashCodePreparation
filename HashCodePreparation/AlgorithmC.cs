using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePreparation
{
    public class AlgorithmC : IAlgorithm
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
            return GetBestRidesInternal(iVehicle, rides, _input.Steps);
        }

        private IEnumerable<Ride> GetBestRidesInternal(int iVehicle, List<Ride> rides)
        {
            int time = 0;
            int x = 0;
            int y = 0;
            while(time < _input.Steps)
            {
                //Ride ride = GetBestRide(time, y, x, rides, out int arrival);
                List<List<Ride>> possibleRides = GetAllPossibleRidesSet(iVehicle, time, x, y, rides, 3);
                var bestScore = 0;
                var bestScoreIndex = 0;
                foreach (var possibleRideSet in possibleRides)
                {

                }
                var bestSet = possibleRides[bestScoreIndex];

                var ride = bestSet.Count == 0 ? null : bestSet[0];
                //var scoring = GetBestScoring()
                //foreach (var ride in rides)
                //{
                    
                //    foreach (var possibleRide in possibleRides)
                //    {
                //        var ridesSoFar = new List<Ride>(rides);
                //        ridesSoFar.Remove(possibleRide);
                //        var 
                //    }
                //}


                if (ride == null)
                    yield break;
                yield return ride;
                x = ride.RideTo.X;
                y = ride.RideTo.Y;
                time += arrival;
            }
        }

        private List<List<Ride>> GetAllPossibleRidesSet(int iVehicle, int time, int x, int y, List<Ride> rides, int numOfRidesAhead)
        {
            throw new NotImplementedException();
        }

        private List<Ride> GetPossibleRides(int time, int y, int x, List<Ride> rides)
        {
            throw new NotImplementedException();
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
