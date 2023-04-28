using Balance.Core.Extensions;
using Balance.Core.Models;

namespace Balance.App.Renders;

public class InfluenceRenderer : Renderer
{
   public InfluenceRenderer(int borderSize)
   {
      _borderSize = borderSize;
   }

   private readonly int _borderSize;

   public void Render(Graphics g, Rectangle clientRectangle, Influence influence)
   {
      using var rectPen = new Pen(Color.Black, _borderSize);
      g.DrawRectangle(rectPen,
         new Rectangle(_borderSize / 2, _borderSize / 2, clientRectangle.Width - _borderSize, clientRectangle.Height - _borderSize));

      var rectWidth = ((float)clientRectangle.Width - _borderSize * 2) / PlayerCount;
      var height = (float)clientRectangle.Height - _borderSize * 2;
      int offset = 0;
      foreach (var player in Enum.GetValues<Player>().OnboardOnly())
      {
         var pct = influence.GetPercentage(player);

         var rect = new RectangleF(
            clientRectangle.X + _borderSize + rectWidth * offset,
            clientRectangle.Y + _borderSize + height - height * pct,
            rectWidth,
            height * pct);

         using var playerBrush = new SolidBrush(Globals.PlayerContext.GetPlayerColor(player));
         g.FillRectangle(playerBrush, rect);

         using var textBrush = new SolidBrush(Color.Black);
         using var font = new Font("Arial", 8);
         var text = $"{pct:P}";
         var textSize = g.MeasureString(text, font);
         var textRect = new RectangleF(rect.X + (rect.Width - textSize.Width) / 2, rect.Bottom - textSize.Height, rect.Width, textSize.Height);
         g.DrawString(text, font, textBrush, textRect);

         offset++;
      }
   }
}
