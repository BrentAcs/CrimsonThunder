using Balance.App.Renders;
using Balance.Core.Extensions;
using Balance.Core.Models;

namespace Balance.App.Controls;

public partial class InfluenceView : UserControl
{
   private readonly InfluenceRenderer _renderer = new(BorderSize);

   public InfluenceView()
   {
      InitializeComponent();
   }

   private Influence? _influence;
   public Influence? Influence
   {
      get => _influence;
      set
      {
         _influence = value;
         Invalidate();
      }
   }

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
