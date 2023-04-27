using System.Diagnostics;
using Balance.App.Controls;
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

      _map = Globals.MapFactory.Create(RealmTileMapFactory.Options.ExtraLarge);
      Globals.MapPopulator.Populate(_map, new IRealmTileMapPopulator.Options());

      theMapView.Map = _map;
      //theMapControl.Initialize(_map);
      totalInfluenceView.Influence = _map.Influence;
      //_tileToolTip.SetToolTip(theMapView.MapPanel, "boobs");
   }

   private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
   {
      UserSettings.Default.MainForm_Location = Location;
      UserSettings.Default.MainForm_Size = Size;
   }

   private void TheMapViewMouseSetOverCoordinate(object sender, MouseCoordinateEventArgs e)
   {
      Debug.WriteLine($"{nameof(TheMapViewMouseSetOverCoordinate)}: {e.Coordinate}");
      tileInfluenceView.Influence = _map.Tiles[e.Coordinate.Col, e.Coordinate.Row].Influence;
   }

   private void theMapView_MouseClearOverCoordinate(object sender, EventArgs e)
   {
      Debug.WriteLine($"{nameof(theMapView_MouseClearOverCoordinate)}");
      tileInfluenceView.Influence = new Influence();
   }
}
