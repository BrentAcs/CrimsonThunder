using Balance.Core.Models;

namespace Balance.App.Controls;

public class MouseCoordinateEventArgs : EventArgs
{
   public MouseCoordinateEventArgs(Coordinate coordinate)
   {
      Coordinate = coordinate;
   }

   public Coordinate Coordinate { get; }
}
