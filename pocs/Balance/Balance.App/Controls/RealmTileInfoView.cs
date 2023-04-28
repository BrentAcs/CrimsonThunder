using Balance.Core.Models;

namespace Balance.App.Controls;

public partial class RealmTileInfoView : UserControl
{
   private RealmTile? _current;

   public RealmTileInfoView()
   {
      InitializeComponent();
   }

   public void SetTileInfo(RealmTile? tile)
   {
      if (tile is null)
      {
         realmTypeTextBox.Text = string.Empty;
         locationTextBox.Text = string.Empty;
         theInfluenceView.Influence = new Influence();
         return;
      }

      if (tile == _current)
         return;

      realmTypeTextBox.Text = tile.RealmType.ToString();
      locationTextBox.Text = $"{tile.Coordinate.Col}, {tile.Coordinate.Row}";
      theInfluenceView.Influence = tile.Influence;

      _current = tile;
   }
}
