using Balance.Core.Models;

namespace Balance.App.CustomEventArgs;

public class MouseCoordinateEventArgs : EventArgs
{
   public MouseCoordinateEventArgs(RealmTile tile)
   {
      Tile = tile;
   }

   public RealmTile Tile { get; }
}

