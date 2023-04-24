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

      _map = Globals.MapFactory.Create();
      Globals.MapPopulator.Populate(_map, new IRealmTileMapPopulator.Options());

      theMapControl.Initialize(_map);
      totalInfluenceView.Influence = _map.Influence;
   }

   private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
   {
      UserSettings.Default.MainForm_Location = Location;
      UserSettings.Default.MainForm_Size = Size;
   }
}
