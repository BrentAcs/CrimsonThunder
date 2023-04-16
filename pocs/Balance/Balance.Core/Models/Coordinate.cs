using System.Diagnostics;

namespace Balance.Core.Models;

[DebuggerDisplay("Col: {Col}, Row: {Row}")]
public record Coordinate(int Col, int Row)
{
   public static readonly Coordinate Empty = new Coordinate(0, 0);
   public static readonly Coordinate OffMap = new(-1, -1);

   //public bool IsOnMap => !Col.IsNegative() && !Row.IsNegative();
   //public bool IsOffMap => Col.IsNegative() && Row.IsNegative();
}
