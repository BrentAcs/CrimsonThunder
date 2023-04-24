using Balance.Core.Extensions;
using Balance.Core.Models;

namespace Balance.App.Controls;

public partial class InfluenceView : UserControl
{
   private InfluenceRenderer _renderer = new(BorderSize);

   public InfluenceView()
   {
      InitializeComponent();
   }

   public Influence? Influence { get; set; }

   private Influence InfluenceInternal => Influence ?? new Influence(25, 0, 50, 100);
   private int PlayerCount => Enum.GetValues<Player>().ExcludeNone().Count();

   private const int BorderSize = 2;

   protected override void OnPaint(PaintEventArgs e)
   {
      var g = e.Graphics;
      _renderer.Render(g, ClientRectangle, InfluenceInternal);
      base.OnPaint(e);
   }
}
