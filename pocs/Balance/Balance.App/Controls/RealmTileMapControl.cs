using System.Diagnostics.Contracts;
using System.Globalization;
using System.Windows.Forms;
using Balance.Core.Models;

namespace Balance.App.Controls;

public partial class RealmTileMapControl : UserControl
{
   private RealmTileMap _map;

   public RealmTileMapControl()
   {
      InitializeComponent();
   }

   public void Initialize(RealmTileMap realmTileMap)
   {
      _map = realmTileMap;
      scaleFactorTextBox.Text = Globals.MapViewState.ScaleFactor.ToString(CultureInfo.InvariantCulture);
      RefreshControls();
   }

   private void ZoomControls(double delta)
   {
      if (!double.TryParse(scaleFactorTextBox.Text, out var scale))
         return;

      scale += delta;
      scaleFactorTextBox.Text = scale.ToString();
      RefreshControls(scale);
   }

   private void RefreshControls(double scale = 100.0)
   {
      scaleFactorTextBox.Text = scale.ToString();
      var controls = GenerateControls(scale);
      SuspendLayout();
      tilesPanel.Controls.Clear();
      foreach (var control in controls)
      {
         tilesPanel.Controls.Add(control);
      }
      ResumeLayout();
   }

   private const int SideLength = 11;

   private IEnumerable<Control> GenerateControls(double scale = 100.0)
   {
      var controls = new List<RealmTileControl>();
      var scaleFactor = scale / 100.0;
      var baseTileSize = Globals.TileRenderer.MapTileSize;
      var tileSize = new Size((int)(baseTileSize.Width * scaleFactor), (int)(baseTileSize.Height * scaleFactor));

      for (int col = 0; col < _map.Width; col++)
      {
         for (int row = 0; row < _map.Height; row++)
         {
            var control = CreateTileControl(col, row);
            control.Location = new Point(col * tileSize.Width, row * tileSize.Height);
            control.Size = tileSize;

            controls.Add(control);
         }
      }

      return controls;
   }

   private RealmTileControl CreateTileControl(int col, int row) => CreateTileControl(new Coordinate(col, row));

   private RealmTileControl CreateTileControl(Coordinate coordinate)
   {
      if (_map.IsNexusRealm(coordinate))
      {
         return new NexusRealmTileControl();
      }

      if (_map.IsBorderRealm(coordinate))
      {
         return new BorderRealmTileControl();
      }

      var control = new RealmTileControl();
      return control;
   }

   private void zoomInButton_Click(object sender, EventArgs e) => ZoomControls(10);

   private void zoomOutButton_Click(object sender, EventArgs e) => ZoomControls(-10);
}
