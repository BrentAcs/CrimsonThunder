using Balance.Core.Models;

namespace Balance.Core.Extensions;

public static class CoordinateExtensions
{
   public static Coordinate Offset(this Coordinate coordinate, Delta delta) => new(coordinate.Col + delta.X, coordinate.Row + delta.Y);
}
