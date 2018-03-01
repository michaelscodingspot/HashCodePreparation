using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePreparation
{
    public class AlgorithmC : IAlgorithm
    {
        private const int AHEAD = 2;
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
            return GetBestRidesInternal(iVehicle, rides);
        }

        private IEnumerable<Ride> GetBestRidesInternal(int iVehicle, List<Ride> rides)
        {
            int time = 0;
            int x = 0;
            int y = 0;
            while(time < _input.Steps)
            {
                //Ride ride = GetBestRide(time, y, x, rides, out int arrival);
                List<List<Ride>> possibleRides = GetAllPossibleRidesSet(iVehicle, time, x, y, rides, AHEAD);

                if (possibleRides.Count == 0)
                    yield break;
                var bestScore = 0d;
                var bestScoreIndex = 0;
                int index = 0;
                foreach (var possibleRideSet in possibleRides)
                {
                    double curScore = 0;
                    int curX = x;
                    int curY = y;
                    int curTime = time;
                    foreach (var ride1 in possibleRideSet)
                    {
                        int distanceToFrom1 = Math.Abs(ride1.RideFrom.X - curX) + Math.Abs(ride1.RideFrom.Y - y);
                        int rideLength1 = Math.Abs(ride1.RideFrom.X - ride1.RideTo.X) + Math.Abs(ride1.RideFrom.Y - ride1.RideTo.Y);
                        var arrival1 = Math.Max(curTime + distanceToFrom1, ride1.EarliestStart) + rideLength1;

                        bool isBonus = time + distanceToFrom1 <= ride1.EarliestStart;
                        int bonus = isBonus ? _input.Bonus : 0;

                        double actualScore = (double)(bonus + rideLength1);
                        double score1 = (actualScore / (double)(arrival1 - curTime));
                        curScore += score1;
                        curTime = arrival1;
                    }

                    if (curScore > bestScore)
                    {
                        bestScoreIndex = index;
                        bestScore = curScore;
                    }
                    index++;
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


                int distanceToFrom = Math.Abs(ride.RideFrom.X - x) + Math.Abs(ride.RideFrom.Y - y);
                int rideLength = Math.Abs(ride.RideFrom.X - ride.RideTo.X) + Math.Abs(ride.RideFrom.Y - ride.RideTo.Y);
                var arrival = Math.Max(time + distanceToFrom, ride.EarliestStart) + rideLength;


                x = ride.RideTo.X;
                y = ride.RideTo.Y;

                time += arrival;
            }
        }

        private List<List<Ride>> GetAllPossibleRidesSet(int iVehicle, int time, int x, int y, List<Ride> rides, int numOfRidesAhead)
        {
            List<List<Ride>> res = new List<List<Ride>>();
            if (numOfRidesAhead == 0)
            {
                return res;
            }
            var curRes = new List<Ride>();
            foreach (var ride in rides)
            {
                int distanceToFrom = Math.Abs(ride.RideFrom.X - x) + Math.Abs(ride.RideFrom.Y - y);
                int rideLength = Math.Abs(ride.RideFrom.X - ride.RideTo.X) + Math.Abs(ride.RideFrom.Y - ride.RideTo.Y);//TODO Maybe cache

                bool canMakeIt = time + distanceToFrom + rideLength < ride.LatestFinish;
                if (!canMakeIt)
                    continue;

                curRes.Add(ride);

                var newX = ride.RideTo.X;
                var newY = ride.RideTo.Y;
                var newRides = new List<Ride>(rides);
                newRides.Remove(ride);
                var arrival = Math.Max(time + distanceToFrom, ride.EarliestStart) + rideLength;

                var moreWithThis = GetAllPossibleRidesSet(iVehicle, arrival, newX, newY, newRides, numOfRidesAhead - 1);

                if (moreWithThis.Count == 0)
                {
                    var currRideList = new List<Ride>() { ride };
                    res.Add(currRideList);
                }
                foreach (var item in moreWithThis)
                {
                    var currRideList = new List<Ride>() { ride };
                    res.Add(currRideList.Concat(item).ToList());
                }

            }

            return res;
        }

        //private List<Ride> GetPossibleRides(int time, int y, int x, List<Ride> rides)
        //{
        //    throw new NotImplementedException();
        //}

        //private Ride GetBestRide(int time, int x, int y, List<Ride> rides, out int arrival)
        //{
        //    arrival = 0;
        //    if (rides.Count == 0)
        //        return null;
        //    Ride result = null;//rides.FirstOrDefault();
        //    double score = 0;
        //    foreach (var ride in rides)
        //    {
        //        int distanceToFrom = Math.Abs(ride.RideFrom.X - x) + Math.Abs(ride.RideFrom.Y - y);
        //        int rideLength = Math.Abs(ride.RideFrom.X - ride.RideTo.X) + Math.Abs(ride.RideFrom.Y - ride.RideTo.Y);//TODO Maybe cache

        //        bool canMakeIt = time + distanceToFrom + rideLength < ride.LatestFinish;
        //        if (!canMakeIt)
        //            continue;

        //        bool isBonus = time + distanceToFrom <= ride.EarliestStart;
        //        int bonus = isBonus ? _input.Bonus : 0;
        //        //int score = bonus + 
        //        double actualScore = (double)(bonus + rideLength);
        //        var arrival1 = Math.Max(time + distanceToFrom, ride.EarliestStart) + rideLength;
        //        double score1 = (actualScore / (double)(arrival1 - time));
        //        if (score1 > score)
        //        {
        //            score = score1;
        //            result = ride;
        //            arrival = arrival1;
        //        }

        //    }
        //    return result;
        //}
    }
}
