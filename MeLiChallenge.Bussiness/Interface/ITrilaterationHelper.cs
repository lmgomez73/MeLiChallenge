using MeLiChallenge.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeLiChallenge.Business.Interface
{
    public interface ITrilaterationHelper
    {
        Point GetBidimensionalTrilateration(Point p1, Point p2, Point p3, double distance1, double distance2, double distance3);
    }
}
