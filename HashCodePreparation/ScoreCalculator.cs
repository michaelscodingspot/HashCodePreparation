using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePreparation
{
    public class ScoreCalculator
    {
        public ScoreCalculator()
        {
            
        }

        public long Calculate(Input input, Result result)
        {
            var score = 0L;

            foreach (var pair in result.RidesForAllVehicles)
            {
                var car = pair.Key;
                var rides = pair.Value.RidesTaken;

                (int, int) position = (0, 0);

                int step = 0;

                var carScore = 0L;

                foreach (var ride in rides)
                {
                    var distance = Distance(ride, position);

                    if (0 < distance)
                    {
                        step += distance;
                    }

                    if (step == ride.EarliestStart)
                    {
                        carScore += input.Bonus;
                    }
                    else
                    {
                        step += Math.Abs(ride.EarliestStart - step);
                    }

                    var rideDistance = 
                    step += Distance(ride.RideFrom, ride.RideTo);

                    if (step <= input.Steps)
                    {
                        carScore += 
                    }
                }

                score += carScore;
            }

            return score;
        }

        public int Distance(Ride ride, (int x, int y) car)
        {
            return Math.Abs(ride.RideFrom.X - car.x) + Math.Abs(ride.RideFrom.Y - car.y);
        }

        public int Distance(Point p1, Point p2)
        {
            return Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
        }
    }
}
