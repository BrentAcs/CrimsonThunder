using Balance.Core.Models;
using Balance.Core.Services;

namespace Balance.App.Forms;

public partial class MainForm : Form
{
   private RealmTileMap? _map;

   public MainForm()
   {
      InitializeComponent();
   }

   private void MainForm_Load(object sender, EventArgs e)
   {
      Location = UserSettings.Default.MainForm_Location;
      Size = UserSettings.Default.MainForm_Size;

      _map = Globals.MapFactory.Create(new IRealmTileMapFactory.Options());

      _map.Tiles[1, 1].Influence.SetAmount(Player.One, 10);
      _map.Tiles[1, 1].Influence.SetAmount(Player.Two, 20);
      _map.Tiles[1, 1].Influence.SetAmount(Player.Three, 30);
      _map.Tiles[1, 1].Influence.SetAmount(Player.Four, 40);

      theMapControl.Initialize(_map);

      _map.Tiles[1, 1].Influence.SetAmount(Player.Four, 50);
   }

   private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
   {
      UserSettings.Default.MainForm_Location = Location;
      UserSettings.Default.MainForm_Size = Size;
   }
}
