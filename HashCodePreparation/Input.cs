using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePreparation
{

    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Ride
    {
        public Ride(int xFrom, int yFrom, int xTo, int yTo, int earliestStart, int latestFinish)
        {
            RideFrom = new Point(xFrom, yFrom);
            RideTo = new Point(xTo, yTo);
            EarliestStart = earliestStart;
            LatestFinish = latestFinish;
        }
        public Point RideFrom { get; set; }
        public Point RideTo { get; set; }
        public int EarliestStart { get; set; }
        public int LatestFinish { get; set; }

    }
    public class Input
    {
        public Input(int rows, int columens, int vehicales, int rideNumber, int bonus, int steps, List<Ride> Rides)
        {

        }
        public int Rows { get; set; }
        public int Columens { get; set; }
        public int Vehicales { get; set; }
        public int RideNumber { get; set; }
        public int Bonus { get; set; }
        public int Steps { get; set; }
        public List<Ride> Rides { get; set; }
    }

}
