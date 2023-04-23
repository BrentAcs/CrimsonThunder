using Balance.Core.Extensions;
using Balance.Core.Models;

namespace Balance.App.Controls;

public partial class InfluenceView : UserControl
{
   public InfluenceView()
   {
      InitializeComponent();
   }

   public Influence? Influence { get; set; }

   private Influence InfluenceInternal => Influence ?? new Influence(25, 0, 50, 100);
   private int PlayerCount => Enum.GetValues<Player>().ExcludeNone().Count();

   private int BorderSize = 2;

   protected override void OnPaint(PaintEventArgs e)
   {
      var g = e.Graphics;

      using var rectPen = new Pen(Color.Black, BorderSize);
      g.DrawRectangle(rectPen,
         new Rectangle(BorderSize / 2, BorderSize / 2, ClientRectangle.Width - BorderSize, ClientRectangle.Height - BorderSize));

      var rectWidth = ((float)ClientRectangle.Width - BorderSize * 2) / PlayerCount;
      var height = ((float)ClientRectangle.Height - BorderSize * 2);
      int offset = 0;
      foreach (var player in Enum.GetValues<Player>().ExcludeNone())
      {
         var pct = InfluenceInternal.GetPercentage(player);

         var rect = new RectangleF(
            BorderSize + (rectWidth * offset),
            BorderSize + height - (height * pct),
            rectWidth,
            height * pct);

         using var playerBrush = new SolidBrush(Globals.PlayerContext.GetPlayerColor(player));
         g.FillRectangle(playerBrush, rect);

         offset++;
      }

      base.OnPaint(e);
   }
}
