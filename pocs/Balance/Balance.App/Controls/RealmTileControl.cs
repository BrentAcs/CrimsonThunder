using System;
using Balance.App.Extensions;
using Balance.Core.Models;

namespace Balance.App.Controls;

public partial class RealmTileControl : UserControl, IObserver<RealmTile>
{
   private RealmTile? _tile;

   public RealmTileControl()
   {
      InitializeComponent();
   }

   public RealmTile? Tile
   {
      get => _tile;
      set
      {
         _tile = value ?? throw new ArgumentNullException(nameof(value));
         _tile.Subscribe(this);
         influenceLabel.Text = $@"{_tile.Influence.GetAmount(Player.One)}-{_tile.Influence.GetAmount(Player.Two)}-{_tile.Influence.GetAmount(Player.Three)}-{_tile.Influence.GetAmount(Player.Four)}";
      }
   }

   protected virtual Color RealmBackColor => Color.White;

   protected override void OnCreateControl()
   {
      //BackColor = RealmBackColor;
      base.OnCreateControl();
   }

   private void RealmTileControl_Paint(object sender, PaintEventArgs e)
   {
      var g = e.Graphics;
      var rect = new Rectangle(Point.Empty, ClientSize);
      using var pen = new Pen(Color.Black, Globals.TileRenderer.BorderSize);
      g.DrawRoundedRectangle(pen, rect, Globals.TileRenderer.BorderSize);
   }

   public void OnCompleted() { }

   public void OnError(Exception error) { }

   public void OnNext(RealmTile value)
   {
      influenceLabel.Text = $@"{_tile.Influence.GetAmount(Player.One)}-{_tile.Influence.GetAmount(Player.Two)}-{_tile.Influence.GetAmount(Player.Three)}-{_tile.Influence.GetAmount(Player.Four)}";
   }
}

public class NexusRealmTileControl : RealmTileControl
{
   protected override Color RealmBackColor => Color.DarkSlateGray;
}

public class BorderRealmTileControl : RealmTileControl
{
   protected override Color RealmBackColor => Color.DimGray;
}

public class StandardRealmTileControl : RealmTileControl
{
   protected override Color RealmBackColor => Color.DimGray;
}

public class PlayerRealmTileControl : RealmTileControl
{
   protected override Color RealmBackColor => Globals.PlayerContext.GetPlayerColor(Tile.Owner);
}

