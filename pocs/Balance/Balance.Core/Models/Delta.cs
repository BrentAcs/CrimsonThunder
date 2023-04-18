using System.Diagnostics;

namespace Balance.Core.Models;

[DebuggerDisplay("X: {X}, Row: {Y}")]
public record Delta(int X, int Y)
{
   public Delta Offset(Delta delta) => new(X + delta.X, Y + delta.Y);
}
