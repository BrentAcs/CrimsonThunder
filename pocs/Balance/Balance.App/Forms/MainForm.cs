using System.Diagnostics;
using Balance.App.Controls;
using Balance.App.CustomEventArgs;
using Balance.Core.Models;
using Balance.Core.Services;

namespace Balance.App.Forms;

public partial class MainForm : Form
{
   private RealmTileMap? _map;
   private RealmTileToolTip _tileToolTip = new();

   public MainForm()
   {
      InitializeComponent();
   }

   protected override void OnLoad(EventArgs e)
   {
      base.OnLoad(e);
      DoubleBuffered = true;
   }

   private void MainForm_Load(object sender, EventArgs e)
   {
      Location = UserSettings.Default.MainForm_Location;
      Size = UserSettings.Default.MainForm_Size;

      _map = Globals.MapFactory.Create(RealmTileMapFactory.Options.Medium);
      Globals.MapPopulator.Populate(_map, new IRealmTileMapPopulator.Options());

      theMapView.Map = _map;
      totalInfluenceView.Influence = _map.Influence;
   }

   private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
   {
      UserSettings.Default.MainForm_Location = Location;
      UserSettings.Default.MainForm_Size = Size;
   }

   private void TheMapViewMouseIndicateOverCoordinate(object sender, MouseCoordinateEventArgs e)
   {
      Debug.WriteLine($"{nameof(TheMapViewMouseIndicateOverCoordinate)}: {e.Tile.Coordinate}");
      theRealmTileInfoView.SetTileInfo(e.Tile);
   }

   private void theMapView_MouseClearOverCoordinate(object sender, EventArgs e)
   {
      Debug.WriteLine($"{nameof(theMapView_MouseClearOverCoordinate)}");
      theRealmTileInfoView.SetTileInfo(null);
   }
}
