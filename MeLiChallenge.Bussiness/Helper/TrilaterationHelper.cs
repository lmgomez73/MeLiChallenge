using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MeLiChallenge.Model;

namespace MeLiChallenge.Business.Helper
{
    //Based on http://repositoriodigital.uns.edu.ar/bitstream/123456789/4671/3/La%20matem%C3%A1tica%20detr%C3%A1s%20del%20GPS.pdf
    public class TrilaterationHelper
    {

        public Point GetBidimensionalTrilateration(Point p1, Point p2, Point p3, double distance1, double distance2, double distance3)
        {
            Point result = new Point();

            Point[][] intersections = new Point[3][];
            intersections[0] = GetIntersectionBetweenTwoPoints(p1, p2, distance1, distance2);
            intersections[1] = GetIntersectionBetweenTwoPoints(p1, p2, distance1, distance2);
            intersections[2] = GetIntersectionBetweenTwoPoints(p3, p2, distance3, distance2);

            if (!ValidateIntersections(intersections))
            {
                throw new Exception("Unable to get trilateration");
            }

            result = GetIntersectionsCoincidence(intersections);
            return result;
        }

        private Point GetIntersectionsCoincidence(Point[][] intersections)
        {
            //I use a dictionary to know wich is the most frequent Point
            Dictionary<Point, int> dic = new Dictionary<Point, int>();

            for (int i = 0; i < intersections.Length; i++)
            {
                for (int j = 0; j < intersections[i].Length; j++)
                {
                    var point = intersections[i][j];
                    if (dic.ContainsKey(point))
                    {
                        dic[point]++;
                    }
                    else
                    {
                        dic.Add(point, 1);
                    }
                }
            }
            Point result = dic.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            return result;
        }

        private bool ValidateIntersections(Point[][] intersections)
        {
            int count;
            foreach (var points in intersections)
            {
                count = 0;
                for (int i = 0; i < points.Length; i++)
                {
                    if (double.IsNaN(points[i].X) || double.IsNaN(points[i].Y))
                    {
                        count++;
                    }
                }
                if (count == points.Length)
                {
                    return false;
                }
            }
            return true;
        }


        // using d(P0,P1) = sqrt((x1 −x0)^2 + (y1 −y0)^2) formula
        public double GetDistanceFromTwoPoints(Point p1, Point p2)
        {
            double result;
            //getting information to use in formula
            double deltaX = p2.X - p1.X;
            double deltaY = p2.Y - p1.Y;

            double xPow = Math.Pow(deltaX, 2);
            double YPow = Math.Pow(deltaY, 2);

            result = Math.Sqrt(xPow + YPow);

            return result;
        }

        public Point[] GetIntersectionBetweenTwoPoints(Point p1, Point p2, double distance1, double distance2)
        {

            Point[] result = new Point[]
            {
            new Point(),
            new Point()
            };
            double totalDistance = GetDistanceFromTwoPoints(p1, p2);

            if (!ValidateDistances(totalDistance, distance1, distance2))
            {
                return result;
            }

            // Find a and h.
            double a = (distance1 * distance1 -
                distance2 * distance2 + totalDistance * totalDistance) / (2 * totalDistance);

            double h = Math.Sqrt(distance1 * distance1 - a * a);


            //Find p3
            Point p3 = new Point();

            p3.X = p1.X + a * (p2.X - p1.X) / totalDistance;
            p3.Y = p1.Y + a * (p2.Y - p1.Y) / totalDistance;

            //Get both intersections

            result[0].X = Math.Round(p3.X + h * (p2.Y - p1.Y) / totalDistance, 2);
            result[0].Y = Math.Round(p3.Y - h * (p2.X - p1.X) / totalDistance, 2);



            result[1].X = Math.Round(p3.X - h * (p2.Y - p1.Y) / totalDistance, 2);
            result[1].Y = Math.Round(p3.Y + h * (p2.X - p1.X) / totalDistance, 2);


            return result;
        }

        private bool ValidateDistances(double distance, double distance1, double distance2)
        {
            //if the distance between these 2 points is greater than the radious, the circles don't intersect.
            if (distance > distance1 + distance2)
            {
                return false;
            }

            //if the distance is less than the radious difference absolute value, then one circle contains the other one
            if (distance < Math.Abs(distance1 - distance2))
            {
                return false;
            }

            return true;
        }
    }
}
