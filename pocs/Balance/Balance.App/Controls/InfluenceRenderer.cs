﻿using Balance.Core.Extensions;
using Balance.Core.Models;

namespace Balance.App.Controls;

public class InfluenceRenderer
{
   public InfluenceRenderer(int borderSize)
   {
      _borderSize = borderSize;
   }

   private int PlayerCount => Enum.GetValues<Player>().ExcludeNone().Count();
   private readonly int _borderSize;

   public void Render(Graphics g, Rectangle clientRectangle, Influence influence)
   {
      using var rectPen = new Pen(Color.Black, _borderSize);
      g.DrawRectangle(rectPen,
         new Rectangle(_borderSize / 2, _borderSize / 2, clientRectangle.Width - _borderSize, clientRectangle.Height - _borderSize));

      var rectWidth = ((float)clientRectangle.Width - _borderSize * 2) / PlayerCount;
      var height = ((float)clientRectangle.Height - _borderSize * 2);
      int offset = 0;
      foreach (var player in Enum.GetValues<Player>().ExcludeNone())
      {
         var pct = influence.GetPercentage(player);

         var rect = new RectangleF(
            _borderSize + (rectWidth * offset),
            _borderSize + height - (height * pct),
            rectWidth,
            height * pct);

         using var playerBrush = new SolidBrush(Globals.PlayerContext.GetPlayerColor(player));
         g.FillRectangle(playerBrush, rect);

         offset++;
      }
   }
}
